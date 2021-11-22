const MAX_LOOP_COUNT = 100;
const API_BASE_ADDRESS = "http://localhost:5000";

function starPosterScreen() {
    initializePage();
    getTimerValueThenGetPostersThenDisplayPosters(0);
}

function initializePage() {
    const screenDiv = document.createElement("div");
    const Image = document.createElement("img");

    screenDiv.id = ("screenDiv");
    screenDiv.classList = "container";
    screenDiv.appendChild(Image);

    Image.src = "https://via.placeholder.com/1080x1920"
    Image.id = ("imageId");
    Image.classList = "image";
    Image.style.height = "100vh";
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
    var req = new XMLHttpRequest();
    req.overrideMimeType("application/json");
    req.open('GET', API_BASE_ADDRESS + "/Posters", true);
    req.onload = function () {
        var posters = JSON.parse(req.responseText);
        displayPosters(timerValue, posters, 0, loopCount)
    };
    req.send();
}

function displayPosters(timerValue, posters, posterIndex, displayPostersCallCount) {
    const image = document.getElementById("imageId");

    if (posterIndex < posters.length) {
        image.src = posters[posterIndex].image;
        posterIndex++;
        setTimeout(displayPosters, timerValue, timerValue, posters, posterIndex, displayPostersCallCount);
    } else if (displayPostersCallCount < MAX_LOOP_COUNT) {
        displayPostersCallCount++;
        getTimerValueThenGetPostersThenDisplayPosters(displayPostersCallCount);
    } else {
        location.reload()
    }
}