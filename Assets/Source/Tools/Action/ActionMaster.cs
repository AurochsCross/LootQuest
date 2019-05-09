using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;
using System.Linq;
using LootQuest.Models.Action;

namespace Tools.Action {
    [NodeTint("#88FF88")]
    public class ActionMaster : Node { 
        
        public Sprite ActionIcon;
        public string actionName;
        public string actionDescription; 

        [Output] public ActionMaster This;

        protected override void Init() {
            base.Init();
            if (this.GetInputPort("0") == null) {
                this.AddInstanceInput(typeof(LootQuest.Models.Action.ActionEffect), ConnectionType.Override, TypeConstraint.Inherited, "0");
            }
        }

        public override object GetValue(NodePort port) {
            if (port.fieldName == "This") 
                return this;
            else 
                return null;
        }

        public void AddNewPort() {
            this.AddInstanceInput(typeof(LootQuest.Models.Action.ActionEffect), ConnectionType.Override, TypeConstraint.Inherited, (int.Parse(Inputs.Last().fieldName) + 1).ToString());
        }

        public ActionEffect[] GetEffectNodes() {
            return Inputs.Select(x => (ActionEffect)x.Connection.node).ToArray();
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