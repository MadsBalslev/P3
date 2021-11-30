const MAX_LOOP_COUNT = 100;
const API_BASE_ADDRESS = "http://localhost:5000";

function startPosterScreen() {
    initializePage();
    getTimerValueThenGetPostersThenDisplayPosters(0);
}

function initializePage() {
    const screenDiv = document.createElement("div");
    const Image = document.createElement("img");

    screenDiv.id = ("screenDiv");
    screenDiv.classList = "container";
    screenDiv.appendChild(Image);

    Image.src = "/images/Nordkraft.png"
    Image.id = ("imageId");
    Image.classList = "image";
    Image.style.objectFit = "cover";
    Image.style.height = "100%";
    Image.style.width = "100%";

    document.body.appendChild(screenDiv);
}

function getTimerValueThenGetPostersThenDisplayPosters(loopCount) {
    var req = new XMLHttpRequest();
    req.overrideMimeType("application/json");
    req.open('GET', API_BASE_ADDRESS + "/metadata/1", true);
    req.onload = function () {
        var timerValue = JSON.parse(req.responseText).timerValue;
        getPostersThenDisplayPosters(timerValue, loopCount);
    };
    req.send();
}

function getPostersThenDisplayPosters(timerValue, loopCount) {
    id = window.location.pathname.split("/")[2];
    var req = new XMLHttpRequest();
    req.overrideMimeType("application/json");
    req.open('GET', API_BASE_ADDRESS + "/Zones/Active/" + id, true);
    req.onload = function () {
        var posters = JSON.parse(req.responseText);
        setTimeout(displayPosters, timerValue, timerValue, posters, 0, loopCount);
    };
    req.send();
}

function displayPosters(timerValue, posters, posterIndex, loopCount) {
    const image = document.getElementById("imageId");

    if (posterIndex < posters.length) {
        image.src = posters[posterIndex].image;
        posterIndex++;
        setTimeout(displayPosters, timerValue, timerValue, posters, posterIndex, loopCount);
    } else if (loopCount < MAX_LOOP_COUNT) {
        loopCount++;
        getTimerValueThenGetPostersThenDisplayPosters(loopCount);
    } else {
        location.reload()
    }
}