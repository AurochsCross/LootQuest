using System;

namespace LootQuest.Models.Events {
    public class EncounterArgs: EventArgs {
        
        public LootQuest.Logic.Game.Commanders.BattleCommander BattleCommander { get; private set; }
        public LootQuest.Logic.Entity.Master[] EncounterParticipatns { get; private set; }

        public EncounterArgs(LootQuest.Logic.Game.Commanders.BattleCommander battleCommander, LootQuest.Logic.Entity.Master[] participants) {
            EncounterParticipatns = participants;
            BattleCommander = battleCommander;
        }
    }
}