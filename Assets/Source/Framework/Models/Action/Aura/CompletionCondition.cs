namespace LootQuest.Models.Action.Aura {
    public class CompletionCondition {
        public CasterType Caster { get; private set; }
        public CompletionConditionType Type { get; private set; }
        public string Value { get; private set; }

        public CompletionCondition(CasterType caster, CompletionConditionType type, string value) {
            Caster = caster;
            Type = type;
            Value = value;
        }
    }
}