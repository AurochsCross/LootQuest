namespace Logic.Game {
    public class Master {

        public Player.Master playerMaster { get; private set; }

        public Master() {
            playerMaster = new Player.Master();
        }


    }
}