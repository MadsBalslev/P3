
    // async function getData(URL) 
    //  {
    //    const response = await fetch(URL);
    //    const data = await response.json();
    // return data;
    // }  
    function getData(url)
    {
        var req = new XMLHttpRequest();
        req.overrideMimeType("application/json");
        req.open('GET', url, true);
        req.onload  = function() {
            slideIndex = 0;
            var jsonResponse = JSON.parse(req.responseText);
            setTimeout(generateSlides(jsonResponse),4000);
            
         };
         req.send();
         
    }

 function startGenerating()
{
    // var Posters = await getData("http://localhost:3000/Posters");
    const screenDiv = document.createElement("div");
    const Image = document.createElement("img")
    Image.src ="https://cdn.discordapp.com/attachments/884375897015205928/905464229480521758/img1.jpg";
    screenDiv.classList = "container";
    Image.id =("imageId");
    Image.classList = "image";
    Image.style.height = "100vh";
    Image.style.width = "100%";
    
    screenDiv.appendChild(Image);
    document.body.appendChild(screenDiv);
    getData("http://localhost:3000/Posters"); 
}


    function generateSlides(Posters)
    {
        const Image = document.getElementById("imageId")
        Image.src = "https://pbs.twimg.com/profile_images/1430729838428446727/ZobAJhkB_400x400.jpg";
        var i = 0;
        var slides =[];
        while (i < Posters.length)
        {
            Posters[i].image
            slides.push(Posters[i].image);
            i++;
        }
        slideIndex++;
        console.log(slideIndex);
        if (slideIndex == slides.length) {slideIndex = 0}   
        setTimeout(generateSlides,4000,Posters); // Change image every 2 seconds
    }