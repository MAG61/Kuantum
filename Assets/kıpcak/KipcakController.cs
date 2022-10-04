using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KipcakController : MonoBehaviour
{
    public float movementSpeed = 1;
    public float jumpForce = 1;

    private bool faceRight = true;
    public bool isOnAir;
    public bool isJumping;
    public bool isGliding;

    private Rigidbody2D rb;
    private Animator animator;

    public string currentAnimation = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        if (isGliding && !animator.GetCurrentAnimatorStateInfo(0).IsName("kipcak-glide"))
        {
            animator.Play("kipcak-glide");
            currentAnimation = "kipcak-glide";
        }

        if (movement > 0 || movement < 0)
        {
            if (!isOnAir && !isJumping)
            {
                animator.Play("kipcak-run");
                currentAnimation = "kipcak-run";
            }
            //else if (animator.GetCurrentAnimatorStateInfo(0).IsName("kipcak-jump") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= animator.GetCurrentAnimatorStateInfo(0).length)
            //{
            //    animator.Play("kipcak-run");
            //    currentAnimation = "kipcak-run";
            //}
        }
        else
        {
            if (!isOnAir && !isJumping)
            {
                animator.Play("kipcak-idle");
                currentAnimation = "kipcak-idle";
            }
            //else if (animator.GetCurrentAnimatorStateInfo(0).IsName("kipcak-jump") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= animator.GetCurrentAnimatorStateInfo(0).length)
            //{
            //    animator.Play("kipcak-idle");
            //    currentAnimation = "kipcak-idle";
            //}
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
            animator.Play("kipcak-jump");
            currentAnimation = "kipcak-jump";
            isOnAir = true;
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Platform" && isOnAir)
        {
            isOnAir = false;
        }
        if (isGliding)
        {
            isGliding = false;
            animator.Play("kipcak-roll");
            currentAnimation = "kipcak-roll";
            StartCoroutine(returnJump());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform" && isOnAir)
        {
            isOnAir = false;

        }
        if (isGliding)
        {
            isGliding = false;
            animator.Play("kipcak-roll");
            currentAnimation = "kipcak-roll";
            StartCoroutine(returnJump());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform" && isOnAir)
        {
            isOnAir = false;

        }
        if (isGliding)
        {
            isGliding = false;
            animator.Play("kipcak-roll");
            currentAnimation = "kipcak-roll";
            StartCoroutine(returnJump());
        }
    }

    IEnumerator returnJump()
    {
        yield return new WaitForSeconds(0.61f);
        isJumping = false;
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length - 0.2f >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
