using System;

namespace LootQuest.Models.Events {
    public class EffectExecutionArgs: EventArgs {
        public LootQuest.Models.Action.ActionRoot Action { get; private set; }
        public Logic.Entity.Master Source { get; private set; }
        public Logic.Entity.Master Subject { get; private set; }
        public int EffectIndex { get; private set; }
        public bool IsWindupEffect { get; private set; }

        public EffectExecutionArgs(LootQuest.Models.Action.ActionRoot action, Logic.Entity.Master source, Logic.Entity.Master subject, int executedEffectIndex, bool isWindup = false) {
            Action = action;
            Source = source;
            Subject = subject;
            EffectIndex = executedEffectIndex;
            IsWindupEffect = isWindup;
        }
    }
}