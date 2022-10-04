using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Animator animator;

    int state = 1;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        switch (state) {
            case 1:
                animator.Play("yay-kilic");
                break;
            case 2:
                animator.Play("yay-yay");
                break;
        }
            

        if (Input.GetKey(KeyCode.Alpha1) && state != 1)            state = 1;
        if (Input.GetKey(KeyCode.Alpha2) && state != 2)            state = 2;

    }
}
