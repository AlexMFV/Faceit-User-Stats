//Adding event handlers
document.getElementById('btnSearch').addEventListener('click', getUserData);

function getUserData() {
  const user = document.getElementById('steamId').value;

  const options = {
    method: "GET",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(user)
  };

  const data = requestUserData('/api/playerData', options);
  console.log(data);
}

async function requestUserData(dir, options) {
  const response = await fetch(dir, options)
    .then((response) => {return response.json();});
    return response;
}
