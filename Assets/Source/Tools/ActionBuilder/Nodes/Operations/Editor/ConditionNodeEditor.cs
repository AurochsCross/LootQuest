using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.ActionBuilder.Nodes {
    [CustomNodeEditor(typeof(ConditionNode))]
    public class ConditionNodeEditor : NodeEditor {
        public override void OnBodyGUI() {
            ConditionNode node = target as ConditionNode;

            NodeEditorGUILayout.PortField(node.GetPort("first"));
            node.condition = (ConditionType)GUILayout.SelectionGrid((int)node.condition, new string[]{">", "<", "="}, 3);
            NodeEditorGUILayout.PortField(node.GetPort("second"));
            NodeEditorGUILayout.PortField(node.GetPort("result"));
        }
    }
}