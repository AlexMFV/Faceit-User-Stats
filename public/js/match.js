const id = new URLSearchParams(window.location.search).get('id');

window.addEventListener('DOMContentLoaded', async function(){
  let match = await processMatchData();

  const matchExists = await fillMatchData(match); // Return false if the match does not exist
});

async function processMatchData(){
  ToggleLoading();

  const jsonData = await requestData('/api/match/'+ id, {method: "GET"});
  let match = new Match();

  if("errors" in jsonData)
    match = null;
  else
    match.fillData(jsonData.rounds[0]);

  return match;
};

async function fillMatchData(match){
  if(match === null)
    alert("Match does not exist!");
  else
    await createElements(match);

  return true;
};

async function getPlayerData(user){
  let player = await processPlayerData(user);
  if(player != null){
    //player = processPlayerRanking(player); //FILLRANKING PROBLEM
    return player;
  }
}
async function processPlayerData(user){
  const jsonData = await requestData('/api/player/'+ user, {method: "GET"});
  let player = new Player();

  if("errors" in jsonData)
    player = null;
  else
    player.fillSimpleData(jsonData);

  return player;
};
async function processPlayerRanking(player){
  const playerInfo = {
    id: player.playerId,
    game: 'csgo',
    regio: 'EU',
    //region: player.games[game].region, //Change this to be dynamic
    country: player.country
  };

  const data = JSON.stringify(playerInfo);

  const rankingData = await requestData('/api/ranking/' + data, {method: "GET"});
  player.fillRanking(rankingData);

  return player;
}

async function createElements(match){
  console.log(match);

  const col = [];

  /*MAIN CONTAINER*/
  let matchContainer = document.createElement("div");
  matchContainer.classList.add("match-container");

  /*Matches Header*/
  const matchHeaderContainer = document.createElement("div");
  matchHeaderContainer.classList.add("match-header");

  let matchSecondHeader = document.createElement("div");
  matchSecondHeader.classList.add("second-header");
  let matchTeamNames = document.createElement("span");
  let matchScoreHeader = document.createElement("div");
  matchScoreHeader.classList.add("score-header");

  matchTeamNames = document.createElement("span");
  matchTeamNames.innerHTML = match.team.team_stats["Final Score"];

  matchScoreHeader.appendChild(matchTeamNames);
  matchSecondHeader.appendChild(matchScoreHeader);

  matchTeamNames = document.createElement("span");
  matchTeamNames.classList.add("team-titles");
  matchTeamNames.innerHTML = match.team.team_stats.Team;

  matchSecondHeader.appendChild(matchTeamNames);

  matchHeaderContainer.appendChild(matchSecondHeader);

  /*RESULTS OF HALFS*/
  matchSecondHeader = document.createElement("div");
  matchSecondHeader.classList.add("second-header");
  /***************/
  let matchResultContainer = document.createElement("div");
  matchResultContainer.classList.add("result-container");

  matchTeamNames = document.createElement("span");
  matchTeamNames.classList.add("first-team");

  matchTeamNames.innerHTML = match.team.team_stats["First Half Score"];
  matchResultContainer.appendChild(matchTeamNames);

  matchTeamNames = document.createElement("span");
  matchTeamNames.classList.add("second-team");

  matchTeamNames.innerHTML = match.team.team_stats["Second Half Score"];
  matchResultContainer.appendChild(matchTeamNames);

  matchSecondHeader.appendChild(matchResultContainer);
  matchHeaderContainer.appendChild(matchSecondHeader);
  /***************/
  /***************/
  matchResultContainer = document.createElement("div");
  matchResultContainer.classList.add("label-result-container");

  matchTeamNames = document.createElement("span");
  matchTeamNames.classList.add("label-result");
  matchTeamNames.innerHTML = "1º";

  matchResultContainer.appendChild(matchTeamNames);

  matchTeamNames = document.createElement("span");
  matchTeamNames.classList.add("label-result");
  matchTeamNames.innerHTML = "2ª";

  matchResultContainer.appendChild(matchTeamNames);
  matchSecondHeader.appendChild(matchResultContainer);
  /***************/

  /***************/
  matchResultContainer = document.createElement("div");
  matchResultContainer.classList.add("result-container");

  matchTeamNames = document.createElement("span");
  matchTeamNames.classList.add("first-team");

  matchTeamNames.innerHTML = match.team1.team_stats["First Half Score"];
  matchResultContainer.appendChild(matchTeamNames);
  /***************/
  /***************/
  matchTeamNames = document.createElement("span");
  matchTeamNames.classList.add("second-team");

  matchTeamNames.innerHTML = match.team1.team_stats["Second Half Score"];
  matchResultContainer.appendChild(matchTeamNames);

  matchSecondHeader.appendChild(matchResultContainer);
  matchHeaderContainer.appendChild(matchSecondHeader);
  /***************/

  matchSecondHeader = document.createElement("div");
  matchSecondHeader.classList.add("second-header");

  matchScoreHeader = document.createElement("div");
  matchScoreHeader.classList.add("score-header");

  matchTeamNames = document.createElement("span");
  matchTeamNames.innerHTML = match.team1.team_stats["Final Score"];

  matchScoreHeader.appendChild(matchTeamNames);
  matchSecondHeader.appendChild(matchScoreHeader);

  matchTeamNames = document.createElement("span");
  matchTeamNames.classList.add("team-titles");
  matchTeamNames.innerHTML = match.team1.team_stats.Team;

  matchSecondHeader.appendChild(matchTeamNames);
  matchHeaderContainer.appendChild(matchSecondHeader);
  /***************************/

  matchContainer.appendChild(matchHeaderContainer);
  /****************/

  /*TEAMS CONTAINER*/
  let teamMainContainer = document.createElement("div");
  teamMainContainer.classList.add("team-main-container");
  /*******************************************************/

  /*MAP*/
  let mapContainer = document.createElement("div");
  mapContainer.classList.add("map-container");

  let iconMap = document.createElement("i");
  iconMap.classList.add("fas");
  iconMap.classList.add("fa-map-marked-alt");

  let matchMap = document.createElement("span");
  matchMap.classList.add("map");
  matchMap.innerHTML = match.round_stats.Map;

  mapContainer.appendChild(iconMap);
  mapContainer.appendChild(matchMap);
  teamMainContainer.appendChild(mapContainer);
  /**/

  /*TEAM HEADER*/
  let headerContainer = document.createElement("div");
  headerContainer.classList.add("teams-header-container");

  let iconGraphic = document.createElement("i");
  iconGraphic.classList.add("fas");
  iconGraphic.classList.add("fa-chart-bar");

  /*right status container*/
  let rightContainer = document.createElement("div");
  rightContainer.classList.add("right-status-container");

  let rightValue = document.createElement("span");
  rightValue.innerHTML = "K";
  rightContainer.appendChild(rightValue);

  rightValue = document.createElement("span");
  rightValue.innerHTML = "A";
  rightContainer.appendChild(rightValue);

  rightValue = document.createElement("span");
  rightValue.innerHTML = "D";
  rightContainer.appendChild(rightValue);

  rightValue = document.createElement("span");
  rightValue.innerHTML = "MVP's";
  rightContainer.appendChild(rightValue);
  headerContainer.appendChild(iconGraphic);
  headerContainer.appendChild(rightContainer);
  teamMainContainer.appendChild(headerContainer);
  /**/

  const firstTeamContainer = await doPlayerStats(match.team,"first-team-container");
  teamMainContainer.appendChild(firstTeamContainer);

  const secondTeamContainer = await doPlayerStats(match.team1,"second-team-container");
  teamMainContainer.appendChild(secondTeamContainer);
  /**/

  matchContainer.appendChild(teamMainContainer);
  /***********************/
  col.push(matchContainer);

  /*******************************************************************************************/

  /*
  *
    FALTA AVATAR E LEVEL DO PLAYER (BUSCAR NA API)
  *
  */
  col.forEach(item => {
    //window.mainContainer.appendChild(item);
    $('#content').append(item);
  });

  ToggleLoading();
};

async function doPlayerStats(team, classContainer){
  const teamContainer = document.createElement("div");
  teamContainer.classList.add(classContainer);

  const ulContainer = document.createElement("ul");

  const Team = team;
  let players = Team.players;

  for(let i = 0;i <= players.length - 1;i++){
    const player = players[i];
    const playerStats = player.player_stats;

    const playerDetailInfo = await getPlayerData(player.nickname);

    let liContainer = document.createElement("li");
    liContainer.classList.add("row-status");

    let levelValue = document.createElement("span");
    levelValue.classList.add("level-value");
    //levelValue.innerHTML = playerDetailInfo.level;
    levelValue.innerHTML = "6";
    liContainer.appendChild(levelValue);

    let imgContainer = document.createElement("div");
    imgContainer.classList.add("img-container");

    let imgValue = document.createElement("img");
    imgValue.classList.add("img");
    imgValue.src = playerDetailInfo.avatarUrl;
    imgContainer.appendChild(imgValue);
    liContainer.appendChild(imgContainer);

    let nameValue = document.createElement("span");
    nameValue.classList.add("name-value");
    nameValue.innerHTML = player.nickname;
    liContainer.appendChild(nameValue);

    rightContainer = document.createElement("div");
    rightContainer.classList.add("right-status-container");

    rightValue = document.createElement("span");
    rightValue.innerHTML = playerStats.Kills;
    rightContainer.appendChild(rightValue);

    rightValue = document.createElement("span");
    rightValue.innerHTML = playerStats.Assists;
    rightContainer.appendChild(rightValue);

    rightValue = document.createElement("span");
    rightValue.innerHTML = playerStats.Deaths;
    rightContainer.appendChild(rightValue);

    rightValue = document.createElement("span");
    rightValue.innerHTML = playerStats.MVPs;
    rightContainer.appendChild(rightValue);

    liContainer.appendChild(rightContainer);

    ulContainer.appendChild(liContainer);
  }

  teamContainer.appendChild(ulContainer);

  return teamContainer;
}

async function requestData(dir, options) {
  const response = await fetch(dir, options)
    .then((response) => { return response.json(); });
    return response;
};

function ToggleLoading(){
  if($('body').find('.lds-background').is(":visible") == false)
    $('body').find('.lds-background').show();
  else
    $('body').find('.lds-background').hide();
};
