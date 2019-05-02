using System.Collections;
using System.Collections.Generic;
using LootQuest.Models.Items;
using System.Linq;

namespace LootQuest.Logic.Entity.Commanders {
    public class EquipmentCommander {
        public Master Master { get; private set; }
        public List<Item> Inventory { get; private set; } = new List<Item>();
        public Dictionary<ArmorType, ArmorItem> Armor { get; private set; } = emptyArmor();
        public List<Item> OtherEquipment { get; private set; } = new List<Item>();

        public EquipmentCommander(Master master) {
            this.Master = master;
        }

        public void Equip(ArmorItem item) {
            if (item.type == ArmorType.unlisted) {
                OtherEquipment.Add(item);
                return;
            }

            Inventory.Remove(item);
            Unequip(item.type);
            Armor[item.type] = item;
        }

        public void Unequip(ArmorType type) {
            if (Armor[type] != null) {
                Inventory.Add(Armor[type]);
                Armor[type] = null;
            }
        }

        public void AddItemToInventory(Item item) {
            Inventory.Add(item);
        }

        public LootQuest.Models.Common.Attributes GetAttributes() {
            LootQuest.Models.Common.Attributes result = new LootQuest.Models.Common.Attributes();
            Armor.Where(x => x.Value?.attributes != null).ToList().ForEach(x => result += x.Value.attributes);
            return result;
        }

        public List<LootQuest.Models.Action.ActionRoot> GetActions() {
            var result = Armor.Where(x => x.Value?.action != null).Select(x => x.Value.action).ToList();
            if (OtherEquipment.Count > 0) {
                result.AddRange(OtherEquipment.Select(x => x.action));
            }
            
            return result;
        }
        
        private static Dictionary<ArmorType, ArmorItem> emptyArmor() { 
            return new Dictionary<ArmorType, ArmorItem> 
            {  
                {LootQuest.Models.Items.ArmorType.body, null},
                {LootQuest.Models.Items.ArmorType.helmet, null},
                {LootQuest.Models.Items.ArmorType.legs, null}
            };
        }
    }
}