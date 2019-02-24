using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.ActionBuilder.Nodes {
    public enum OperationType { Add, Subtract, Multiply, Divide }

    [CreateNodeMenu("Operations/Math Operation")]
    public class OperationNode : Node { 
        [Input] public string first;
        [Input] public string second;
        public OperationType operationType = OperationType.Add;
        [Output] public string result;


        public override object GetValue(NodePort port) {
            string aValue = GetInputValue<string>("first");
            string bValue = GetInputValue<string>("second");

            if (port.fieldName == "result") {
                switch (operationType) {
                    default: case OperationType.Add: return string.Format("({0} + {1})", aValue, bValue);
                    case OperationType.Subtract: return string.Format("({0} - {1})", aValue, bValue);
                    case OperationType.Multiply: return string.Format("({0} * {1})", aValue, bValue);
                    case OperationType.Divide: return string.Format("({0} / {1})", aValue, bValue);
                }
            }
            else return "None";
        }
    }
}