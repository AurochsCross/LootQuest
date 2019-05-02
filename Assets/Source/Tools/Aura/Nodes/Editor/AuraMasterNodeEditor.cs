using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura.Nodes {
    [CustomNodeEditor(typeof(AuraMasterNode))]
    public class AuraMasterNodeEditor : NodeEditor {
        public override void OnBodyGUI() {
            AuraMasterNode node = target as AuraMasterNode;
            
            base.OnBodyGUI();
        }

        public override void OnHeaderGUI() {
            AuraMasterNode node = target as AuraMasterNode;

            bool isMaster = ((node.graph as AuraGraph).MasterNode == node);

            var guiColor = GUI.color;
            if (isMaster)
                GUI.color = Color.green;

            GUILayout.Label("Aura Master Node" + (isMaster ? " (Main)" : ""), NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));

            GUI.color = guiColor;
        }
        
        
    }
}