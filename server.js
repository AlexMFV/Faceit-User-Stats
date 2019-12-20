const express = require('express');
const app = express();
const path = require('path');
const ejs = require('ejs');
const pg = require('pg');

//Set the visible folders for the server
app.use(express.static(path.join(__dirname, 'public')));
app.use(express.static(path.join(__dirname, 'views')));

//app.use(express.json());

//Set the engine
app.engine('.html', require('ejs').__express);
app.set('views', __dirname + '/views');
app.set('view engine', 'html');

app.get('/faceitstats/', function(req, res){
  res.render('index');
});

app.listen(8080);
console.log("Server listening on port 8080!");
