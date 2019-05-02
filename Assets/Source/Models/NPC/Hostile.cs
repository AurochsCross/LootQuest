using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models.NPC {
    [CreateAssetMenu(menuName = "Tools/Data/NPCs/Hostile")]
    public class Hostile : ScriptableObject
    {
        public string Name;
        public int MaxHp;
        public int Strength;
        public int Dexterity;
        public int Intelligence;
    }
}