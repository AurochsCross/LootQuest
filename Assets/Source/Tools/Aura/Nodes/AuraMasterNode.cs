using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura.Nodes {
    public class AuraMasterNode : Node {
        [Input] public CompletionConditions.CompletionCondition CompletionConditions;
        [Input] public CompletionConditions.CompletionCondition DestroyConditions;
        public bool OverridesDamage = false;
        [Input] public string DamageOverrideFormula;
        public bool OverridesHealing = false;
        [Input] public string HealingOverrideFormula;
        [Output] public AuraMasterNode Triggers;
        public GameObject AuraRepresentationEffect;

        [ContextMenu("Set as main")]
        void SetMain() {
            (graph as AuraGraph).MasterNode = this;
        }
    }
}
