document.getElementById("submit-button").addEventListener("click", submit);

document.getElementById("call-button").addEventListener("click", call);

const pc2VideoElement = document.getElementById("pc-2");

const offerTextarea = document.getElementById("offer-textarea");
const answerTextarea = document.getElementById("answer-textarea");
const receiveOfferButton = document.getElementById("receive-offer-button");
receiveOfferButton.addEventListener("click", receiveOffer);
const receiveAnswerButton = document.getElementById("receive-answer-button");
receiveAnswerButton.addEventListener("click", receiveAnswer);

const statsButton = document.getElementById("stats-button");
statsButton.addEventListener("click", async () => await getStats());

let myMediaStream;

const config = {
  iceServers: [{ urls: "stun:stun3.l.google.com:19302" }],
};

const ALLOWED_VIDEO_CODECS = ["video/vp8", "video/rtx"];

const pc1Connection = new RTCPeerConnection(config);

pc1Connection.addEventListener("connectionstatechange", (x) => {
  console.log("State: ", pc1Connection.connectionState);
});

pc1Connection.addEventListener("iceconnectionstatechange", (x) => {
  console.log("ICE State: ", pc1Connection.iceConnectionState);
});

async function submit() {
  const myVideoElement = document.getElementById("pc-1");

  const constraints = { audio: true, video: { width: 1280, height: 720 } };
  myMediaStream = await navigator.mediaDevices.getUserMedia(constraints);

  myVideoElement.srcObject = myMediaStream;
}

async function call() {
  pc1Connection.addTrack(myMediaStream.getVideoTracks()[0], myMediaStream);
  restrictVideoCodecs(pc1Connection);

  const offer = await pc1Connection.createOffer();
  await pc1Connection.setLocalDescription(offer);
  await waitForIceGathering(pc1Connection);
  offerTextarea.value = await encodeDescription(pc1Connection.localDescription);
}

function waitForIceGathering(pc) {
  return new Promise((resolve) => {
    if (pc.iceGatheringState === "complete") {
      resolve();
      return;
    }
    const onChange = () => {
      if (pc.iceGatheringState === "complete") {
        pc.removeEventListener("icegatheringstatechange", onChange);
        resolve();
      }
    };
    pc.addEventListener("icegatheringstatechange", onChange);
  });
}

async function receiveOffer() {
  const offer = await decodeDescription(offerTextarea.value);

  pc1Connection.ontrack = (event) => {
    if (pc2VideoElement.srcObject) return;
    pc2VideoElement.srcObject = event.streams[0];
  };

  await pc1Connection.setRemoteDescription(offer);
  restrictVideoCodecs(pc1Connection);

  const answer = await pc1Connection.createAnswer();
  await pc1Connection.setLocalDescription(answer);
  await waitForIceGathering(pc1Connection);
  answerTextarea.value = await encodeDescription(
    pc1Connection.localDescription,
  );
}

async function receiveAnswer() {
  const answer = await decodeDescription(answerTextarea.value);

  await pc1Connection.setRemoteDescription(answer);
}

async function getStats() {
  const result = await pc1Connection.getStats();

  result.forEach((x) => console.log(x));
}

function restrictVideoCodecs(pc) {
  const capabilities = RTCRtpReceiver.getCapabilities("video");
  const allowed = capabilities.codecs.filter((codec) =>
    ALLOWED_VIDEO_CODECS.includes(codec.mimeType.toLowerCase()),
  );

  for (const transceiver of pc.getTransceivers()) {
    if (transceiver.receiver.track.kind !== "video") continue;
    try {
      transceiver.setCodecPreferences(allowed);
    } catch (error) {
      console.error("setCodecPreferences failed:", error);
    }
  }
}

async function compress(text) {
  const stream = new Blob([text])
    .stream()
    .pipeThrough(new CompressionStream("deflate-raw"));
  return new Uint8Array(await new Response(stream).arrayBuffer());
}

async function decompress(bytes) {
  const stream = new Blob([bytes])
    .stream()
    .pipeThrough(new DecompressionStream("deflate-raw"));
  return new Response(stream).text();
}

function bytesToBase64Url(bytes) {
  let binary = "";
  for (const b of bytes) binary += String.fromCharCode(b);
  return btoa(binary)
    .replace(/\+/g, "-")
    .replace(/\//g, "_")
    .replace(/=+$/, "");
}

function base64UrlToBytes(text) {
  const base64 = text.replace(/-/g, "+").replace(/_/g, "/");
  const padded = base64 + "=".repeat((4 - (base64.length % 4)) % 4);
  return Uint8Array.from(atob(padded), (c) => c.charCodeAt(0));
}

async function encodeDescription(description) {
  const json = JSON.stringify(description);
  const encoded = bytesToBase64Url(await compress(json));
  console.log(
    `Description: ${json.length} chars -> ${encoded.length} chars (deflate-raw + base64url)`,
  );
  return encoded;
}

async function decodeDescription(text) {
  return JSON.parse(await decompress(base64UrlToBytes(text.trim())));
}
