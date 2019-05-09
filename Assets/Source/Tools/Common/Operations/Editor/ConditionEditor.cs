using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Common.Operations.Editor {
    [CustomNodeEditor(typeof(Condition))]
    public class ConditionEditor : NodeEditor {
        public override void OnBodyGUI() {
            Condition node = target as Condition;

            NodeEditorGUILayout.PortField(node.GetPort("a"));
            node.condition = (ConditionType)GUILayout.SelectionGrid((int)node.condition, new string[]{">", "<", "="}, 3);
            NodeEditorGUILayout.PortField(node.GetPort("b"));
            NodeEditorGUILayout.PortField(node.GetPort("result"));
        }
    }
}