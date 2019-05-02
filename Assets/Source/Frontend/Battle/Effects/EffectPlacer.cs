using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend.Battle.Effects {
    public class EffectPlacer: MonoBehaviour {

        public enum EffectSubject { Target, Source };
        public EffectSubject Subject;

        public Vector3 Offset;
        
        void Start() { 
            if (Subject == EffectSubject.Source) {
                transform.position = gameObject.GetComponent<BattleEffect>().Source.position + Offset;
            } else if (Subject == EffectSubject.Target) {
                transform.position = gameObject.GetComponent<BattleEffect>().Target.position + Offset;
            }

        }
    }
}