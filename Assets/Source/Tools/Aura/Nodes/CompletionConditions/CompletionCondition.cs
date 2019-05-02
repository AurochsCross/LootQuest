using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura.Nodes.CompletionConditions {

    public enum CompletionConditionType {
        Time,
        ActionsUsed,
        DamageTaken,
        DamageActionsTaken,
        DamageInflicted
    }

    [NodeWidth(250)]
    public class CompletionCondition : Node, Interfaces.ICompletionCondition {

        public CompletionConditionType Type;
        [HideInInspector]
        public CasterType Caster;
        [Input] public string Value;
        [Output] public CompletionCondition Condition;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "Condition") 
                return this;
            else 
                return null;
        }

    }
}