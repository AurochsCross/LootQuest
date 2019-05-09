using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.HostileBehaviour.Nodes {
    [NodeTint("#FF5050")]
    public class BehaviourEnd : Node { 
        [Input] public Node Execute;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "Next") {
                return this;
            }
            else return "None";
        }
    }
}