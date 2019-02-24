using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;
using System.Linq;

namespace Tools.ActionBuilder.Nodes {
    [NodeTint("#88FF88")]
    [CreateNodeMenu("Outputs/Action Effect")]
    public class ActionEffectNode : Node { 
        public int id = 0;
        [Input] public string hitCondition;
        [Output] public string didHit;
        [Input] public string valueCalculation;
        [Output] public string valueCalculationRaw;
        [Output] public string calculatedValue;
        public ActionType type = ActionType.Damage;
        public int typeIndex = 0; // 0 - Damage, 1 - Heal

        [Output] public ActionEffect output;


        public override void OnCreateConnection(NodePort from, NodePort to) {
            if (from.fieldName == "output") {
                id = int.Parse(to.fieldName);
            }
        }

        public override void OnRemoveConnection(NodePort port) {
            if (port.fieldName == "output") {
                id = -1;
            }
        }

        public override object GetValue(NodePort port) {
            string hitConditionValue = string.IsNullOrWhiteSpace(GetInputValue<string>("hitCondition")) ? hitCondition : GetInputValue<string>("hitCondition");
            string valueCalculationValue = string.IsNullOrWhiteSpace(GetInputValue<string>("valueCalculation")) ? valueCalculation : GetInputValue<string>("valueCalculation");
            
            if (port.fieldName == "output")
                return new ActionEffect(id, hitConditionValue, valueCalculationValue, type);
            else if (port.fieldName == "calculatedValue") 
                return String.Format("[{0}:calculatedValue]", id);
            else if (port.fieldName == "didHit") 
                return String.Format("[{0}:didHit]", id);
            else if (port.fieldName == "valueCalculationRaw")
                return valueCalculationValue;
            else 
                return "";
        }

        public ActionEffect GetActionEffect() {
            string hitConditionValue = string.IsNullOrWhiteSpace(GetInputValue<string>("hitCondition")) ? hitCondition : GetInputValue<string>("hitCondition");
            string valueCalculationValue = string.IsNullOrWhiteSpace(GetInputValue<string>("valueCalculation")) ? valueCalculation : GetInputValue<string>("valueCalculation");
            
            return new ActionEffect(id, hitConditionValue, valueCalculationValue, type);
        }

    }
}