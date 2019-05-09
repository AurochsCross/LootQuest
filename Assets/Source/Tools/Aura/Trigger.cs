using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura {
    [NodeWidth(250)]
    public class Trigger : Node {
        [Input] public AuraMaster Master;
        public LootQuest.Models.Action.Aura.TriggerType Type;
        [Output] public Trigger OnTrigger;
        [Output] public string Value;
        public float RepeatTime;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "OnTrigger") 
                return this;
            else if (port.fieldName == "Value")
                return "[trigger:value]";
            else 
                return null;
        }

        public LootQuest.Models.Action.ActionRoot GetActionRoot() {

            var port = GetOutputPort("OnTrigger");

            if (port.ConnectionCount > 0) {
                var actionUseNodeActionPort = (port.GetConnection(0).node as Common.BehaviourActionUse).GetInputPort("Action");
                if (actionUseNodeActionPort.ConnectionCount > 0) {
                    var actionNode = actionUseNodeActionPort.GetConnection(0).GetOutputValue() as Action.ActionMaster;
                    return actionNode.GetAction();
                }
            }



            return null;
        }

    }
}