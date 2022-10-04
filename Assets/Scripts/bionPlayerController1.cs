using UnityEngine;

public class bionPlayerController1 : MonoBehaviour
{
    public float normalSpeed = 1;
    public float sprintSpeed = 2;
    public float crouchSpeed = 0.5f;
    public float jumpForce = 1;
    public int state = 1;

    private bool faceRight = false;
    public bool isOnAir;
    public bool isSneaking;

    private Rigidbody2D rb;
    private Animator animator;
    private float speed;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            state = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            state = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            state = 3;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isSneaking = !isSneaking;
            if (isSneaking)
            {
                speed = crouchSpeed;
            }
            else
            {
                speed = normalSpeed;
            }
            animator.SetBool("isSneaking", isSneaking);
        }

        animator.SetInteger("state", state);

        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            animator.SetBool("isOnAir", false);
        }
        else
        {
            animator.SetBool("isOnAir", true);
        }


        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        animator.SetInteger("xVelocity", (int)movement);

        if (Input.GetKey(KeyCode.LeftShift) && (movement > 0 || movement < 0) && !isSneaking)
        {
            speed = sprintSpeed;
            animator.SetBool("isRunning", true);
        }
        else
        {
            if (!isSneaking)
            {
                speed = normalSpeed;
                animator.SetBool("isRunning", false);
            }
        }

        if (movement > 0 || movement < 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (faceRight == true && movement < 0)
        {

            Flip();
        }
        else if (faceRight == false && movement > 0)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && (Mathf.Abs(rb.velocity.y) < 0.01f || !isOnAir))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isOnAir = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Platform" && isOnAir)
        {
            isOnAir = false;
        }
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
