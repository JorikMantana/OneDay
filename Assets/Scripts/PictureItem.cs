using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureItem : MonoBehaviour, IInteractable
{
    public static int PictureCount;
    [SerializeField] private int okjeoj;

    private void Update()
    {
        okjeoj = PictureCount;
    }

    public void Interact()
    {
        gameObject.SetActive(false);
        PictureCount++;
    }
}
