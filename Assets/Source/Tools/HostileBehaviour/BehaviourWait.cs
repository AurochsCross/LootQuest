using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.HostileBehaviour.Nodes.Actions {
    [NodeTint("#9090FF")]
    public class BehaviourWait : Node { 

        public float Time = 0f;
        [Input] public Node Execute;
        [Output] public Node Next;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "Next") {
                return this;
            }
            else return "None";
        }
    }
}