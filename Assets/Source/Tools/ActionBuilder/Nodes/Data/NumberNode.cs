using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.ActionBuilder.Nodes {
    [NodeTint("#AADDFF")]
    [CreateNodeMenu("Data/Number")]
    public class NumberNode : Node { 
        public string number;
        [Output] public string result;
        public override object GetValue(NodePort port) {
            if (port.fieldName == "result") 
                return number;
            else return "None";
        }
    }
}