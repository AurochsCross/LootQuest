using UnityEngine;

namespace Models.Items {
    [CreateAssetMenu(fileName = "Data", menuName = "Tools/Inventory/Armor", order = 1)]
    public class ArmorItem : Item 
    {
        public ArmorType type;
        public ArmorItem(string name, ArmorType type) : base(name) {
            this.type = type;
        }
    }
}