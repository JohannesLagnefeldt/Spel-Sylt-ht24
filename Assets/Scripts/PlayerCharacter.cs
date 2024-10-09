using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerCharacter : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private List<Interactable> interactables = new List<Interactable>();

    [SerializeField] private float responseivnes;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move_input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, speed * move_input.normalized, responseivnes * Time.deltaTime);
        if (rigidBody.velocity.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rigidBody.velocity.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        if (NearestInteractable())
        {
            NearestInteractable().Highlight();
            if (Input.GetButtonDown("Jump"))
            {
                NearestInteractable().Interact(this);
            }
        }

        
        animator.SetFloat("Move Speed", rigidBody.velocity.magnitude);


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

