using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BattleEffectCameraShake : MonoBehaviour
{
    public float Delay;
    public float Duration;
    public float Strength;
    public int Vibro;    

    // Update is called once per frame
    void Start() {
            Camera.main.DOShakePosition(Duration, Strength, Vibro).SetDelay(Delay);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            Camera.main.DOShakePosition(Duration, Strength, Vibro);
        }
        
    }
}
