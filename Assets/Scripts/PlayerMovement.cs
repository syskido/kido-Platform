using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;    
    private Animator anim;
    private bool grounded;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
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

        if (Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();

        //Set animator parameters
        anim.SetBool("run", horzontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
 

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
