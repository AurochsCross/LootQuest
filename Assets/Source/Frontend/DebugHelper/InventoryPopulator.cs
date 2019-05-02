using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Frontend.DebugHelper
{
    public class InventoryPopulator : MonoBehaviour
    {
        public Inventory.ItemRegistry ItemRegistry;
        public Models.Items.ArmorItem[] armorItems;
        public Models.Items.ArmorItem[] equipedItems;

        void Start() {
            Populate();
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.C)) {
                
            }
        }

        private void Populate() {
            var master = gameObject.GetComponent<Entity.EntityMaster>();
            LootQuest.Logic.Entity.Commanders.EquipmentCommander equipmentCommander = gameObject.GetComponent<Entity.EntityMaster>().Master.EquipmentCommander;
            armorItems.ToList().ForEach(x =>  { 
                equipmentCommander.AddItemToInventory(x.GeneratedItem); 
                ItemRegistry.AddItem(x);
            });
            
            equipedItems.ToList().ForEach( x => {
                equipmentCommander.AddItemToInventory(x.GeneratedItem); 
                equipmentCommander.Equip(x.GeneratedItem);
                ItemRegistry.AddItem(x);
            });
        }
    }
}