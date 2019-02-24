using System;

namespace Logic.Items {
    class Item {
         
        public String name { get; private set; }
        public Common.Attributes attributes { get; private set; }

        public Actions.Action action { get; private set; }

        public Item(string name) {
            this.name = name;
        }
    }
}