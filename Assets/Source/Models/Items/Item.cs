using System;
using UnityEngine;

namespace Models.Items {
    public class Item: ScriptableObject {
         
        public String itemName;
        public Models.Common.Attributes attributes = new Models.Common.Attributes();

        public Tools.ActionBuilder.AbilityGraph actionGraph;
        public Models.Action.ActionRoot action {
            get {
                if (actionCache == null) {
                    actionCache = actionGraph == null ? null : actionGraph.GetAction();
                }
                return actionCache;
            }
        }

        private Models.Action.ActionRoot actionCache;

        public Item(string name) {
            this.itemName = name;
        }
    }
}