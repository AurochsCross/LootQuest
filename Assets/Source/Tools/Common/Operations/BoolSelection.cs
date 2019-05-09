using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

namespace Tools.Common.Operations {
    public class BoolSelection : Node { 
        [Input] public string condition;
        [Input] public string success;
        [Input] public string fail;
        [Output] public string result;

        public override object GetValue(NodePort port) {
            string conditionValue = string.IsNullOrWhiteSpace(GetInputValue<string>("condition")) ? condition : GetInputValue<string>("condition");
            string successValue = string.IsNullOrWhiteSpace(GetInputValue<string>("success")) ? success : GetInputValue<string>("success");
            string failValue = string.IsNullOrWhiteSpace(GetInputValue<string>("fail")) ? fail : GetInputValue<string>("fail");

            if (port.fieldName == "result") {
                return string.Format("(if {0}, {1}, {2})", conditionValue, successValue, failValue);
            }
            else return "None";
        }
    }
}