
namespace LootQuest.Models.Items {
    public class ArmorItem : Item 
    {
        public ArmorType type;
        public ArmorItem(int id, string name, ArmorType type) : base(id, name) {
            this.type = type;
        }
    }
}