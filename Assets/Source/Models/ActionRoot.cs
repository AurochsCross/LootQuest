﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

[DataContract]
public class ActionRoot
{
    [DataMember]
    public int id;
    [DataMember]
    public string name;
    [DataMember]
    public string description;
    [DataMember]
    public ActionEffect[] effects;
}
