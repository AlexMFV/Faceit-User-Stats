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

async function createElements(match){
  console.log(match);

  const col = [];

  /*MAIN CONTAINER*/
  let matchContainer = document.createElement("div");
  matchContainer.classList.add("match-container");

  /*Matches Header*/
  const matchHeaderContainer = document.createElement("div");
  matchHeaderContainer.classList.add("match-header");

  let matchHeader = document.createElement("div");
  let matchSecundHeader = document.createElement("div");
  let matchTeamNames = document.createElement("span");

  matchSecundHeader.classList.add("secund-header");
  matchTeamNames.innerHTML = match.team.team_stats.Team + "  ";

  matchSecundHeader.appendChild(matchTeamNames);

  matchTeamNames = document.createElement("span");
  matchTeamNames.innerHTML = match.team.team_stats["Final Score"];

  matchSecundHeader.appendChild(matchTeamNames);
  matchHeader.appendChild(matchSecundHeader);
  matchHeaderContainer.appendChild(matchHeader);

  matchHeader = document.createElement("div");

  matchSecundHeader = document.createElement("div");
  matchSecundHeader.classList.add("secund-header");

  matchTeamNames = document.createElement("span");
  matchTeamNames.innerHTML = "VS";

  matchSecundHeader.appendChild(matchTeamNames);
  matchHeaderContainer.appendChild(matchSecundHeader);

  matchHeader = document.createElement("div");

  matchSecundHeader = document.createElement("div");
  matchSecundHeader.classList.add("secund-header");

  matchTeamNames = document.createElement("span");
  matchTeamNames.innerHTML = match.team1.team_stats.Team + "  ";

  matchSecundHeader.appendChild(matchTeamNames);

  matchTeamNames = document.createElement("span");
  matchTeamNames.innerHTML = match.team1.team_stats["Final Score"];

  matchSecundHeader.appendChild(matchTeamNames);
  matchHeader.appendChild(matchSecundHeader);

  matchHeaderContainer.appendChild(matchHeader);
  /***************************/

  matchContainer.appendChild(matchHeaderContainer);
  /****************/

  col.push(matchContainer);
  /*******************************************************************************************/

  /*
  *
    FALTA AVATAR E LEVEL DO PLAYER (BUSCAR NA API)
  *
  */

  /*First/Left Team*/
  const firstTeamContainer = DoPlayerStats(match.team,"left-team-container");
  col.push(firstTeamContainer);
  /*******************************************************************************************/

  /*Secund/Right Team*/
  const secundTeamContainer = DoPlayerStats(match.team1,"right-team-container");
  col.push(secundTeamContainer);
  /*******************************************************************************************/

  col.forEach(item => {
    //window.mainContainer.appendChild(item);
    $('#content').append(item);
  });

  ToggleLoading();
};

function DoPlayerStats(team, classContainer){
  const teamContainer = document.createElement("div");
  teamContainer.classList.add(classContainer);

  const Team = team;
  let players = Team.players;

  for(let i = 0;i <= players.length - 1;i++){
    const player = players[i];
    const playerStats = player.player_stats;
    let icon = document.createElement("i");

    //Main Player Container
    const playerContainer = document.createElement("div");
    playerContainer.classList.add("player-container");

    //Avatar
    const avatarContainer = document.createElement("div");
    avatarContainer.classList.add("avatar-container");

    const avatar = document.createElement('img');
    avatar.classList.add('player-avatar');
    avatar.src = "https://i.picsum.photos/id/581/200/300.jpg";

    avatarContainer.appendChild(avatar);
    playerContainer.appendChild(avatarContainer);

    //Name + Level
    let staticContainer = document.createElement("div");
    staticContainer.classList.add("static-container");

    let value = document.createElement("span");
    value.classList.add("static-value");
    value.classList.add("title");
    value.innerHTML = player.nickname + "  LEVEL 6";

    staticContainer.appendChild(value);
    playerContainer.appendChild(staticContainer);

    //Score (K-A-D) + K/D Ratio
    staticContainer = document.createElement("div");
    staticContainer.classList.add("static-container");

    value = document.createElement("span");
    value.classList.add("static-value");
    value.innerHTML = " " +playerStats.Kills + "-"+ playerStats.Assists + "-" + playerStats.Deaths + " (K/D " + playerStats["K/D Ratio"] + ")";

    icon.classList.add("fas");
    icon.classList.add("fa-chart-bar");

    staticContainer.appendChild(icon);
    staticContainer.appendChild(value);
    playerContainer.appendChild(staticContainer);

    //Headshot %
    staticContainer = document.createElement("div");
    staticContainer.classList.add("static-container");

    value = document.createElement("span");
    value.classList.add("static-value");
    value.innerHTML = " " + playerStats["Headshots %"] + "%";

    icon = document.createElement("i");
    icon.classList.add("fas");
    icon.classList.add("fa-bullseye");

    staticContainer.appendChild(icon);
    staticContainer.appendChild(value);

    //MVP's
    value = document.createElement("span");
    value.classList.add("static-value");
    value.innerHTML = " " + playerStats.MVPs;

    icon = document.createElement("i");
    icon.classList.add("fas");
    icon.classList.add("fa-star");

    staticContainer.appendChild(icon);
    staticContainer.appendChild(value);
    playerContainer.appendChild(staticContainer);

    //Triple Kills
    staticContainer  = document.createElement("div");
    staticContainer.classList.add("static-container");

    icon = document.createElement("i");
    icon.classList.add("fas");
    icon.classList.add("fa-skull");

    value = document.createElement("span");
    value.classList.add("static-value");
    value.innerHTML = "3x";

    staticContainer.appendChild(value);
    staticContainer.appendChild(icon);

    icon = document.createElement("i");
    icon.classList.add("fas");
    icon.classList.add("fa-skull");

    value = document.createElement("span");
    value.classList.add("static-value");
    value.innerHTML = " " + playerStats["Triple Kills"];
    staticContainer.appendChild(value);

    //Quadra Kills
    value = document.createElement("span");
    value.classList.add("static-value");
    value.innerHTML = " / 4x";

    staticContainer.appendChild(value);
    staticContainer.appendChild(icon);

    icon = document.createElement("i");
    icon.classList.add("fas");
    icon.classList.add("fa-skull");

    value = document.createElement("span");
    value.classList.add("static-value");
    value.innerHTML = " " + playerStats["Quadro Kills"];
    staticContainer.appendChild(value);

    //Penta Kills
    value = document.createElement("span");
    value.classList.add("static-value");
    value.innerHTML = "/ 5x";

    staticContainer.appendChild(value);
    staticContainer.appendChild(icon);

    value = document.createElement("span");
    value.classList.add("static-value");
    value.innerHTML = " " + playerStats["Penta Kills"];
    staticContainer.appendChild(value);

    playerContainer.appendChild(staticContainer);

    /************************************************/
    teamContainer.appendChild(playerContainer);
  }

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
