using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.Common.Refference {
	public class ActionEffectRefference : Node {
		public int ActionEffectIndex;
		public Action.ActionEffect refferencedNode;

		[Output] public string didHit;
		[Output] public string calculation;
		[Output] public string calculatedValue;

		// Use this for initialization
		protected override void Init() {
			base.Init();
			name = "Effect Refference";
		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port) {
			if (port.fieldName == "didHit") {
				return refferencedNode.GetValue(refferencedNode.GetPort("didHit"));
			} else if (port.fieldName == "calculation") {
				return refferencedNode.GetValue(refferencedNode.GetPort("valueCalculationRaw"));
			} else if (port.fieldName == "calculatedValue") {
				return refferencedNode.GetValue(refferencedNode.GetPort("calculatedValue"));
			}
			return null; // Replace this
		}

		public void SetEffect(int index) {
			var actionNode = graph.nodes.Where( x => x.GetType() == typeof(Action.ActionMaster)).First();
			ActionEffectIndex = index;

			refferencedNode = (Action.ActionEffect)actionNode.GetPort(ActionEffectIndex.ToString()).Connection.node;
		}
	}
}