//Adding event handlers
document.getElementById('btnSearch').addEventListener('click', getUserData);

async function getUserData() {
  const user = document.getElementById('steamId').value;

  const data = { user };
  const options = {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(data)
  };

  const playerData = await requestData('/api/playerData', options);
  console.log(playerData); // DEBUG: 
}

async function requestData(dir, options) {
  const response = await fetch(dir, options)
    .then((response) => { return response.json(); });
    return response;
}
