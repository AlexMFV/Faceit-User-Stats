//const GetData = fetch('/api/player/AlexMFV', {method: "GET"}).then(r=>r.json()).then(data => {
//    fillPlayerData();
//    return data;
//});
//
//$(document).ready(async () => {
//  let someData = await GetData;
//});

window.addEventListener('DOMContentLoaded', async function(){
  const player = await processPlayerData();
  const what = await fillPlayerData(player);
});

async function processPlayerData(){
  const user = new URLSearchParams(window.location.search).get('id');
  const game = new URLSearchParams(window.location.search).get('game');

  //if(game == null)
    //console.log("Redirect to index.js and show error");

  //if(!game in json)
    //console.log("Show user first game in list and show error \"Game not present on user profile\"");

  const json = await requestData('/api/player/'+ user, {method: "GET"});
  let player = new Player();

  if("errors" in json)
    player = null;
  else
    player.fillData(json);

  return player;
}

async function requestData(dir, options) {
  const response = await fetch(dir, options)
    .then((response) => { return response.json(); });
    return response;
}

async function fillPlayerData(player){
  if(player === null)
    alert("The user does not exist!");
  else
    await createElements(player);

  return true;
}

async function createElements(player){
  console.log(player);
  const col = [];

  //Avatar of the player
  const avatar = document.createElement('img');
  avatar.src = player.avatarUrl;
  avatar.classList.add('avatar');
  col.push(avatar);

  //Nickname
  const nick = document.createElement('h2');
  nick.innerHTML = player.nickname;
  col.push(nick);

  //Player id
  const pId = document.createElement('p');
  pId.innerText = "Player ID: " + player.playerId;
  col.push(pId);

  //Player Profile
  let btnWrapper = document.createElement('a');
  btnWrapper.href = player.faceitUrl.replace('{lang}', 'en');
  const faceitProfile = document.createElement('button');
  faceitProfile.innerText = "Faceit Profile";
  btnWrapper.appendChild(faceitProfile);
  col.push(btnWrapper);

  //Steam Button
  btnWrapper = document.createElement('a');
  btnWrapper.href = "http://steamcommunity.com/profiles/" + player.steamId64;
  const steamProfile = document.createElement('button');
  steamProfile.innerText = "Steam Profile";
  btnWrapper.appendChild(steamProfile);
  col.push(btnWrapper);

  //Country
  const ranking = document.createElement('a');
  ranking.innerHTML = "Global Ranking [" + 3932012 + "]";
  const country = document.createElement('img');
  country.src = "https://www.countryflags.io/" + player.country + "/shiny/48.png";
  col.push(ranking);
  col.push(country);

  //Membership
  const memb = document.createElement('p');
  memb.innerText = "Membership: " + player.membership;
  col.push(memb);

  //SteamIDs
  const steamId = document.createElement('p');
  const steamId3 = document.createElement('p');
  const steamId64 = document.createElement('p');
  steamId.innerText = "Steam ID: " + player.steamId;
  steamId3.innerText = "Steam ID3: " + player.steamId3;
  steamId64.innerText = "Steam ID64: " + player.steamId64;
  col.push(steamId);
  col.push(steamId3);
  col.push(steamId64);

  col.forEach(item => {
    window.mainContainer.appendChild(item);
  });

  //Get all player matches
}
