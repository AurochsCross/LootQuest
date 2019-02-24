using System.Collections;
using System.Collections.Generic;
using Models.Items;

namespace Logic.Player.Commanders {
    class EquipmentCommander {
        public List<Item> inventory { get; private set; } = new List<Item>();
        Dictionary<ArmorType, ArmorItem> armor = emptyArmor();

        public void Equip(ArmorItem item) {
            inventory.Remove(item);
            inventory.Add(armor[item.type]);
            armor[item.type] = item;
        }

        public Common.Attributes GetAttributes() {
            Common.Attributes result = new Common.Attributes(0, 0, 0);

            foreach (var armorPiece in armor) {
                if (armorPiece.Value.attributes != null) {
                    result += armorPiece.Value.attributes;
                }
            }

            return result;
        }

        public List<Models.Action.ActionRoot> GetActions() {
            List<Models.Action.ActionRoot> result = new List<Models.Action.ActionRoot>();

            foreach (var armorPiece in armor) {
                if (armorPiece.Value.action != null) {
                    result.Add(armorPiece.Value.action);
                }
            }

            return result;
        }
        
        private static Dictionary<ArmorType, ArmorItem> emptyArmor() {
            Dictionary<ArmorType, ArmorItem> armor = new Dictionary<ArmorType, ArmorItem>();
            
            armor.Add(Models.Items.ArmorType.body, null);
            armor.Add(Models.Items.ArmorType.helmet, null);
            armor.Add(Models.Items.ArmorType.legs, null);

            return armor;
        }
    }
}