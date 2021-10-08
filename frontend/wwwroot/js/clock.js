function GetDateTime() {
  const dateOptions = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric', hour: "2-digit", minute: "2-digit" };
  let currentTime = new Date();
  let date = currentTime.toLocaleDateString('da-DK', dateOptions);
  document.querySelector(".date").innerHTML = date;
}