using UnityEditor;
using UnityEngine;

namespace Tools.Items
{
    [System.Serializable]
    [CustomEditor(typeof(Frontend.Exploring.EntityRegistry))]
    class HostileRegistryEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var registry = target as Frontend.Exploring.EntityRegistry;

            EditorGUILayout.LabelField("Registered entities:" + registry.Entities.Count);
            EditorGUILayout.LabelField("Registered hostiles:" + registry.Hostiles.Count);
        }
    }
}