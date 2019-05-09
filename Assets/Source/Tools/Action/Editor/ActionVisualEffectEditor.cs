using XNodeEditor;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;
using Frontend.Animations;

namespace Tools.Action.Editor {
    [CustomNodeEditor(typeof(ActionVisualEffect))]
    public class ActionVisualEffectEditor : NodeEditor {
        public override void OnBodyGUI() {
            ActionVisualEffect node = target as ActionVisualEffect;

            node.Type = (ActionVisualEffectType)EditorGUILayout.EnumPopup(node.Type);
            // node.Type = (ActionVisualEffectType)GUILayout.SelectionGrid((int)node.Type, new string[]{"Simple animation trigger", "Animation trigger", "Effect object" }, 2);

            if (node.Type == ActionVisualEffectType.SimpleAnimationTrigger) {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Animation: ");
                node.AnimationType = (Frontend.Animations.AnimationConfig.SimpleAnimationType)EditorGUILayout.EnumPopup(node.AnimationType);
                GUILayout.EndHorizontal();
                //node.AnimationType = (Frontend.Animations.AnimationConfig.SimpleAnimationType)GUILayout.SelectionGrid((int)node.AnimationType, Frontend.Animations.AnimationConfig.SimpleAnimationTriggers.Select(x => x).ToArray() /* new string[]{"Simple animation trigger", "Animation trigger", "Effect object" }*/, 1);
                node.TriggerName = node.AnimationType.ToName();
            } else if (node.Type == ActionVisualEffectType.AnimationTrigger) {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Trigger: ");
                node.TriggerName = GUILayout.TextField(node.TriggerName);
                GUILayout.EndHorizontal();
            } else if (node.Type == ActionVisualEffectType.EffectObject) {
                node.EffectGameObject = EditorGUILayout.ObjectField(node.EffectGameObject, typeof(GameObject)) as GameObject;
            }

            NodeEditorGUILayout.PortField(node.GetOutputPort("Effect"));
        }
    }
}