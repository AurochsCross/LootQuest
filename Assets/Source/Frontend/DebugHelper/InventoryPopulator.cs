using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Frontend.DebugHelper
{
    public class InventoryPopulator : MonoBehaviour
    {
        public Models.Items.ArmorItem[] armorItems;

        // Start is called before the first frame update
        void Start()
        {
            Logic.Player.Commanders.EquipmentCommander equipmentCommander = Frontend.Master.main.playerMaster.equipmentCommander;
            armorItems.ToList().ForEach(x => equipmentCommander.AddItemToInventory(x));
            equipmentCommander.inventory.ForEach(x => Debug.Log(x.itemName));

            //equipmentCommander.Equip((Models.Items.ArmorItem)equipmentCommander.inventory.First());

            Debug.Log("Actions:");
            equipmentCommander.GetActions().ForEach(x => Debug.Log(x.name));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}