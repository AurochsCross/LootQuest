using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura.Editor {
    [CustomNodeEditor(typeof(AuraMaster))]
    public class AuraMasterEditor : NodeEditor {
        public override void OnBodyGUI() {
            AuraMaster node = target as AuraMaster;
            
            base.OnBodyGUI();
        }

        public override void OnHeaderGUI() {
            AuraMaster node = target as AuraMaster;

            bool isMaster = ((node.graph as AuraGraph).MasterNode == node);

            var guiColor = GUI.color;
            if (isMaster)
                GUI.color = Color.green;

            GUILayout.Label("Aura Master Node" + (isMaster ? " (Main)" : ""), NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));

            GUI.color = guiColor;
        }
        
        
    }
}