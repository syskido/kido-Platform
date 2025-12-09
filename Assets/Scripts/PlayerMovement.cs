using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    private Animator anim;
    private bool grounded;


    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horzontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horzontalInput * speed, body.velocity.y);

        //Flip player when moving left/right
        if (horzontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horzontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        //Set animator parameters
        anim.SetBool("run", horzontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if player is grounded
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
