using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move_input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidBody.velocity = move_input.normalized * speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            print("interacted");
        }
    }


}
