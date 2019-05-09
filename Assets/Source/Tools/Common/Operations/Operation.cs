using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.Common.Operations {
    public enum OperationType { Add, Subtract, Multiply, Divide }

    public class Operation : Node { 
        [Input] public string a;
        [Input] public string b;
        public OperationType operationType = OperationType.Add;
        [Output] public string result;


        public override object GetValue(NodePort port) {
            string aValue = GetInputValue<string>("a");
            string bValue = GetInputValue<string>("b");

            foreach (var inputPort in Ports) {
                Debug.Log(inputPort.fieldName + " connections: " + inputPort.ConnectionCount);
                foreach (var connection in inputPort.GetConnections()) {
                    Debug.Log("Connection: " + connection.fieldName);
                }
            }

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