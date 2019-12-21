const express = require('express');
const app = express();
const path = require('path');
const ejs = require('ejs');
const pg = require('pg');
const https = require('https');
const fs = require('fs');
const request = require('request');

const api_key = fs.readFileSync('apikey.txt').toString('utf8');
const packet = {
  method: "GET",
  headers: {
    "Content-Type": "application/json",
    "Authorization": "Bearer " + api_key
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

app.get('/api/playerData', getPlayerData);

app.listen(8080);
console.log("Server listening on port 8080!");

function getPlayerData(req, res){
  try{
    let value;
    const final = request(strPlayerData.replace('<usr>', req.body.user), { json: true }, (err, res, body) => {
      if (err) { return console.log(err); }
      console.log(body);
      value = body;
      return body;
    });

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
