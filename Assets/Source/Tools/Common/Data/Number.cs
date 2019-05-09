using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.Common.Data {
    [NodeTint("#AADDFF")]
    public class Number : Node { 
        public string number;
        [Output] public string result;
        public override object GetValue(NodePort port) {
            if (port.fieldName == "result") 
                return number;
            else return "None";
        }
    }
}