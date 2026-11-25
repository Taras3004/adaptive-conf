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

  const offer = await pc1Connection.createOffer();
  await pc1Connection.setLocalDescription(offer);
  await waitForIceGathering(pc1Connection);
  offerTextarea.value = JSON.stringify(pc1Connection.localDescription);
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
  const offer = JSON.parse(offerTextarea.value);

  pc1Connection.ontrack = (event) => {
    if (pc2VideoElement.srcObject) return;
    pc2VideoElement.srcObject = event.streams[0];
  };

  await pc1Connection.setRemoteDescription(offer);

  const answer = await pc1Connection.createAnswer();
  await pc1Connection.setLocalDescription(answer);
  await waitForIceGathering(pc1Connection);
  answerTextarea.value = JSON.stringify(pc1Connection.localDescription);
}

async function receiveAnswer() {
  const answer = JSON.parse(answerTextarea.value);

  await pc1Connection.setRemoteDescription(answer);
}

async function getStats() {
  const result = await pc1Connection.getStats();

  result.forEach((x) => console.log(x));
}
