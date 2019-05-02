using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura.Nodes.CompletionConditions {
    [CustomNodeEditor(typeof(CompletionCondition))]
    public class CompletionConditionEditor : NodeEditor {
        public override void OnBodyGUI() {
            CompletionCondition node = target as CompletionCondition;

            node.Caster = (LootQuest.Models.Action.Aura.CasterType)GUILayout.SelectionGrid((int)node.Caster, new string[]{"Self", "Other", "Any"}, 3);
            
            base.OnBodyGUI();
        }
    }
}