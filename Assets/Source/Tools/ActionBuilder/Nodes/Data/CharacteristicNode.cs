using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public enum OwnerType {
        Source,
        Target
    };

    public enum CharacteristicType {
        Strength,
        Dexterity,
        Intelligence,
        MaxHp,
        Hp
    };

namespace Tools.ActionBuilder.Nodes {
    

    [NodeTint("#AAFFFF")]
    [CreateNodeMenu("Data/Characteristic")]
    public class CharacteristicNode : Node { 
        public OwnerType owner;
        public CharacteristicType characteristic;
        [Output] public string result;

        public override object GetValue(NodePort port) {
            if (port.fieldName == "result") 
                return string.Format("[{0}:{1}]", OwnerToString(owner), CharacteristicToString(characteristic));
            else 
                return null;
        }

        private string OwnerToString(OwnerType owner) {
            switch (owner) {
                case OwnerType.Source: return "s";
                case OwnerType.Target: return "t";
            }

            return "";
        }

        private string CharacteristicToString(CharacteristicType characteristic) {
            switch (characteristic) {
                case CharacteristicType.Dexterity: return "dexterity";
                case CharacteristicType.Intelligence: return "intelligence";
                case CharacteristicType.Strength: return "strength";
                case CharacteristicType.MaxHp: return "maxHp";
                case CharacteristicType.Hp: return "hp";
            }

            return "";
        }
    }
}