function getData(url) {
    var req = new XMLHttpRequest();
    req.overrideMimeType("application/json");
    req.open('GET', url, true);
    req.onload = function () {
        var jsonResponse = JSON.parse(req.responseText);
        getPreferences(jsonResponse);
    };
    req.send();
}
function startGenerating() {
    generateHTML();
    getData("http://localhost:5000/Posters");
}

function generateSlides(posters, timer) {
    var slides = [];
    var i = 0;
    while (i < posters.length) {
        const imgUrl = posters[i].image
        slides.push(imgUrl)
        i++;
    }
    var slideIndex = 0;
    showPosters(slides, slideIndex, timer);
    console.log(slides);
}
function getPreferences(jsonResponse) {

    var req = new XMLHttpRequest();
    req.overrideMimeType("application/json");
    req.open('GET', "http://localhost:5000/metadata/1", true);
    req.onload = function () {
        const obj = JSON.parse(req.responseText);
        console.log(obj.timerValue);
       generateSlides(jsonResponse, obj.timerValue);
    };
    req.send();
}

function generateHTML() {
    const screenDiv = document.createElement("div");
    const Image = document.createElement("img");

    screenDiv.id = ("screenDiv");
    screenDiv.classList = "container";
    screenDiv.appendChild(Image);

    Image.src = "https://cdn.discordapp.com/attachments/884375897015205928/905464229480521758/img1.jpg";
    Image.id = ("imageId");
    Image.classList = "image";
    Image.style.height = "100vh";
    Image.style.width = "100%";

    document.body.appendChild(screenDiv);
}

function showPosters(slides, slideIndex, timer) {
    console.log(slideIndex);
    setPoster(slides[slideIndex]);
    slideIndex++;
    if (slideIndex == slides.length+1) {getData("http://localhost:5000/Posterss")}
    else
    {
    setTimeout(showPosters, timer, slides,slideIndex,timer);
    }
}

function setPoster(image) {
    const Image = document.getElementById("imageId");
    Image.src = image;
}

