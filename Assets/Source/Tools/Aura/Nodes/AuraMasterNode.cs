using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura.Nodes {
    public class AuraMasterNode : Node {
        public bool IsShield = false;
        [Input] public CompletionConditions.CompletionCondition CompletionConditions;
        [Input] public CompletionConditions.CompletionCondition DestroyConditions;
        [Output] public AuraMasterNode Triggers;

        [ContextMenu("Set as main")]
        void SetMain() {
            (graph as AuraGraph).MasterNode = this;
        }
    }
}
