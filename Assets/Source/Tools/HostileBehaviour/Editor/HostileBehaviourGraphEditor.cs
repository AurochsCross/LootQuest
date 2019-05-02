using UnityEngine;
using UnityEditor;
using XNode;
using XNodeEditor;

namespace Tools.HostileBehaviour {
    [CustomNodeGraphEditor(typeof(HostileBehaviourGraph))]
    public class HostileBehaviourGraphEditor : XNodeEditor.NodeGraphEditor {
        
        public override void OnGUI() {
            HostileBehaviourGraph graph = target as HostileBehaviourGraph;
            if (GUILayout.Button("Test")) {
                graph.GetActions();
            }
        }
    }
}