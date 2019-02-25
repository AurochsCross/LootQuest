using System.Collections;
using System.Collections.Generic;
using Models.Items;
using System.Linq;

namespace Logic.Player.Commanders {
    public class EquipmentCommander {
        public List<Item> inventory { get; private set; } = new List<Item>();
        public Dictionary<ArmorType, ArmorItem> armor { get; private set; } = emptyArmor();

        public void Equip(ArmorItem item) {
            inventory.Remove(item);
            Unequip(item.type);
            armor[item.type] = item;
        }

        public void Unequip(ArmorType type) {
            if (armor[type] != null) {
                inventory.Add(armor[type]);
                armor[type] = null;
            }
        }

        public void AddItemToInventory(ArmorItem item) {
            inventory.Add(item);
        }

        public Models.Common.Attributes GetAttributes() {
            Models.Common.Attributes result = new Models.Common.Attributes();
            armor.Where(x => x.Value?.attributes != null).ToList().ForEach(x => result += x.Value.attributes);
            return result;
        }

        public List<Models.Action.ActionRoot> GetActions() {
            return armor.Where(x => x.Value?.action != null).Select(x => x.Value.action).ToList();
        }
        
        private static Dictionary<ArmorType, ArmorItem> emptyArmor() { 
            return new Dictionary<ArmorType, ArmorItem> 
            {  
                {Models.Items.ArmorType.body, null},
                {Models.Items.ArmorType.helmet, null},
                {Models.Items.ArmorType.legs, null}
            };
        }
    }
}