//Adding event handlers
document.getElementById('btnSearch').addEventListener('click', getUserData);

function getUserData() {
  const user = document.getElementById('steamId').value;
  const game = getRadioButtonValue();
  window.location.href = '/player.html?id=' + user + '&game=' + game; //"/player.html?id=" + user;
}

function getRadioButtonValue(){
  const children = document.getElementById('radioCont').children;

  for(let i = 0; i < children.length; i++){
    if(children[i].checked)
      return children[i].value;
  };
}
