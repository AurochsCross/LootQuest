// using System.Collections.Generic;

// namespace LootQuest.Logic.Player {
//     public class Master {
//         public Commanders.BattleCommander battleCommander { get; private set; } 
//         public Commanders.EquipmentCommander equipmentCommander { get; private set; } 
//         public Pawns.ExplorePawn ExplorePawn { get; private set; }

//         public LootQuest.Models.Common.Attributes Attributes { 
//             get {
//                 return equipmentCommander.GetAttributes();
//             }
//         }

//         public List<LootQuest.Models.Action.ActionRoot> Actions {
//             get {
//                 return equipmentCommander.GetActions();
//             }
//         }

//         public Master() {
//             equipmentCommander = new Commanders.EquipmentCommander();
//             ExplorePawn = new Pawns.ExplorePawn();
//         }

//         public Commanders.BattleCommander CreateBattleCommander() {
//             battleCommander = new Commanders.BattleCommander(Attributes, Actions);
//             return battleCommander;
//         }
//     }
// }