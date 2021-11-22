function starPosterScreen() {
    initializePage();
    getTimerValueThenGetPostersThenDisplayPosters();
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

function getTimerValueThenGetPostersThenDisplayPosters() {
    var req = new XMLHttpRequest();
    req.overrideMimeType("application/json");
    req.open('GET', "http://localhost:5000/metadata/1", true);
    req.onload = function () {
        var timerValue = JSON.parse(req.responseText).timerValue;
        getPostersThenDisplayPosters(timerValue);
    };
    req.send();
}

function getPostersThenDisplayPosters(timerValue) {
    var req = new XMLHttpRequest();
    req.overrideMimeType("application/json");
    req.open('GET', "http://localhost:5000/Posters", true);
    req.onload = function () {
        var posters = JSON.parse(req.responseText);
        displayPosters(timerValue, posters, 0)
    };
    req.send();
}

function displayPosters(timerValue, posters, posterIndex) {
    const image = document.getElementById("imageId");

    if (posterIndex < posters.length) {
        image.src = posters[posterIndex].image;
        posterIndex++;
        setTimeout(displayPosters, timerValue, timerValue, posters, posterIndex);
    } else {
        location.reload()
    }
}