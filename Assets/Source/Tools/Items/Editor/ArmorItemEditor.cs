using UnityEditor;
using UnityEngine;
using Models.Items;
using Models.Common;

namespace Tools.Items {
    [CustomEditor(typeof(ArmorItem))]
    class ArmorItemEditor: Editor {

        Tools.ActionBuilder.AbilityGraph actionGraph;

        private bool isCharacteristicsShowing = false;

        public override void OnInspectorGUI()
        {
            var armor = target as ArmorItem;
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Name: ", GUILayout.ExpandWidth(false));
            armor.itemName = EditorGUILayout.TextField(armor.itemName);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Type: ", GUILayout.ExpandWidth(false));
            armor.type = (ArmorType)EditorGUILayout.EnumPopup(armor.type);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Separator();
            DrawCharacteristics(armor);
            EditorGUILayout.Separator();

            EditorGUILayout.LabelField("Action: " + (armor.action != null ? armor.action.name : "none"), GUILayout.ExpandWidth(false));
            actionGraph = (Tools.ActionBuilder.AbilityGraph)EditorGUILayout.ObjectField(actionGraph, typeof(Tools.ActionBuilder.AbilityGraph));
            armor.action = actionGraph != null ? actionGraph.GetAction() : null;


        }

        private void DrawCharacteristics(ArmorItem armor) {
            if (armor.attributes == null) {
                armor.attributes = new Attributes();
            }

            EditorGUILayout.LabelField("Characteristics");
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Strength: ");
            var strength = EditorGUILayout.IntField(armor.attributes.strength);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Dexterity: ");
            var dexterity = EditorGUILayout.IntField(armor.attributes.dexterity);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Intelligence: ");
            var intelligence = EditorGUILayout.IntField(armor.attributes.intelligence);
            EditorGUILayout.EndHorizontal();

            armor.attributes = new Attributes(strength, dexterity, intelligence);
        }
    }
}