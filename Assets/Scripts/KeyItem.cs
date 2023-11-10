using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyItem : Item
{
    [SerializeField] public UnityEvent _event;
    protected override void DoAction()
    {
    }
}
