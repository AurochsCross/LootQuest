using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.ActionBuilder.Nodes {
    public enum ConditionType { moreThan, lessThan, equals };

    [CreateNodeMenu("Operations/Condition")]
    public class ConditionNode : Node { 
        [Input(backingValue = ShowBackingValue.Always, connectionType = ConnectionType.Override)] public string a;
        [Input(connectionType = ConnectionType.Override)] public string b;
        public ConditionType condition;
        [Output] public string result;

        public override object GetValue(NodePort port) {
            string firstValue = string.IsNullOrWhiteSpace(GetInputValue<string>("a")) ? a : GetInputValue<string>("a");
            string secondValue = string.IsNullOrWhiteSpace(GetInputValue<string>("b")) ? b : GetInputValue<string>("b");

            string equationSign = "";
            switch(condition) {
                case ConditionType.moreThan: equationSign = ">";
                break;
                case ConditionType.lessThan: equationSign = "<";
                break;
                case ConditionType.equals: equationSign = "=";
                break;
            }

            if (port.fieldName == "result") {
                return string.Format("({0} {1} {2})", firstValue, equationSign, secondValue);
            }
            else 
                return "";
        }
    }
}