//Adding event handlers
document.getElementById('btnSearch').addEventListener('click', searchUser);

window.onload = () => {
  console.log("The website is reading this: Index.js");
};

function searchUser() {
  const elem = document.getElementById('steamId');
  console.log("Searching for user: " + elem.value);
}
