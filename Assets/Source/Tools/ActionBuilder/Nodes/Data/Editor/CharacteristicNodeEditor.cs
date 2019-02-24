using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.ActionBuilder.Nodes {
    [CustomNodeEditor(typeof(Characteristic))]
    public class CharacteristicNodeEditor : NodeEditor {
        public override void OnBodyGUI() {
            Characteristic node = target as Characteristic;

            node.owner = (OwnerType)GUILayout.SelectionGrid((int)node.owner, new string[]{"Source", "Target" }, 2);
            node.characteristic = (CharacteristicType)EditorGUILayout.EnumPopup(node.characteristic);
            NodeEditorGUILayout.PortField(node.GetPort("result"));
        }
    }
}