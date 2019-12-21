//Adding event handlers
document.getElementById('btnSearch').addEventListener('click', getUserData);

async function getUserData() {
  const user = document.getElementById('steamId').value;

  window.location.href = "/player?"
}

async function requestData(dir, options) {
  const response = await fetch(dir, options)
    .then((response) => { return response.json(); });
    return response;
}

function processPlayerData(){
  const user = "Something" //Get from QueryString
  //const urlParams = new URLSearchParams(window.location.search);
  //const myParam = urlParams.get('myParam');
  const data = { user };
  const options = {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(data)
  };

  const playerData = await requestData('/api/playerData', options);
}
