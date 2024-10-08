using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerCharacter : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private List<Interactable> interactables = new List<Interactable>();

    [SerializeField] private float responseivnes;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move_input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, speed * move_input.normalized, responseivnes * Time.deltaTime);
        if (Input.GetButtonDown("Jump"))
        {
            print("interacted");
        }

        if (NearestInteractable())
        {
            NearestInteractable().Highlight();
        }
        
    }

    private Interactable NearestInteractable()
    {
        float previusDist = 200;
        Interactable nearestinteractable = null;

        foreach (var item in interactables)
        {
            float dist = Vector3.Distance(item.transform.position, transform.position);
            if(dist < previusDist)
            {
                nearestinteractable = item;
            }
        }

        return nearestinteractable;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            interactables.Add(collision.GetComponent<Interactable>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            interactables.Remove(collision.GetComponent<Interactable>());
        }
    }
}

