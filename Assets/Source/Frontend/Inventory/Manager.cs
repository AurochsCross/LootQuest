using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Frontend.Inventory {
    public class Manager : MonoBehaviour
    {
        public GameObject inventoryPanel;
        public GameObject inventoryItemButtonTemplate;
        private Logic.Player.Commanders.EquipmentCommander equipmentCommander;

        public Button helmetButton;
        public Button torsoButton;
        public Button leggingButton;

        public GameObject inventoryUI;

        void Awake() {
        }

        void Start() {
            equipmentCommander = Frontend.Master.main.playerMaster.equipmentCommander;
            helmetButton.onClick.AddListener(() => UnequipItem(Models.Items.ArmorType.helmet));
            torsoButton.onClick.AddListener(() => UnequipItem(Models.Items.ArmorType.body));
            leggingButton.onClick.AddListener(() => UnequipItem(Models.Items.ArmorType.legs));
            UpdateInventory();
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.I)) {
                ToggleUI();
            }
        }

        private void ToggleUI() {
            inventoryUI.SetActive(!inventoryUI.active);
            if (inventoryUI.activeSelf) {
                UpdateInventory();
            }
        }

        public void EquipItem(Models.Items.Item item) {
            equipmentCommander.Equip((Models.Items.ArmorItem)item);
            UpdateInventory();
        }

        private void UnequipItem(Models.Items.ArmorType type) {
            equipmentCommander.Unequip(type);
            UpdateInventory();
        }

        private void UpdateInventory() {
            foreach (Transform child in inventoryPanel.transform) {
                Destroy(child.gameObject);
            }

            equipmentCommander.inventory.ForEach( x => AddItemToPanel(x));
            helmetButton.transform.GetChild(0).GetComponent<Text>().text = equipmentCommander.armor[Models.Items.ArmorType.helmet]?.name ?? "None";
            torsoButton.transform.GetChild(0).GetComponent<Text>().text = equipmentCommander.armor[Models.Items.ArmorType.body]?.name ?? "None";
            leggingButton.transform.GetChild(0).GetComponent<Text>().text = equipmentCommander.armor[Models.Items.ArmorType.legs]?.name ?? "None";
        }

        private void AddItemToPanel(Models.Items.Item item) {
            var button = Instantiate(inventoryItemButtonTemplate) as GameObject;
            button.transform.SetParent(inventoryPanel.transform);
            //button.transform.parent = inventoryPanel.transform;
            button.GetComponent<InventoryItemButton>().SetItem(item);
            button.GetComponent<InventoryItemButton>().SetManager(this);
        }
    }
}