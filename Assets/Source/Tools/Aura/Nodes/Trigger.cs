using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura.Nodes {
    public enum TriggerType {
        OnInflictingDamage,
        OnDamageTaken,
        OnHealingTaken,
        OnRepeatingTimer,
        OnCreation,
        OnCompletion,
        OnDestruction
    }

    [NodeWidth(250)]
    public class Trigger : Node {
        [Input] public AuraMasterNode Master;
        public TriggerType Type;
        [Output] public Trigger OnTrigger;
        [Output] public string Value;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "OnTrigger") 
                return this;
            else 
                return null;
        }

    }
}