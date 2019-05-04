using System;

namespace LootQuest.Models.Events {
    public class AuraEventArgs: EventArgs {
        public int Amount { get; private set; }
        public Models.Action.Aura.TriggerType TriggerType { get; private set; }

        public AuraEventArgs(int amount) {
            Amount = amount;
        }

        public AuraEventArgs(Action.Aura.TriggerType triggerType) {
            TriggerType = triggerType;
        }

        public AuraEventArgs() {
            
        }
    }
}