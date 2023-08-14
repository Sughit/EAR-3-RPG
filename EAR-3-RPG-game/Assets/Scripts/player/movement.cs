using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float horizontal;
    float vertical;

    private Vector3 pointerInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        pointerInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDirection = pointerInput - transform.position;
        RotateToPointer(lookDirection);
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        rb.velocity = moveDirection * speed *Time.fixedDeltaTime;
    }

    public void RotateToPointer(Vector3 lookDirection)
    {
        Vector3 scale = transform.localScale;
        if (lookDirection.x > 0)
        {
            scale.x = 1;
        }
        else if (lookDirection.x < 0)
        {
            scale.x = -1;
        }
        transform.localScale = scale;
    }
}
