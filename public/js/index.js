//Adding event handlers
window.addEventListener('DOMContentLoaded', async function(){
  initFuncs();
});

function initFuncs(){
  btnSearchClick();
  faceitUserAtributes();

  createElements();
}

function btnSearchClick(){
  let btnSearch = document.getElementById('btnSearch');
  if(btnSearch != null)  {
    btnSearch.addEventListener('click', getUserData);
  }
}

function faceitUserAtributes(){
  let faceitUser = document.getElementById('steamId');
  faceitUser.addEventListener("keyup", function(event) {
    if (event.keyCode === 13 && faceitUser.value != "") {
      event.preventDefault();
      getUserData();
    }
    else
      if(faceitUser.value != ""){
        //Menssage there is no FaceitUser written
      }
  });
}

function getUserData() {
  const user = document.getElementById('steamId').value;
  //const game = getRadioButtonValue();
  if(user != ""){
    window.location.href = '/player.html?id=' + user + '&game=' + "csgo"; //"/player.html?id=" + user;
  }
  else {
    //Menssage there is no FaceitUser written
  }
}
function getRadioButtonValue(){
  const children = document.querySelector(".radio:checked").value;
  return children;
}

async function createElements(){
  const col = [];

  col.push(createTop5Elo());
  col.push(createTop5Kd());

  col.forEach(item => {
    //window.mainContainer.appendChild(item);
    $('.main-content').append(item);
  });
}

async function createTop5Elo(players){
  //console.log(players);

  let mainDiv = document.querySelector(".top-main.topElo");

  for (let i = 0; i < 5; i++) {
    let playerContainer = document.createElement("a");
    playerContainer.classList.add("player-container");

    let imgContainer = document.createElement("div");
    imgContainer.classList.add("img-container");

    let img = document.createElement("img");
    img.src = "";

    imgContainer.appendChild(img);
    playerContainer.appendChild(imgContainer);

    let valuesContainer = document.createElement("div");
    valuesContainer.classList.add("values");

    let name = document.createElement("span");
    name.classList.add("name");
    name.innerHTML = "Nome";

    valuesContainer.appendChild(name);

    name = document.createElement("span");
    name.innerHTML = "Elo";
    valuesContainer.appendChild(name);

    name = document.createElement("span");
    name.innerHTML = "K/D Ratio";
    valuesContainer.appendChild(name);

    playerContainer.appendChild(valuesContainer);
    mainDiv.appendChild(playerContainer);
  }

  return mainDiv;
}

async function createTop5Kd(players){
  //console.log(players);

  let mainDiv = document.querySelector(".top-main.topKd");

  for (let i = 0; i < 5; i++) {
    let playerContainer = document.createElement("a");
    playerContainer.classList.add("player-container");

    let imgContainer = document.createElement("div");
    imgContainer.classList.add("img-container");

    let img = document.createElement("img");
    img.src = "";

    imgContainer.appendChild(img);
    playerContainer.appendChild(imgContainer);

    let valuesContainer = document.createElement("div");
    valuesContainer.classList.add("values");

    let name = document.createElement("span");
    name.classList.add("name");
    name.innerHTML = "Nome";

    valuesContainer.appendChild(name);

    name = document.createElement("span");
    name.innerHTML = "K/D Ratio";
    valuesContainer.appendChild(name);

    name = document.createElement("span");
    name.innerHTML = "Elo";
    valuesContainer.appendChild(name);

    playerContainer.appendChild(valuesContainer);
    mainDiv.appendChild(playerContainer);
  }

  return mainDiv;
}
