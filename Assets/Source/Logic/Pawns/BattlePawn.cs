using System.Collections;
using System.Collections.Generic;

namespace Logic.Pawns {
    class BattlePawn {
        public Common.Attributes baseAttributes { get; private set; }
        public List<Actions.Action> actions { get; private set; }

        public int maxHitPoints { get; private set; }
        public int currentHitPoints { get; private set; }

        public BattlePawn(Common.Attributes baseAttributes, List<Actions.Action> actions) {
            this.baseAttributes = baseAttributes;
            this.actions = actions;
            this.maxHitPoints = baseAttributes.strength;
            this.currentHitPoints = baseAttributes.strength;
        }

        public void TakeDamage(int damage) {
            currentHitPoints -= damage;
            if (currentHitPoints < 0) {
                currentHitPoints = 0;
            }
        }

        public void TakeHealing(int healing) {
            currentHitPoints += healing;
            if (currentHitPoints > maxHitPoints) {
                currentHitPoints = maxHitPoints;
            }
        }
    }
}