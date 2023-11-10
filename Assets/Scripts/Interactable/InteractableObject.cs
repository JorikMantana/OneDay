using UnityEngine;

namespace Interactable
{
    public class InteractableObject: MonoBehaviour , IInteractable
    {
        public virtual void Interact()
        {
            Debug.Log("Interact");
            DoAction();
        }

        protected virtual void DoAction()
        {
            Debug.LogError($"Метод Interact небыл реализован!");
        }
    }
}
