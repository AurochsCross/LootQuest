using System.Collections.Generic;

namespace LootQuest.Models.Action.Aura {
    public class AuraRoot: Representable {
        public List<CompletionCondition> CompletionConditions { get; private set; }
        public List<CompletionCondition> DestroyConditions { get; private set; }
        public List<Trigger> Triggers { get; private set; }

        public bool IsOverridingDamage { get; private set; } = false;
        public string DamageOverride { get; private set; }
        public bool IsOverridingHealing { get; private set; } = false;
        public string HealingOverride { get; private set; }

        public AuraRoot(List<CompletionCondition> completionConditions, List<CompletionCondition> destroyConditions, List<Trigger> triggers) {
            CompletionConditions = completionConditions;
            DestroyConditions = destroyConditions;
            Triggers = triggers;
        }

        public void AddDamageOverride(string overrideFunction) {
            IsOverridingDamage = true;
            DamageOverride = overrideFunction;
        }

        public void AddHealingOverride(string overrideFunction) {
            IsOverridingHealing = true;
            HealingOverride = overrideFunction;
        }
    }
}