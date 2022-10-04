using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGDragnDrop : MonoBehaviour
{
    public float minX, maxX, minY, maxY;

    private float startX, startY;
    private bool isHeld = false;

    void Update()
    {
        if (isHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startX, mousePos.y - startY, 0);
        }

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startX = mousePos.x - this.transform.localPosition.x;
            startY = mousePos.y - this.transform.localPosition.y;

            this.GetComponent<BoxCollider2D>().enabled = false;

            isHeld = true;
        }
    }

    private void OnMouseUp()
    {
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }
        if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }

        isHeld = false;

        StartCoroutine(drop());
    }

    IEnumerator drop()
    {
        yield return new WaitForSeconds(0.01f);
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

}
