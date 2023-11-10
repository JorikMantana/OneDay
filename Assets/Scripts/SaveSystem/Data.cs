using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Data
{
    public PlayerData PlayerData { get; set; }
    public List<TaskSave> Tasks { get; set; }
    public List<InventoryItem> inventory { get; set; }

    public Dictionary<int, bool> DoorState { get; set; }
}

[Serializable]
public class PlayerData
{
    public Vector position;
    public Vector rotation;
}

[Serializable]
public class TaskSave
{
    public string Name { get; set; }
    public string Description { get; set; }
}

[Serializable]
public struct Vector
{
    public Vector(float x, float y, float z, float q)
    {
        X = x;
        Y = y;
        Z = z;
        Q = q;
    }

    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float Q { get; set; }
}