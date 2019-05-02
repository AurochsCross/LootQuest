using LootQuest.Models.Exploring;

namespace LootQuest.Logic.Pawns {
    public class ExplorePawn {
        public LootQuest.Logic.Entity.Master Master { get; private set; }
        public Position CurrentPosition;

        public ExplorePawn(LootQuest.Logic.Entity.Master master) {
            Master = master;
            CurrentPosition = new Position();
        }

        public ExplorePawn(LootQuest.Logic.Entity.Master master, Position position) {
            Master = master;
            CurrentPosition = position;
        }
    }
}