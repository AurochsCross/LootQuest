using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;
using UnityEditor;

namespace Tools.ActionBuilder.Nodes {
    [CustomNodeEditor(typeof(ActionNode))]
    public class ActionNodeEditor : NodeEditor {
        public override void OnBodyGUI() {

                ActionNode node = target as ActionNode;
                
                // Action description

                GUILayout.Label("Description");

                GUILayout.BeginHorizontal();
                GUILayout.Label("Icon: ", GUILayout.ExpandWidth(false));
                node.ActionIcon = EditorGUILayout.ObjectField(node.ActionIcon, typeof(Sprite)) as Sprite;
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Name: ", GUILayout.ExpandWidth(false));
                node.actionName = GUILayout.TextField(node.actionName);
                GUILayout.EndHorizontal();

                GUILayout.Label("Description: ");
                node.actionDescription = GUILayout.TextArea(node.actionDescription, GUILayout.Height(60));

                // Effect 
                
                if (GUILayout.Button("Ganerate Json")) {
                    var result = AbilityJsonExporter.GenerateActionJson(node);
                    Debug.Log(result);
                    var model = AbilityJsonExporter.GenerateActionFromJson(result);
                    Debug.Log(model.name);
                }

                GUILayout.BeginHorizontal();

                

                GUILayout.Label("Effects:");
                GUILayout.Label("");

                if (GUILayout.Button("-")) {
                    if (node.Ports.Count() > 1)
                    node.RemoveInstancePort(node.Ports.Last());
                }

                if (GUILayout.Button("+")) {
                    node.AddNewPort();
                }

                GUILayout.EndHorizontal();

                foreach (var port in node.Ports) {
                    NodeEditorGUILayout.PortField(port);
                }

            }
    }
}