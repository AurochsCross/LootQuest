using System.Linq;

namespace Logic.Battle {
    public class Battlefield {
        public Logic.Game.Commanders.BattleCommander battleManager { get; } = new Game.Commanders.BattleCommander();
        public Logic.Bases.Commanders.BattleCommander[] battleCommanders;
        public Battlefield(Logic.Bases.Commanders.BattleCommander[] battleCommanders) {
            this.battleCommanders = battleCommanders;
            battleCommanders.ToList().ForEach(x => x.battlefield = this);
        }
    }
}