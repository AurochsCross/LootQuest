using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;

[NodeWidth(1000)]
[NodeTint("#00FF00")]
[CreateNodeMenu("Loot Quest/Action description")]
public class ActionDescriptionNode : Node { 
    public int id;
    public string actionName;
    public string description;
}