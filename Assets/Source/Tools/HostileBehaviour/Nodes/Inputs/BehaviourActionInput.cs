using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.HostileBehaviour.Nodes.Inputs {
    [NodeTint("#50FF50")]
    [CreateNodeMenu("Behaviour/Input/Action (from action graph)")]
    public class BehaviourActionInput : Node { 

        public Tools.ActionBuilder.AbilityGraph Graph;
        [Output] public ActionBuilder.Nodes.ActionNode Action;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "Action" && Graph != null) {
                return Graph.MainActionNode;
            }
            else 
                return null;
        }
    }
}