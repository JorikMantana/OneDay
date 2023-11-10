using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLoadingScreen : MonoBehaviour
{
    public void LoadingScreen()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
}
