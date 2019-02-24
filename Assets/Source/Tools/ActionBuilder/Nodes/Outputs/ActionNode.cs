using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;
using System.Linq;


namespace Tools.ActionBuilder.Nodes {
    [NodeTint("#88FF88")]
    [CreateNodeMenu("Outputs/Action Output")]
    public class ActionNode : Node { 

        public string actionName;
        public string actionDescription; 

        protected override void Init() {
            base.Init();
            this.AddInstanceInput(typeof(ActionEffect), ConnectionType.Override, TypeConstraint.Inherited, "0");
        }

        public void AddNewPort() {
            this.AddInstanceInput(typeof(ActionEffect), ConnectionType.Override, TypeConstraint.Inherited, (int.Parse(Inputs.Last().fieldName) + 1).ToString());
        }

        public ActionEffectNode[] GetEffectNodes() {
            return Inputs.Select(x => (ActionEffectNode)x.Connection.node).ToArray();
        }
    }
}