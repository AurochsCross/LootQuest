namespace Logic.Common {
    class Attributes {
        public int strength { get; private set; }
        public int dexterity { get; private set; }
        public int intelligence { get; private set; }

        public Attributes(int strength, int dexterity, int intelligence) {
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
        }

        public static Attributes operator +(Attributes first, Attributes second) {
            return new Attributes(first.strength + second.strength, first.dexterity + second.dexterity, first.intelligence + second.intelligence);
        }
    }
}