using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Task", order = 51)]
public class TaskData : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public string Description;
}
