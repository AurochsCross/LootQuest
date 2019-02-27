namespace Logic.Game {
    public class Master {

        public Player.Master playerMaster { get; private set; }
        public Commanders.BattleCommander currentBattleCommander { get; private set; }

        public Master() {
            playerMaster = new Player.Master();
        }

        public void InitiateBattle(Pawns.BattlePawn enemy) {
            currentBattleCommander = new Commanders.BattleCommander(new Pawns.BattlePawn[]{ playerMaster.battleCommander.battlePawn, enemy });
        }
    }
}