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
  avatar.classList.add('player-avatar');
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

  //_blanck attr
  let _blanckAttr = document.createAttribute("target");
  _blanckAttr.value = "_blanck";

  //Player Profile
  let btnWrapper = document.createElement('a');
  btnWrapper.href = player.faceitUrl.replace('{lang}', 'en');
  btnWrapper.classList.add('faceit-btn-profile');
  btnWrapper.setAttributeNode(_blanckAttr);

  //Player id
  /*const pId = document.createElement('p');
  pId.classList.add('player-id');
  pId.innerText = "Player ID: " + player.playerId;
  profileInfoContainer.appendChild(pId);*/

  //Ranking Container
  const rankingContainer = document.createElement('div');
  rankingContainer.classList.add('ranking-container');

  //Country
  const globalRankingContainer = document.createElement('div');
  globalRankingContainer.classList.add('global-ranking-container');

  const ranking = document.createElement('p');
  ranking.innerHTML = "Global Ranking";
  ranking.classList.add('player-global-ranking');

  const globalIcon = document.createElement('i');
  globalIcon.classList.add("fas");
  globalIcon.classList.add("fa-blobe-europe");

  let rankingPosition = document.createElement('p');
  rankingPosition.classList.add("player-position");
  rankingPosition.innerHTML = player.regionPosition.toLocaleString("de-DE");

  globalRankingContainer.appendChild(globalIcon);
  globalRankingContainer.appendChild(ranking);
  globalRankingContainer.appendChild(rankingPosition);

  const countryRankingContainer = document.createElement('div');
  countryRankingContainer.classList.add('country-ranking-container');

  const country = document.createElement('p');
  country.classList.add("player-country-ranking");
  country.innerHTML = "National Ranking";

  rankingPosition = document.createElement('p');
  rankingPosition.classList.add("player-position");
  rankingPosition.innerHTML = player.countryPosition.toLocaleString("de-DE");

  const flag = document.createElement('img');
  flag.src = "https://www.countryflags.io/" + player.country + "/flat/32.png"; //shiny
  flag.classList.add('player-country-flag');

  countryRankingContainer.appendChild(country);
  countryRankingContainer.appendChild(rankingPosition);
  countryRankingContainer.appendChild(flag);

  rankingContainer.appendChild(countryRankingContainer);
  rankingContainer.appendChild(globalRankingContainer);

  profileInfoContainer.appendChild(rankingContainer);

  //Membership
  const membershipContainer = document.createElement('div');
  membershipContainer.classList.add('membership-container');

  const memb = document.createElement('p');
  memb.classList.add("player-membership");
  memb.innerText = "Membership";

  const membVal = document.createElement('p');
  membVal.classList.add("membership");
  membVal.innerText = player.membership;

  if(player.membership == "premium")
    membVal.style.backgroundColor  = "#df6f0d";

  membershipContainer.appendChild(memb);
  membershipContainer.appendChild(membVal);

  profileInfoContainer.appendChild(membershipContainer);

  //Buttons Container
  const buttonsContainer = document.createElement('div');
  buttonsContainer.classList.add('buttons-profile-container');

  //Faceit Profile
  const faceitProfile = document.createElement('button');
  faceitProfile.innerText = "Faceit Profile";
  faceitProfile.classList.add("player-btn");
  btnWrapper.appendChild(faceitProfile);
  btnWrapper.setAttributeNode(_blanckAttr);

  buttonsContainer.appendChild(btnWrapper);

  //Steam Button
  btnWrapper = document.createElement('a');
  btnWrapper.href = "http://steamcommunity.com/profiles/" + player.steamId64;
  btnWrapper.classList.add('steam-btn-profile');

  _blanckAttr = document.createAttribute("target");
  _blanckAttr.value = "_blanck";
  btnWrapper.setAttributeNode(_blanckAttr);

  const steamProfile = document.createElement('button');
  steamProfile.innerText = "Steam Profile";
  steamProfile.classList.add("player-btn");
  btnWrapper.appendChild(steamProfile);
  buttonsContainer.appendChild(btnWrapper);

  profileContainer.appendChild(buttonsContainer);


  const levelContainer = document.createElement('div');
  levelContainer.classList.add('player-level-container');

  const eloContainer = document.createElement('div');
  eloContainer.classList.add('player-elo-container');

  const levelElo = document.createElement('p');
  levelElo.classList.add("level-elo");
  levelElo.innerHTML = `${player.nickname}'s elo is ${player.elo} - level ${player.level}`;

  const eloBar = document.createElement('div');
  eloBar.classList.add('elo-bar');

  const playerEloBar = document.createElement('div');
  playerEloBar.classList.add('player-elo-bar');

  if(player.elo < 2100) {
    playerEloBar.style.width = (player.elo / 2100) * 100 + "%";
  }
  else {
    playerEloBar.style.width = 2100;
  }

  eloBar.appendChild(playerEloBar);

  eloContainer.appendChild(levelElo);
  levelContainer.appendChild(eloContainer);
  levelContainer.appendChild(eloBar);

  col.push(levelContainer);

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
