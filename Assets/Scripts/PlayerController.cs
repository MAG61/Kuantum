using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float movementSpeed = 1;
	public float jumpForce = 1;

	private bool faceRight = true;
	public bool isOnAir;

	private Rigidbody2D rb;
	private Animator animator;


	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		animator.SetBool("isOnAir", isOnAir);
		float movement = Input.GetAxis("Horizontal");
		transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

		if (movement > 0 || movement < 0)
		{
			animator.SetBool("isRunning", true);
		}
		else
		{
			animator.SetBool("isRunning", false);
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
			animator.SetTrigger("jump");
			isOnAir = true;
        }

		if (Mathf.Abs(rb.velocity.y) < 0.01f && Mathf.Abs(rb.velocity.y) > -0.01f)
			animator.SetBool("jump", false);

		else if (Mathf.Abs(rb.velocity.y) > 0.01f)
			animator.SetBool("jump", true);

		else if (Mathf.Abs(rb.velocity.y) < -0.01f)
			animator.SetBool("jump", true);

		animator.SetFloat("yVelocity", rb.velocity.y);
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
