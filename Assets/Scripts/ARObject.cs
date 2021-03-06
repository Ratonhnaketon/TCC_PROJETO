﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] 
public class ARObject
{
    public string name;
    public string description;
    public string id;
    public float scale;
    public string[] hashtags;

    public ARObject(string name, string description, string id, string[] hashtags, float scale)
    {
        this.name = name;
        this.description = description;
        this.id = id;
        this.hashtags = hashtags;
        this.scale = scale;
    }
}
