using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Common.Refference.Editor {
    [CustomNodeEditor(typeof(CharacteristicRefference))]
    public class CharacteristicRefferenceEditor : NodeEditor {
        public override void OnBodyGUI() {
            CharacteristicRefference node = target as CharacteristicRefference;

            node.owner = (OwnerType)GUILayout.SelectionGrid((int)node.owner, new string[]{"Source", "Target" }, 2);
            node.characteristic = (CharacteristicType)EditorGUILayout.EnumPopup(node.characteristic);
            NodeEditorGUILayout.PortField(node.GetPort("result"));
        }
    }
}