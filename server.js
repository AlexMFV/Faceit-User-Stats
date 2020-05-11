const express = require('express');
const app = express();
const path = require('path');
const pg = require('pg');
const fs = require('fs');
const fetch = require('node-fetch');

const api_key = fs.readFileSync('apikey.txt').toString('utf8');
const packet = {
  method: "GET",
  headers: {
    "Content-Type": "application/json",
    'Authorization': ("Bearer " + api_key)
  }
};

/* API URL CONSTANTS */
const faceitUrl = "https://open.faceit.com/data/v4/";
const strPlayerData = "players?nickname=<usr>";
const strPlayerRanking = "rankings/games/<game>/regions/<region>/players/<usrId>?country=<country>&limit=2";
const strPlayerRegional = "rankings/games/<game>/regions/<region>/players/<usrId>?limit=2";
const strPlayerMatches = "players/<usrId>/history?game=<game>&from=<start>&to=<end>&offset=0&limit=15";
const strMatchInfo = "matches/<matchId>/stats";

//Set the visible folders for the server
app.use(express.static(path.join(__dirname, 'public')));
app.use(express.static(path.join(__dirname, 'views')));
app.use(express.json());
app.engine('.html', require('ejs').__express);
//app.set('views', __dirname + '/views');
app.set('view engine', 'html');

app.get('/', function(req, res){
  res.render('index');
});

/* POST REQUESTS */

/* GET REQUESTS */
app.get('/api/player/:id', getPlayerData);
app.get('/api/ranking/:player', getPlayerRanking);
app.get('/api/player/matches/:player', getPlayerMatches);
app.get('/api/player/match/:match', getMatchInfo);
app.get('/api/match/:id', getMatchData);

app.listen(8080);
console.log("Server listening on port 8080!");

/* SERVER METHODS */

async function getPlayerData(req, res){
  let value;
  try{
    const user = req.params.id;

    value = await fetch(faceitUrl + strPlayerData.replace('<usr>', user), packet).then((res) => { return res.json(); });
    res.json(value);
  }
  catch(e){
    error(res, e);
  }
}

async function getPlayerRanking(req, res){
  let value;
  try{
    const player = JSON.parse(req.params.player);
    const userId = player.id;
    const gameId = player.game;
    const region = player.region;
    const country = player.country;
    //Get Regional and Country Rank

    value = await fetch(faceitUrl + strPlayerRanking
      .replace('<usrId>', userId)
      .replace('<game>', gameId)
      .replace('<region>', region)
      .replace('<country>', country), packet).then((res) => { return res.json(); });

    regional = await fetch(faceitUrl + strPlayerRegional
      .replace('<usrId>', userId)
      .replace('<game>', gameId)
      .replace('<region>', region), packet).then((res) => { return res.json(); });

    value.regionPos = regional.position;
    res.json(value);
  }
  catch(e){
    error(res, e);
  }
}

async function getPlayerMatches(req, res){
  let value;
  try{
    const player = JSON.parse(req.params.player);
    const userId = player.id;
    const gameId = player.game;
    const startDate = player.startDate;
    const endDate = player.endDate;
    //Get Matches

    value = await fetch(faceitUrl + strPlayerMatches
      .replace('<usrId>', userId)
      .replace('<game>', gameId)
      .replace('<start>', startDate)
      .replace('<end>', endDate), packet).then((res) => { return res.json(); });

    res.json(value);
  }
  catch(e){
    error(res, e);
  }
}

async function getMatchInfo(req, res){
  let value;
  try{
    const match = JSON.parse(req.params.match);
    const matchId = match.id;
    //Get Match Info

    value = await fetch(faceitUrl + strMatchInfo
      .replace('<matchId>', matchId), packet).then((res) => { return res.json(); });

    res.json(value);
  }
  catch(e){
    error(res, e);
  }
}

async function getMatchData(req, res){
  let value;
  try{
    const id = req.params.id;

    value = await fetch(faceitUrl + strMatchInfo
      .replace('<matchId>', id), packet).then((res) => { return res.json(); });
    res.json(value);
  }
  catch(e){
    error(res, e);
  }
}

function Epoch(date) {
    return Math.round(new Date(date).getTime() / 1000.0);
}

function error(res, msg) {
  res.sendStatus(500);
  console.error(msg);
}
