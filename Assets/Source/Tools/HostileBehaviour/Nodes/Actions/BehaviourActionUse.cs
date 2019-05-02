using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.HostileBehaviour.Nodes.Actions {
    [NodeTint("#50FFFF")]
    [CreateNodeMenu("Behaviour/Use Action")]
    public class BehaviourActionUse : Node { 

        [Input] public Tools.ActionBuilder.Nodes.ActionNode Action;
        [Input] public Node Execute;
        [Output] public Node Next;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "Next") {
                return this;
            } else if (port.fieldName == "Action") {
                return GetInputValue<Tools.ActionBuilder.Nodes.ActionNode>("Action") == null ? Action : GetInputValue<Tools.ActionBuilder.Nodes.ActionNode>("Action");
            }
            else return "None";
        }

        public Tools.ActionBuilder.Nodes.ActionNode GetActionNode() {
             return GetInputValue<Tools.ActionBuilder.Nodes.ActionNode>("Action") == null ? Action : GetInputValue<Tools.ActionBuilder.Nodes.ActionNode>("Action");
        }
    }
}