using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPictureItem : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject ui;
    public void Interact()
    {
        gameObject.SetActive(false);
        ui.SetActive(true);
        Invoke("EndGame", 5);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}
