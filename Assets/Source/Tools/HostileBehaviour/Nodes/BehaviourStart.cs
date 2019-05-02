using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.HostileBehaviour.Nodes {
    [NodeTint("#50FF50")]
    [CreateNodeMenu("Behaviour/Start")]
    public class BehaviourStart : Node { 
        [Output] public Node Next;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "Next") {
                return this;
            }
            else return "None";
        }
    }
}