
function getData(url) {
    var req = new XMLHttpRequest();
    req.overrideMimeType("application/json");
    req.open('GET', url, true);
    req.onload = function () {
        var jsonResponse = JSON.parse(req.responseText);
        generateSlides(jsonResponse);
    };
    req.send();
}
function startGenerating() {
    generateHTML();
    getData("http://192.168.0.102:5001/Posters");
}

function generateSlides(posters) {
    var slides = [];
    var i = 0;
    while (i < posters.length) {
        const imgUrl = posters[i].image
        slides.push(imgUrl)
        i++;
    }
    var slideIndex = 0;
    showPosters(slides, slideIndex);
    console.log(slides);
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

function showPosters(slides, slideIndex) {
    console.log(slideIndex);
    setPoster(slides[slideIndex]);
    slideIndex++;
    if (slideIndex == slides.length+1) {getData("http://192.168.0.102:5001/Posters")}
    else
    {
    setTimeout(showPosters, 4000, slides,slideIndex);
    }
    
}

function setPoster(image) {
    const Image = document.getElementById("imageId");
    Image.src = image;
}

