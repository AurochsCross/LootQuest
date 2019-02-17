using System;

namespace Logic.Items {
    class Item {
         
        public String name { get; private set; }
        public int? strength { get; private set; }
        public int? dexterity { get; private set; }
        public int? intelligence { get; private set; }

        public Item(string name) {
            this.name = name;
        }
    }
}