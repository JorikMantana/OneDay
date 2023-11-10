using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Note", menuName = "Note", order = 51)]
public class NoteData : ScriptableObject
{
    [SerializeField] public string Name = "Unknow";
    [SerializeField] public string Content = "Unknow";
}
