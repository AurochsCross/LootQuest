using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.ActionBuilder.Nodes {
    [CustomNodeEditor(typeof(CharacteristicNode))]
    public class CharacteristicNodeEditor : NodeEditor {
        public override void OnBodyGUI() {
            CharacteristicNode node = target as CharacteristicNode;

            node.owner = (OwnerType)GUILayout.SelectionGrid((int)node.owner, new string[]{"Source", "Target" }, 2);
            node.characteristic = (CharacteristicType)EditorGUILayout.EnumPopup(node.characteristic);
            NodeEditorGUILayout.PortField(node.GetPort("result"));
        }
    }
}