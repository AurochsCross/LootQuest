using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NpcHelper : MonoBehaviour
{
    [MenuItem("LootQuest/Tools/NPC/Add NPC Components")]
    public static void AddNpcComponents() {
        if (Selection.activeTransform != null) {
            Selection.activeTransform.gameObject.AddComponent<Frontend.Animations.AnimationManager>();
            Selection.activeTransform.gameObject.AddComponent<Frontend.NPC.HostileNPC>();
            Selection.activeTransform.gameObject.AddComponent<Frontend.Entity.EntityMaster>();
            Selection.activeTransform.gameObject.AddComponent<Frontend.Entity.EntityBattleMaster>();
            Selection.activeTransform.gameObject.AddComponent<Frontend.Entity.EntityEffectMaster>();
            Selection.activeTransform.gameObject.AddComponent<Frontend.NPC.BehaviourExecutor>();
        }
    }
}
