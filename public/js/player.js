/*BERNARDO CAEIRO*/

//const GetData = fetch('/api/player/AlexMFV', {method: "GET"}).then(r=>r.json()).then(data => {
//    fillPlayerData();
//    return data;
//});
//
//$(document).ready(async () => {
//  let someData = await GetData;
//});

const user = new URLSearchParams(window.location.search).get('id');
const game = new URLSearchParams(window.location.search).get('game');

window.addEventListener('DOMContentLoaded', async function(){
  let player = await processPlayerData();
  player = await processPlayerRanking(player);

  const playerExists = await fillPlayerData(player); // Return false if the user does not exist
});

async function processPlayerData(){
  //if(game == null)
    //console.log("Redirect to index.js and show error");

  //if(!game in json)
    //console.log("Show user first game in list and show error \"Game not present on user profile\"");

  const jsonData = await requestData('/api/player/'+ user, {method: "GET"});
  let player = new Player();

  if("errors" in jsonData)
    player = null;
  else
    player.fillData(jsonData);

  return player;
}

async function processPlayerRanking(player){
  const playerInfo = {
    id: player.playerId,
    game: game,
    region: player.games[game].region, //Change this to be dynamic
    country: player.country
  };

  const data = JSON.stringify(playerInfo);
  console.log(data);

  const rankingData = await requestData('/api/ranking/' + data, {method: "GET"});
  console.log(rankingData);
  player.fillRanking(rankingData);

  return player;
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

  //Create Profile Container
  const profileContainer = document.createElement('div');
  profileContainer.classList.add('profile-container');
  col.push(profileContainer);

  //Avatar Container
  const avatarContainer = document.createElement('div');
  avatarContainer.classList.add('avatar-container');

  //Avatar of the player
  const avatar = document.createElement('img');
  avatar.src = player.avatarUrl;
  avatar.classList.add('avatar');
  avatarContainer.appendChild(avatar);
  profileContainer.appendChild(avatarContainer);

  //Profile Information Container
  const profileInfoContainer = document.createElement('div');
  profileInfoContainer.classList.add('profile-info-container');
  profileContainer.appendChild(profileInfoContainer);

  //Nickname
  const nick = document.createElement('h2');
  nick.innerHTML = player.nickname;
  nick.classList.add('player-nickname');
  profileInfoContainer.appendChild(nick);

  //Player id
  const pId = document.createElement('p');
  pId.innerText = "Player ID: " + player.playerId;
  profileInfoContainer.appendChild(pId);

  //Player Profile
  let btnWrapper = document.createElement('a');
  btnWrapper.href = player.faceitUrl.replace('{lang}', 'en');

  const faceitProfile = document.createElement('button');
  faceitProfile.innerText = "Faceit Profile";
  btnWrapper.appendChild(faceitProfile);
  profileInfoContainer.appendChild(btnWrapper);

  //Steam Button
  btnWrapper = document.createElement('a');
  btnWrapper.href = "http://steamcommunity.com/profiles/" + player.steamId64;
  const steamProfile = document.createElement('button');
  steamProfile.innerText = "Steam Profile";
  btnWrapper.appendChild(steamProfile);
  profileInfoContainer.appendChild(btnWrapper);

  //Country
  const ranking = document.createElement('p');
  ranking.innerHTML = "Global Ranking [" + player.regionPosition + "]";

  const country = document.createElement('p');
  country.classList.add("ranking");
  country.innerHTML = "International Ranking [" + player.countryPosition + "]";
  const flag = document.createElement('img');
  flag.src = "https://www.countryflags.io/" + player.country + "/flat/32.png"; //shiny
  country.appendChild(flag);

  profileInfoContainer.appendChild(ranking);
  profileInfoContainer.appendChild(country);

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

async function requestData(dir, options) {
  const response = await fetch(dir, options)
    .then((response) => { return response.json(); });
    return response;
}
