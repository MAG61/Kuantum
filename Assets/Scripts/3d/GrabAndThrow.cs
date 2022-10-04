using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndThrow : MonoBehaviour
{
    public float pickUpRange = 5f;
    public float moveForce = 250;
    private GameObject holdedObj;
    public Transform holdParent;
    public LayerMask layerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (holdedObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange, layerMask))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if (holdedObj != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(holdedObj.transform.position, holdParent.transform.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - holdedObj.transform.position);
            holdedObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 5;

            objRig.transform.parent = holdParent;
            holdedObj = pickObj;
        }
    }

    void DropObject()
    {
        Rigidbody objRig = holdedObj .GetComponent<Rigidbody>();
        objRig.useGravity = true;
        objRig.drag = 1;

        objRig.transform.parent = null;
        holdedObj = null;
    }
}
