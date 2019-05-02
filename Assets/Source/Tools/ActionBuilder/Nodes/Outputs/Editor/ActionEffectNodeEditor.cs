using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;
using LootQuest.Models.Action;

namespace Tools.ActionBuilder.Nodes {
    [CustomNodeEditor(typeof(ActionEffectNode))]
    public class ActionEffectNodeEditor : NodeEditor {
        public override void OnBodyGUI() {
            ActionEffectNode node = target as ActionEffectNode;

            node.subject = (EffectSubject)GUILayout.SelectionGrid((int)node.subject, new string[]{"Source", "Target" }, 2);

            node.typeIndex = GUILayout.SelectionGrid(node.typeIndex, new string[]{"Attack", "Heal" }, 2);
            switch (node.typeIndex) {
                case 0: {
                    node.type = EffectType.Damage;
                    break;
                }
                case 1: {
                    node.type = EffectType.Heal;
                    break;
                }
            }

            if (node.id == -1) {
                GUILayout.Label("Id: none");
            } else {
                GUILayout.Label("Id:" + node.id);
            }

            GUILayout.BeginHorizontal();
            GUILayout.Label("Delay: ", GUILayout.ExpandWidth(false));
            node.Delay = EditorGUILayout.FloatField(node.Delay);
            GUILayout.EndHorizontal();


            DrawEffectArray(node);
            DrawWindupEffectArray(node);

            GUILayout.Label("Hit condition");
            NodeEditorGUILayout.PortField(new GUIContent("Input"), node.GetPort("hitCondition"));
            NodeEditorGUILayout.PortField(node.GetPort("didHit"));

            GUILayout.Label("Value calculation");
            NodeEditorGUILayout.PortField(new GUIContent("Input"), node.GetPort("valueCalculation"));
            NodeEditorGUILayout.PortField(new GUIContent("Calculation"), node.GetPort("valueCalculationRaw"));
            NodeEditorGUILayout.PortField(new GUIContent("Calculated value"), node.GetPort("calculatedValue"));
            
            GUILayout.Label("");
            NodeEditorGUILayout.PortField(node.GetPort("output"));
            //GUILayout.EndHorizontal();

            // SimpleGraph graph = node.graph;
        }

        private bool _showEffects = false;

        private void DrawEffectArray(ActionEffectNode node) {
            if (node.Effects == null) {
                node.Effects = new List<GameObject>();
            }
            
            _showEffects = EditorGUILayout.Foldout(_showEffects, "Effects");
            if (!_showEffects) {
                return;
            }

            GUILayout.BeginHorizontal();
            GUILayout.Label("Count: ");
            int capacity = EditorGUILayout.IntField(node.Effects.Capacity);

            if (capacity < node.Effects.Count)
                node.Effects.RemoveRange(capacity, node.Effects.Count - capacity);
            node.Effects.Capacity = capacity;
            GUILayout.EndHorizontal();

            for (int i = 0; i < node.Effects.Capacity; i++) {
                if (i < node.Effects.Count) {
                    node.Effects[i] = EditorGUILayout.ObjectField(node.Effects[i], typeof(GameObject)) as GameObject ?? null;
                } else {
                    GameObject temp = EditorGUILayout.ObjectField((GameObject)null, typeof(GameObject)) as GameObject;
                    if (temp != null) {
                        node.Effects.Add(temp);
                    }
                }
            }
        }

        private bool _showWindupEffects = false;
        private void DrawWindupEffectArray(ActionEffectNode node) {
            _showWindupEffects = EditorGUILayout.Foldout(_showWindupEffects, "Windup Effects");
            if (!_showWindupEffects) {
                return;
            }

            GUILayout.BeginHorizontal();
            GUILayout.Label("Count: ");
            int capacity = EditorGUILayout.IntField(node.WindupEffects.Capacity);

            if (capacity < node.WindupEffects.Count)
                node.WindupEffects.RemoveRange(capacity, node.WindupEffects.Count - capacity);
            node.WindupEffects.Capacity = capacity;
            GUILayout.EndHorizontal();

            for (int i = 0; i < node.WindupEffects.Capacity; i++) {
                if (i < node.WindupEffects.Count) {
                    node.WindupEffects[i] = EditorGUILayout.ObjectField(node.WindupEffects[i], typeof(GameObject)) as GameObject ?? null;
                } else {
                    GameObject temp = EditorGUILayout.ObjectField((GameObject)null, typeof(GameObject)) as GameObject;
                    if (temp != null) {
                        node.WindupEffects.Add(temp);
                    }
                }
            }
        }
    }
}