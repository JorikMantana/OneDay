using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSession : MonoBehaviour
{
    [SerializeField] private GameObject ui;

    private void Start()
    {
        ui.SetActive(true);
        Invoke("StartGame", 5);
    }

    public void StartGame()
    {
        ui.SetActive(false);
    }
}
