using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.ActionBuilder.Nodes {
    public enum ConditionType { moreThan, lessThan, equals };

    [CreateNodeMenu("Operations/Condition")]
    public class ConditionNode : Node { 
        [Input] public string first;
        [Input] public string second;
        public ConditionType condition;
        [Output] public string result;

        public override object GetValue(NodePort port) {
            string firstValue = string.IsNullOrWhiteSpace(GetInputValue<string>("first")) ? first : GetInputValue<string>("first");
            string secondValue = string.IsNullOrWhiteSpace(GetInputValue<string>("second")) ? second : GetInputValue<string>("second");

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