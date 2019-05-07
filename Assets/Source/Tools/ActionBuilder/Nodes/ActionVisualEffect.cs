using System;
using XNode;
using UnityEngine;

namespace Tools.ActionBuilder.Nodes {
    public enum ActionVisualEffectType {
        SimpleAnimationTrigger,
        AnimationTrigger,
        EffectObject
    };
    public class ActionVisualEffect: Node {

        public ActionVisualEffectType Type;
        public Frontend.Animations.AnimationConfig.SimpleAnimationType AnimationType = Frontend.Animations.AnimationConfig.SimpleAnimationType.SimpleAttack;
        public string TriggerName;
        public GameObject EffectGameObject;

        [Output] public ActionVisualEffect Effect;
    }
}