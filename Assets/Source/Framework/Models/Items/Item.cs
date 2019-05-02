using System;

namespace LootQuest.Models.Items {
    public class Item: Representable {
        public int Id;
        public String itemName;
        public Models.Common.Attributes attributes = new Models.Common.Attributes();

        public Models.Action.ActionRoot action;

        public Item(int id, string name) {
            this.Id = id;
            this.itemName = name;
        }
    }
}