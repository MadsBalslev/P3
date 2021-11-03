
    //  async function getData(URL) 
    //  {
    //     const response = await fetch(URL);
    //     const data = await response.json();
    //     return data;
    //  }  

async function startGenerating()
{
    // var Posters = await getData("http://localhost:3000/Posters");
    var slideIndex=0;
    const screenDiv = document.createElement("div");
    const Image = document.createElement("img")
    Image.src ="https://cdn.discordapp.com/attachments/884376312079327262/903342511601356820/image0.jpg"
    screenDiv.classList = "container";
    Image.classList = "image";
    Image.style.height = "100vh";
    Image.style.width = "100%";

    screenDiv.appendChild(Image);
    document.body.appendChild(screenDiv);
    setTimeout(showSlides,4000);
  

    function showSlides() {
      var slides =[];
      Posters.forEach(element => {
          slides.push(element.image);
      });
      
  
      Image.src=slides[slideIndex];
      slideIndex++;
      if (slideIndex == slides.length) {slideIndex = 0}   
      setTimeout(showSlides, 4000); // Change image every 2 seconds
    }
}