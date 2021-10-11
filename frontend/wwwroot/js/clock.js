function GetDateTime() {
  const el = document.querySelector("#date");
  const options = {weekday: 'long', year: 'numeric', month: 'long', day: 'numeric', hour: "numeric", minute: "numeric"};
  const now = new Date(Date.now());
  const localNow = now.toLocaleDateString("da-DK", options);
  el.innerHTML = localNow;
}