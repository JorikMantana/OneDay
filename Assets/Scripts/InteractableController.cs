using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractableController : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [Header("Croshair Setting")]
    [SerializeField]
    private Image CrosHair;
    [SerializeField]
    private Sprite DotCroshaier;
    [SerializeField]
    private Sprite InteractableCroshair;

    [Header("Interactable Setting")]
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private LayerMask interactableLayer;
    [SerializeField]
    private Text ItemName;


    [SerializeField] private IInteractable curentInteractable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.transform.position, camera.transform.forward, Color.green, 0, true);

        InteractableRay();

        if (Input.GetKeyDown(KeyCode.E) && curentInteractable != null) curentInteractable.Interact();
    }


    private void InteractableRay()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit hit, maxDistance, interactableLayer))
        {

            if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
            {
                //CrosHair.sprite = InteractableCroshair;
                curentInteractable = interactable;
            }

        }
        else
            curentInteractable = null;
    }
}
