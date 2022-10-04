using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappController : MonoBehaviour
{
    public float rotationScale;
    public float jumpPower;
    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y <= 40 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rb.velocity = Vector2.up * jumpPower ;

        }

        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90 + rb.velocity.y * rotationScale));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "point")
        {
            GameObject.Find("GameManager").GetComponent<FlappGameManager>().updateScore();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "FlappDeathArea")
        {
            Time.timeScale = 0;
            GameObject.Find("GameManager").GetComponent<FlappGameManager>().Restart();
        }
    }


}
