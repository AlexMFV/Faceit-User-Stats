//Adding event handlers
let btnSearch = document.getElementById('btnSearch');
btnSearch.addEventListener('click', getUserData);

let faceitUser = document.getElementById('steamId');
faceitUser.addEventListener("keyup", function(event) {
  if (event.keyCode === 13 && faceitUser.value != "") {
    event.preventDefault();
    getUserData();
  }
  else
    if(faceitUser.value != ""){
      //Menssage there is no FaceitUser written
    }
});

function getUserData() {
  const user = document.getElementById('steamId').value;
  const game = getRadioButtonValue();
  if(user != ""){
    window.location.href = '/player.html?id=' + user + '&game=' + game; //"/player.html?id=" + user;
  }
  else {
    //Menssage there is no FaceitUser written
  }
}

function getRadioButtonValue(){
  const children = document.querySelector(".radio:checked").value;
  return children;
}
