using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemButton : MonoBehaviour
{
    public Button button;
    public Text text;
    private Models.Items.Item item;
    private Frontend.Inventory.Manager inventoryManager;


    // Start is called before the first frame update
    void Start() {
        button.onClick.AddListener(OnButtonClick);
    }
    public void SetManager(Frontend.Inventory.Manager inventoryManager) {
        this.inventoryManager = inventoryManager;
    }

    public void SetItem(Models.Items.Item item) {
        this.item = item;
        text.text = item.itemName;
    }


    public void OnButtonClick() {
        inventoryManager.EquipItem(item);
        Debug.Log(item.itemName + " selected");
    }

}
