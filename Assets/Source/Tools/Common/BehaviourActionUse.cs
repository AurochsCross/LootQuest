using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.Common {
    [NodeTint("#50FFFF")]
    public class BehaviourActionUse : Node { 

        [Input] public Tools.Action.ActionMaster Action;
        [Input] public Node Execute;
        [Output] public Node Next;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "Next") {
                return this;
            } else if (port.fieldName == "Action") {
                return GetInputValue<Tools.Action.ActionMaster>("Action") == null ? Action : GetInputValue<Tools.Action.ActionMaster>("Action");
            }
            else return "None";
        }

        public Tools.Action.ActionMaster GetActionNode() {
             return GetInputValue<Tools.Action.ActionMaster>("Action") == null ? Action : GetInputValue<Tools.Action.ActionMaster>("Action");
        }
    }
}