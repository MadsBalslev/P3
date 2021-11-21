var posters = [];
var currentPosterIndex = 0;
var timerValue = 5000;

function starPosterScreen() {
    initializePage();
    getTimerValue();
    getPosters();
    setInterval(displayNextPoster, timerValue);
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

function getTimerValue() {
    var req = new XMLHttpRequest();
    req.overrideMimeType("application/json");
    req.open('GET', "http://localhost:5000/metadata/1", true);
    req.onload = function () {
        timerValue = JSON.parse(req.responseText);
    };
    req.send();
}

function getPosters() {
    var req = new XMLHttpRequest();
    req.overrideMimeType("application/json");
    req.open('GET', "http://localhost:5000/Posters", true);
    req.onload = function () {
        posters = JSON.parse(req.responseText);
    };
    req.send();
}

function displayNextPoster() {
    const Image = document.getElementById("imageId");
    if (currentPosterIndex < posters.length) {
        Image.src = posters[currentPosterIndex].image;
        currentPosterIndex++;
    } else {
        currentPosterIndex = 0;
        getTimerValue();
        getPosters();
    }
}