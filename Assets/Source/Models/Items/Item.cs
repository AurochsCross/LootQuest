using System;
using UnityEngine;

namespace Models.Items {
    public class Item: ScriptableObject {
         
        public String itemName;
        public Models.Common.Attributes attributes = new Models.Common.Attributes();
        public Models.Action.ActionRoot action;

        private Models.Action.ActionRoot actionCache;

        public Item(string name) {
            this.name = name;
        }
    }
}