using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.ActionBuilder.Nodes {
    [CustomNodeEditor(typeof(ActionEffectNode))]
    public class ActionEffectNodeEditor : NodeEditor {
        public override void OnBodyGUI() {
                ActionEffectNode node = target as ActionEffectNode;

                node.typeIndex = GUILayout.SelectionGrid(node.typeIndex, new string[]{"Attack", "Heal" }, 2);

                if (node.id == -1) {
                    GUILayout.Label("Id: none");
                } else {
                    GUILayout.Label("Id:" + node.id);
                }

                GUILayout.Label("");

                //GUILayout.BeginHorizontal();
                GUILayout.Label("Hit condition");
                NodeEditorGUILayout.PortField(new GUIContent("Input"), node.GetPort("hitCondition"));
                NodeEditorGUILayout.PortField(node.GetPort("didHit"));

                GUILayout.Label("Value calculation");
                NodeEditorGUILayout.PortField(new GUIContent("Input"), node.GetPort("valueCalculation"));
                NodeEditorGUILayout.PortField(new GUIContent("Calculation"), node.GetPort("valueCalculationRaw"));
                NodeEditorGUILayout.PortField(new GUIContent("Calculated value"), node.GetPort("calculatedValue"));
                
                GUILayout.Label("");
                NodeEditorGUILayout.PortField(node.GetPort("output"));
                //GUILayout.EndHorizontal();

                // SimpleGraph graph = node.graph;
            }
    }
}