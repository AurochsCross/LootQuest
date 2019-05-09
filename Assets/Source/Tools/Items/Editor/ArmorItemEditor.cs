using UnityEditor;
using UnityEngine;
using Models.Items;
using LootQuest.Models.Common;

namespace Tools.Items
{
    [System.Serializable]
    [CustomEditor(typeof(ArmorItem))]
    class ArmorItemEditor : Editor
    {

        [SerializeField]
        Tools.Action.ActionGraph actionGraph;

        public override void OnInspectorGUI()
        {
            EditorUtility.SetDirty(target);
            var armor = target as ArmorItem;

            DrawInformation(armor);

            EditorGUILayout.Separator();
            DrawCharacteristics(armor);
            EditorGUILayout.Separator();

            armor.actionGraph = (Tools.Action.ActionGraph)EditorGUILayout.ObjectField(armor.actionGraph, typeof(Tools.Action.ActionGraph), false);
        }

        private static void DrawInformation(ArmorItem armor)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Id: ", GUILayout.ExpandWidth(false));
            armor.Id = EditorGUILayout.IntField(armor.Id);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Name: ", GUILayout.ExpandWidth(false));
            armor.itemName = EditorGUILayout.TextField(armor.itemName);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Type: ", GUILayout.ExpandWidth(false));
            armor.type = (LootQuest.Models.Items.ArmorType)EditorGUILayout.EnumPopup(armor.type);
            EditorGUILayout.EndHorizontal();
        }

        private void DrawCharacteristics(ArmorItem armor)
        {
            EditorGUILayout.LabelField("Characteristics");
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Strength: ");
            armor.Strength = EditorGUILayout.IntField(armor.Strength);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Dexterity: ");
            armor.Dexterity = EditorGUILayout.IntField(armor.Dexterity);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Intelligence: ");
            armor.Intelligence = EditorGUILayout.IntField(armor.Intelligence);
            EditorGUILayout.EndHorizontal();
        }
    }
}