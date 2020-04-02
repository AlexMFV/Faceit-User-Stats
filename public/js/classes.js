class Player{
  constructor(){

  }

  fillRanking(data){
    //Change this to the Game tab later
    console.log(data);


      this.countryPosition = data.position;
      this.regionPosition = data.regionPos;
      this.elo = data.items[0].faceit_elo;
      this.level = data.items[0].game_skill_level;

  }

  fillData(data){
    this.playerId = data.player_id;
    this.steamId = data.platforms.steam;
    this.steamId3 = data.new_steam_id;
    this.steamId64 = data.steam_id_64;
    this.nickname = data.nickname;
    this.country = data.country;
    this.avatarUrl = data.avatar;
    this.infractions = {
      lastInfraction: data.infractions.last_infraction_date,
      afk: data.infractions.afk,
      leaver: data.infractions.leaver,
      noCheckIn: data.infractions.qm_not_checkedin,
      noVote: data.infractions.qm_not_voted
    },
    this.games = data.games;
    this.language = data.settings.language;
    this.friends = data.friends_ids;
    this.bans = data.bans;
    this.membership = data.membership_type;
    this.faceitUrl = data.faceit_url;
    this.matches = [];
  }

  error(error, type){
    this.error = type;
    this.message = error;
  }
}

class Match{
  constructor(){}

    fillData(data){
      this.matchId = data.match_id;
      this.round_stats = data.round_stats;
      this.team = data.teams[0];
      this.team1 = data.teams[1];
    }

    error(error, type){
      this.error = type;
      this.message = error;
    }
}
