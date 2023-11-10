using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private NoteData data;

    [SerializeField] private TMP_Text Name;
    [SerializeField] private TMP_Text Content;

    private void Start()
    {
        if (data == null)
        {
            data = new();
            Debug.LogError("the value Data not set");
        }

        Name.text = data.Name;
        Content.text = data.Content;
    }
}
