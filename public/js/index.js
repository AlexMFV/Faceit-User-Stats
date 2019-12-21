//Adding event handlers
document.getElementById('btnSearch').addEventListener('click', searchUser);

//window.onload = () => {};

function searchUser() {
  const elem = document.getElementById('steamId');
  console.log("Searching for user: " + elem.value);
}

async function requestData(type) {
  const response = await fetch(type, {})
    .then((response) => {return response.json();});
    console.log(response);
}
