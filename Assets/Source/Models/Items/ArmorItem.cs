using System.Collections;
using System.Collections.Generic;
using LootQuest.Models.Items;
using UnityEngine;
using UnityEditor;

namespace Models.Items {
    public class ArmorItem : ScriptableObject
    {
        public int Id;
        public ArmorType type;
        public string itemName;
        public LootQuest.Models.Common.Attributes attributes { 
            get {
                return new LootQuest.Models.Common.Attributes(Strength, Dexterity, Intelligence);
            }
        }
        public Tools.ActionBuilder.AbilityGraph actionGraph;

        public int Strength = 0;
        public int Intelligence = 0;
        public int Dexterity = 0;

        public LootQuest.Models.Items.ArmorItem GeneratedItem {
            get {
                var item = new LootQuest.Models.Items.ArmorItem(Id, itemName, type);

                item.attributes = attributes;
                item.action = actionGraph?.GetAction();
                item.AddRepresentable(this);

                return item;
            }
        }
    }
}