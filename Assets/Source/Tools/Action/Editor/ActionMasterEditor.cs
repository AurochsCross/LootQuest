using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;
using UnityEditor;

namespace Tools.Action.Editor {
    [CustomNodeEditor(typeof(ActionMaster))]
    public class ActionMasterEditor : NodeEditor {
        public override void OnBodyGUI() {

                ActionMaster node = target as ActionMaster;
                
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


                GUILayout.BeginHorizontal();

                

                GUILayout.Label("Effects:");
                GUILayout.Label("");

                if (GUILayout.Button("-")) {
                    if (node.Ports.Count() > 2)
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