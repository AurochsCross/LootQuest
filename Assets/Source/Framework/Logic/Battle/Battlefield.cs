// using System.Linq;

// namespace LootQuest.Logic.Battle {
//     public class Battlefield {
//         public Logic.Game.Commanders.BattleCommander battleManager { get; private set; }
//         public Logic.Bases.Commanders.BattleCommander[] battleCommanders;
//         public Battlefield(Logic.Game.Commanders.BattleCommander battleManager, Logic.Bases.Commanders.BattleCommander[] battleCommanders) {
//             this.battleManager = battleManager;
//             this.battleCommanders = battleCommanders;
//             battleCommanders.ToList().ForEach(x => x.battlefield = this);
//         }
//     }
// }