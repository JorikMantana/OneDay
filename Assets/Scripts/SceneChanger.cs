using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject mainSceneImage;
    [SerializeField] private GameObject churchSceneImage;
    [SerializeField] private Slider slider;
    [SerializeField] private float waitTime;
    [SerializeField] private int churchIndex;
    private void Start()
    {
        if (EnterToLocation.SceneIndex == churchIndex)
        {
            mainSceneImage.SetActive(false);
            churchSceneImage.SetActive(true);
        }

        slider.maxValue = waitTime;
        slider.value = 0;
        StartCoroutine("_loadScene");
    }

    IEnumerator _loadScene()
    {
        yield return new WaitForSeconds(waitTime);
        AsyncOperation operation = SceneManager.LoadSceneAsync(EnterToLocation.SceneIndex);
    }

    private void Update()
    {
        slider.value += Time.deltaTime;
    }
}
