using System.Linq;

namespace LootQuest.Logic.Game {
    public class Master {

        #region Events 

        public delegate void EncounterHandler(object myObject, Models.Events.EncounterArgs args);
        public event EncounterHandler OnEncounterStarted;

        #endregion

        public Entity.Master PlayerMaster { get; private set; }
        
        public Commanders.BattleCommander CurrentBattleCommander { get; private set; }

        public Commanders.ExploreCommander ExploreCommander { get; private set; }

        public Master() {
            float time = Utilities.Time.CurrentTime;
            ExploreCommander = new Commanders.ExploreCommander(this);
        }

        public void SetPlayer(Entity.Master playerMaster) {
            PlayerMaster = playerMaster;
        }

        public void StartEncounter(LootQuest.Logic.Entity.Master npc) {
            CurrentBattleCommander = new Commanders.BattleCommander(this);
            var participants = new Entity.Commanders.BattleCommander[]{ PlayerMaster.GenerateBattleCommander(CurrentBattleCommander), npc.GenerateBattleCommander(CurrentBattleCommander) };
            CurrentBattleCommander.SetupBattle(participants);

            OnEncounterStarted(this, new Models.Events.EncounterArgs(CurrentBattleCommander, participants.Select(x => x.Master).ToArray()));
        }
    }
}