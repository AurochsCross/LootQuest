namespace LootQuest.Models.Action.Aura {
    public class Trigger {
        public TriggerType Type { get; private set; }
        public ActionRoot TriggeredAction { get; private set; }
        public Logic.Entity.Commanders.BattleCommander.BattleHandler EventHandler;

        public Trigger(TriggerType type, ActionRoot action) {
            Type = type;
            TriggeredAction = action;
        }
    }
}