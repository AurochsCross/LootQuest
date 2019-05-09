using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;
using System.Linq;
using LootQuest.Models.Action;

namespace Tools.Action {
    [NodeTint("#88FF88")]
    public class ActionEffect : Node { 
        public int id = 0;
        [Input] public string hitCondition;
        [Output] public string didHit;
        [Input] public string valueCalculation;

        public float Delay = 0f;
        [Input] public ActionVisualEffect WindupEffects;
        [Input] public ActionVisualEffect Effects;
        [Input] public Aura.AuraMaster Aura;
        [Output] public string valueCalculationRaw;
        [Output] public string calculatedValue;
        public EffectType type = EffectType.Damage;
        public EffectSubject subject = EffectSubject.Source;
        public int typeIndex = 0; // 0 - Damage, 1 - Heal

        [Output] public LootQuest.Models.Action.ActionEffect output;


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
                return new LootQuest.Models.Action.ActionEffect(id, hitConditionValue, valueCalculationValue, type, subject, Delay);
            else if (port.fieldName == "calculatedValue") 
                return String.Format("[{0}:calculatedValue]", id);
            else if (port.fieldName == "didHit") 
                return String.Format("[{0}:didHit]", id);
            else if (port.fieldName == "valueCalculationRaw")
                return valueCalculationValue;
            else 
                return "";
        }

        public LootQuest.Models.Action.ActionEffect GetActionEffect() {
            var typeValue = GetInputValue<EffectType>("type");
            string hitConditionValue = string.IsNullOrWhiteSpace(GetInputValue<string>("hitCondition")) ? hitCondition : GetInputValue<string>("hitCondition");
            if(type != EffectType.Aura) {
                string valueCalculationValue = string.IsNullOrWhiteSpace(GetInputValue<string>("valueCalculation")) ? valueCalculation : GetInputValue<string>("valueCalculation");

                return new LootQuest.Models.Action.ActionEffect(id, hitConditionValue, valueCalculationValue, type, subject, Delay);
            } else {
                return new LootQuest.Models.Action.ActionEffect(id, hitConditionValue, (GetInputValue("Aura", Aura).graph as Tools.Aura.AuraGraph).ConvertToModel(), subject, Delay);
            }
        }

        public List<ActionVisualEffect> GetWindupEffects() {
            return this.GetInputPort("WindupEffects").GetConnections().Select(x => x.node as ActionVisualEffect).ToList();
        }

        public List<ActionVisualEffect> GetEffects() {
            return this.GetInputPort("Effects").GetConnections().Select(x => x.node as ActionVisualEffect).ToList();
        }

    }
}