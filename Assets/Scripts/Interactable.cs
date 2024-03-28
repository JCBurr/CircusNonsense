using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    private bool canInteract;

    // Blank method for classes that inherit this to implement
    public interface IInteractable
    {
        void Interact();
    }
}
