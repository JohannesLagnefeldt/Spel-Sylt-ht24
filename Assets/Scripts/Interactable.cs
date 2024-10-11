using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public Vector3 position;
    [SerializeField] GameObject arrow;
    private void Start()
    {
        position = gameObject.transform.position;
    }
    public abstract void Interact(PlayerCharacter player);

    public void Highlight()
    {
        arrow.SetActive(true);
    }

    public void NoHighlight()
    {
        arrow.SetActive(false);
    }


}
