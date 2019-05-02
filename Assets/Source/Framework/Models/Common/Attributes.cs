using System;

namespace LootQuest.Models.Common {
    [Serializable]
    public class Attributes {
        public int strength { get; private set; }
        public int dexterity { get; private set; }
        public int intelligence { get; private set; }
        public int? Hp { get; private set; }

        public Attributes() {
            this.strength = 0;
            this.dexterity = 0;
            this.intelligence = 0;
            Hp = null;
        }
        public Attributes(int strength, int dexterity, int intelligence, int? hp = null) {
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
            this.Hp = hp;
        }

        public static Attributes operator +(Attributes first, Attributes second) {
            return new Attributes(first.strength + second.strength, first.dexterity + second.dexterity, first.intelligence + second.intelligence, first.Hp ?? 0 + second.Hp ?? 0);
        }
    }
}