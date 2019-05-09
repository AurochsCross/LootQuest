using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.HostileBehaviour.Nodes.Inputs {
    [NodeTint("#50FF50")]
    public class BehaviourActionInput : Node { 

        public Tools.Action.ActionGraph Graph;
        [Output] public Action.ActionMaster Action;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "Action" && Graph != null) {
                return Graph.MainActionNode;
            }
            else 
                return null;
        }
    }
}