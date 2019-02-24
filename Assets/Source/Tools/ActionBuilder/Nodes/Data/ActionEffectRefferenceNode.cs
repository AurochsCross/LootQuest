using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace Tools.ActionBuilder.Nodes {
	[CreateNodeMenu("Data/Effect Refference")]
	public class ActionEffectRefferenceNode : Node {
		public int ActionEffectIndex;
		public ActionEffectNode refferencedNode;

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
			var actionNode = graph.nodes.Where( x => x.GetType() == typeof(ActionNode)).First();
			ActionEffectIndex = index;

			refferencedNode = (ActionEffectNode)actionNode.GetPort(ActionEffectIndex.ToString()).Connection.node;
		}
	}
}