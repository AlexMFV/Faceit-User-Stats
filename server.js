const express = require('express');
const app = express();
const path = require('path');
const ejs = require('ejs');
const pg = require('pg');
const https = require('https');
const fs = require('fs');

const api_key = fs.readFileSync('apikey.txt').toString('utf8');

const packet = {
  method: "GET",
  headers: {
    "Content-Type": "application/json",
    "Authorization": "Bearer " + api_key
  }
};

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

app.listen(8080);
console.log("Server listening on port 8080!");

/*function something(req, res){
  try{
    res.json(value);
  }
  catch(e){
    error(res, e);
  }
}*/

function error(res, msg) {
  res.sendStatus(500);
  console.error(msg);
}
