
function showSlides(mySlides) {
    // var i;
    // // var slides = mySlides;
    // var slides = mySlides;
    // for (i = 0; i < slides.length; i++) {
    //   slides[i] = "none"; 
    // }
    // var slideIndex = 0;
    // slideIndex++;
    // if (slideIndex > slides.length) {slideIndex = 1}   
    // slides[slideIndex-1] = "block"; 
    // setTimeout(showSlides, 4000); // Change image every 2 seconds
    DotNet.invokeMethodAsync('frontend', "changePictureValue","https://assets3.thrillist.com/v1/image/3005223/792x816/scale;jpeg_quality=60.jpg");
}