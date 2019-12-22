//Adding event handlers
document.getElementById('btnSearch').addEventListener('click', getUserData);

async function getUserData() {
  const user = document.getElementById('steamId').value;

  window.location.href = '/player.html?id=' + user; //"/player.html?id=" + user;
}
