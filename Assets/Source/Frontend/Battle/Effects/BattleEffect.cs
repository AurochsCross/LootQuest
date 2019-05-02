using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend.Battle.Effects {
    public class BattleEffect : MonoBehaviour {
        public Transform Source { get; private set; }
        public Transform Target { get; private set; }
        public virtual void Setup(Transform source, Transform target) { 
            Source = source;
            Target = target;
        }
    }
}