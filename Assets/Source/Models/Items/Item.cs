using System;

namespace Models.Items {
    class Item {
         
        public String name { get; private set; }
        public Logic.Common.Attributes attributes { get; private set; }

        public Models.Action.ActionRoot action { get; private set; }

        public Item(string name) {
            this.name = name;
        }
    }
}