function startGenerating()
{
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
      var slides =[ "https://via.placeholder.com/960x1280.png",
      "https://via.placeholder.com/1080x1920.png",
      "https://via.placeholder.com/1080x2048.png",
      ]
      Image.src=slides[slideIndex];
      slideIndex++;
      if (slideIndex == slides.length) {slideIndex = 0}   
      setTimeout(showSlides, 4000); // Change image every 2 seconds

    //  if(i==0)
    //  {
    //      Image.src="https://assets3.thrillist.com/v1/image/3005227/792x815/scale;jpeg_quality=60.jpg";
    //      i++;
    //  }
    //  else if (i==1)
    //  {
    //      Image.src=  "https://assets3.thrillist.com/v1/image/3005222/792x918/scale;jpeg_quality=60.jpg";
    //      i = 0;
    
    //  for (each item in jsonobject)
    //  do {get json[i]
    //  i = jsonobject.length {sig selv}}

        // setTimeout(showSlides,4000);
    }
}