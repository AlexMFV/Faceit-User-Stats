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
const strPlayerData = "https://open.faceit.com/data/v4/players?nickname=<usr>";

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
app.get('/api/ranking/:id', getPlayerRanking);

app.listen(8080);
console.log("Server listening on port 8080!");

/* SERVER METHODS */

async function getPlayerData(req, res){
  let value;
  try{
    const user = req.params.id;
    value = await fetch(strPlayerData.replace('<usr>', user), packet).then((res) => { return res.json(); });
    res.json(value);
  }
  catch(e){
    error(res, e);
  }
}

async function getPlayerRanking(req, res){
  let value;
  try{
    const user = req.params.id;
    //Get Regional and Country Rank
    value = await fetch(strPlayerData.replace('<usr>', user), packet).then((res) => { return res.json(); });
    res.json(value);
  }
  catch(e){
    error(res, e);
  }
}

function error(res, msg) {
  res.sendStatus(500);
  console.error(msg);
}
