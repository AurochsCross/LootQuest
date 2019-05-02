using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.ActionBuilder.Nodes {
    [CustomNodeEditor(typeof(OperationNode))]
    public class OperationNodeEditor : NodeEditor {
        public override void OnBodyGUI() {
                OperationNode node = target as OperationNode;
                // SimpleGraph graph = node.graph;

                NodeEditorGUILayout.PortField(node.GetInputPort("a"));
                node.operationType = (OperationType)GUILayout.SelectionGrid((int)node.operationType, new string[]{"+", "-", "*", "/" }, 4);
                NodeEditorGUILayout.PortField(node.GetInputPort("b"));
                NodeEditorGUILayout.PortField(node.GetOutputPort("result"));


                // foreach (var port in node.Ports) {
                //     NodeEditorGUILayout.PortField(port);
                // }
            }
    }
}