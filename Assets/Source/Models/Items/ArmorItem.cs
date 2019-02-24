namespace Models.Items {
    class ArmorItem : Item
    {
        public ArmorType type { get; private set; }
        public ArmorItem(string name, ArmorType type) : base(name) {
            this.type = type;
        }
    }
}