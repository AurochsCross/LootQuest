using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Tools.Common.Refference {
    public class AuraRefference: Node {
        public Aura.AuraGraph Graph;
        [Output] public Aura.AuraMaster Aura;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "Aura" && Graph != null && Graph.MasterNode != null) {
                return Graph.MasterNode;
            }

            return null;
        }
    }
}