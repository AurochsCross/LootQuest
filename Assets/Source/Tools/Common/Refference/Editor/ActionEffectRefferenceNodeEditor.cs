using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Common.Refference.Editor {
    [CustomNodeEditor(typeof(ActionEffectRefference))]
    public class ActionEffectRefferenceEditor : NodeEditor {
        public override void OnBodyGUI() {
            ActionEffectRefference node = target as ActionEffectRefference;

            int[] indexes = getAvailableIndexes(node);
            node.SetEffect(EditorGUILayout.IntPopup(node.ActionEffectIndex, indexes.Select(x => x.ToString()).ToArray(), indexes));

            foreach (var port in node.Outputs) {
                NodeEditorGUILayout.PortField(port);
            }

            //base.OnBodyGUI();
        }

        private int[] getAvailableIndexes(ActionEffectRefference node) {
            var actionNode = node.graph.nodes.Where( x => x.GetType() == typeof(Tools.Action.ActionMaster)).First();

            List<int> result = new List<int>();
            foreach (var input in actionNode.Inputs) {
                if (input.IsConnected) {
                    result.Add(int.Parse(input.fieldName));
                }
            }

            return result.ToArray();
        }
    }
}