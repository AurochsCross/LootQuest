using System.Collections.Generic;

namespace LootQuest.Models.Action.Aura {
    public class AuraRoot: Representable {
        public List<CompletionCondition> CompletionConditions { get; private set; }
        public List<CompletionCondition> DestroyConditions { get; private set; }
        public List<Trigger> Triggers { get; private set; }

        public AuraRoot(List<CompletionCondition> completionConditions, List<CompletionCondition> destroyConditions, List<Trigger> triggers) {
            CompletionConditions = completionConditions;
            DestroyConditions = destroyConditions;
            Triggers = triggers;
        }
    }
}