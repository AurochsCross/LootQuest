using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura {
    public class AuraMaster : Node {
        [Input] public CompletionCondition CompletionConditions;
        [Input] public CompletionCondition DestroyConditions;
        public bool OverridesDamage = false;
        [Input] public string DamageOverrideFormula;
        public bool OverridesHealing = false;
        [Input] public string HealingOverrideFormula;
        [Output] public AuraMaster Triggers;
        public GameObject AuraRepresentationEffect;

        [ContextMenu("Set as main")]
        void SetMain() {
            (graph as AuraGraph).MasterNode = this;
        }
    }
}
