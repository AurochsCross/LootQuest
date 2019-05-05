namespace LootQuest.Models.Action.Aura {
    public class Trigger {
        public TriggerType Type { get; private set; }
        public ActionRoot TriggeredAction { get; private set; }
        public float TriggerTime { get; private set; }
        public Logic.Entity.Commanders.BattleCommander.BattleHandler EventHandler;

        public Trigger(TriggerType type, ActionRoot action, float time = 0) {
            Type = type;
            TriggeredAction = action;
            TriggerTime = time;
        }
    }
}