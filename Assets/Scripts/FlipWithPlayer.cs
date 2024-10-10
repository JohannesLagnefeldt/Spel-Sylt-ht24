using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWithPlayer : MonoBehaviour
{
    [SerializeField] PlayerCharacter player;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = gameObject.transform.localPosition;

    }
    
    private void Update()
    {
        if (player.spriteRenderer.flipX)
        {
            gameObject.transform.localPosition = new Vector3(initialPosition.x * -1, initialPosition.y, initialPosition.z);
        }
        else
        {
            gameObject.transform.localPosition = new Vector3(initialPosition.x * 1, initialPosition.y, initialPosition.z);
        }
    }
}
