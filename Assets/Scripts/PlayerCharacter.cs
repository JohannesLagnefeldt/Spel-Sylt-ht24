using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.U2D;


public class PlayerCharacter : MonoBehaviour
{
    public enum Item
    {
        NOTHING = 0,
        PASTRY_BAKED = 1,
        PASTRY_UNBAKED = 2,
        CUP_EMPTY = 3,
        CUP_BLACK = 4,
        CUP_MILK = 5,
        CUP_SKIMMED= 6
    }

    private Rigidbody2D rigidBody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private List<Interactable> interactables = new List<Interactable>();
    private ItemRenderer[] itemRenderers; 

    public List<Item> inventory = new List<Item>();

    [SerializeField] private float responseivnes;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        itemRenderers = GetComponentsInChildren<ItemRenderer>();
        inventory.Add(Item.NOTHING);
        inventory.Add(Item.NOTHING);
        UpdateTray();
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
            interactables.ForEach(i => i.NoHighlight());
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
            float dist = Vector3.Distance(item.position, transform.position);
            if(dist < previusDist)
            {
                nearestinteractable = item;
            }
        }

        return nearestinteractable;
    }

    public void UpdateTray()
    {
        itemRenderers[0].SetSprite(inventory[0]);
        itemRenderers[1].SetSprite(inventory[1]);

        if (inventory.Any(i => i != Item.NOTHING))
        {
            animator.SetBool("Carrying Tray", true);
        }
        else
        {
            animator.SetBool("Carrying Tray", false);
        }
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
            collision.GetComponent<Interactable>().NoHighlight();
        }
    }

}

