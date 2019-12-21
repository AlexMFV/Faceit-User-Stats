class Player{
  constructor(data){
    this.playerId = data.player_id;
    this.steamId = data.platforms.steam;
    this.steamId3 = data.new_steam_id;
    this.steamId64 = data.steam_id_64;
    this.nickname = data.nickname;
    this.country = data.country;
    this.avatarUrl = data.avatar;
    this.infractions = {
      this.lastInfraction = data.infractions.last_infraction_date;
      this.afk = data.infractions.afk;
      this.leaver = data.infractions.leaver;
      this.noCheckIn = data.infractions.qm_not_checkedin;
      this.noVote = data.infractions.qm_not_voted;
    },
    this.games = data.games;
    this.language = data.settings.language;
    this.friends = data.friends_ids;
    this.bans = data.bans;
    this.membership = data.membership_type;
    this.faceitUrl = data.faceit_url;
  }
}
