using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToLocation : MonoBehaviour, IInteractable
{
    [SerializeField] private int nextSceneIndex;
    public LoadLoadingScreen loadLoadingScreen;
    [SerializeField] public bool isClosed = false;
    [SerializeField] private GameObject closedErrorText;
    public static int SceneIndex = 2;
    public int DoorId;

    public void OpenDoor()
    {
        isClosed = false;
    }
    
    public void Interact()
    {
        if (!isClosed)
        {
            SceneIndex = nextSceneIndex;
            loadLoadingScreen.LoadingScreen();
        }
        else
        {
            closedErrorText.SetActive(true);
            Invoke("DeactivateClosedErrorText", 2);
        }
    }
    
    public void DeactivateClosedErrorText()
    {
        closedErrorText.SetActive(false);
    }
}
