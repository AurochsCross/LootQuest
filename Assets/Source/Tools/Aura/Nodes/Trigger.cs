using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Aura.Nodes {
    [NodeWidth(250)]
    public class Trigger : Node {
        [Input] public AuraMasterNode Master;
        public LootQuest.Models.Action.Aura.TriggerType Type;
        [Output] public Trigger OnTrigger;
        [Output] public string Value;

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
                var actionUseNodeActionPort = (port.GetConnection(0).node as HostileBehaviour.Nodes.Actions.BehaviourActionUse).GetInputPort("Action");
                if (actionUseNodeActionPort.ConnectionCount > 0) {
                    var actionNode = actionUseNodeActionPort.GetConnection(0).GetOutputValue() as ActionBuilder.Nodes.ActionNode;
                    return actionNode.GetAction();
                }
            }



            return null;
        }

    }
}