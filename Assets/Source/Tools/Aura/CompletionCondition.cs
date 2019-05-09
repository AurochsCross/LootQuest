using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura {
    [NodeWidth(250)]
    public class CompletionCondition : Node {

        public LootQuest.Models.Action.Aura.CompletionConditionType Type;
        [HideInInspector]
        public LootQuest.Models.Action.Aura.CasterType Caster;
        [Input] public string Value;
        [Output] public CompletionCondition Condition;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "Condition") 
                return this;
            else 
                return null;
        }

        public string GetValue() {
            return GetInputValue<string>("Value", Value);
        }

    }
}