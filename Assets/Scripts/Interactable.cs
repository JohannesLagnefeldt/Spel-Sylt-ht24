using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public Vector3 position;

    private void Start()
    {
        position = transform.position;
    }
    public abstract void Interact(PlayerCharacter player);

    public void Highlight()
    {

    }
    
}
