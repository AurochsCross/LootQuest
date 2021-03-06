using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;
using System.Linq;
using LootQuest.Models.Action;

namespace Tools.ActionBuilder.Nodes {
    [NodeTint("#88FF88")]
    [CreateNodeMenu("Outputs/Action Output")]
    public class ActionNode : Node { 
        
        public Sprite ActionIcon;
        public string actionName;
        public string actionDescription; 

        protected override void Init() {
            base.Init();
            if (this.GetInputPort("0") == null) {
                this.AddInstanceInput(typeof(ActionEffect), ConnectionType.Override, TypeConstraint.Inherited, "0");
            }
        }

        public void AddNewPort() {
            this.AddInstanceInput(typeof(ActionEffect), ConnectionType.Override, TypeConstraint.Inherited, (int.Parse(Inputs.Last().fieldName) + 1).ToString());
        }

        public ActionEffectNode[] GetEffectNodes() {
            return Inputs.Select(x => (ActionEffectNode)x.Connection.node).ToArray();
        }

        public ActionRoot GetAction() {
            ActionRoot action = new ActionRoot();
            action.name = actionName;
            action.description = actionDescription;
            action.id = this.graph.GetInstanceID();
            action.effects = GetEffectNodes().Select( x => x.GetActionEffect() ).ToArray();
            action.AddRepresentable(this);
            return action;
        }
    }
}