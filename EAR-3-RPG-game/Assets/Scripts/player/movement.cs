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
    Animator anim;
    bool ok;
    public GameObject sunetMiscare;

    private Vector3 pointerInput;

    void Start()
    {
        anim = GetComponent<Animator>();
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
    if(horizontal!=0 && vertical!=0)
    {
                anim.SetBool("isRunningLR", true);
                ok=true;
    }else
    {
        ok=false;
    }
        if(horizontal!=0 && ok==false)
        {
            anim.SetBool("isRunningLR", true);
            ok=true;
        } 
        else   
        {
            anim.SetBool("isRunningLR", false);
            ok=false;
        }
        if(vertical==1 && ok==false)
        {
            anim.SetBool("isRunningUP", true);
            ok=true;
        } 
        else   
        {
            anim.SetBool("isRunningUP", false);
            ok=false;
        }
        if(vertical==-1 && ok==false)
        {
            anim.SetBool("isRunningDN", true);
            ok=true;
        } 
        else   
        {
            anim.SetBool("isRunningDN", false);
            ok=false;
        }
        if(horizontal!=0 || vertical!=0)
        {
            sunetMiscare.SetActive(true);
        }
        else
        {
            sunetMiscare.SetActive(false);
        }
    
        

    }

    public void RotateToPointer(Vector3 lookDirection)
    {
        Vector3 scale = transform.localScale;
        if(horizontal!=0 || vertical!=0)
        {
        if (horizontal > 0)
        {
            scale.x = 1;
        }
        else if (horizontal < 0)
        {
            scale.x = -1;
        }
        }else
        {
           if (lookDirection.x > 0)
        {
            scale.x = 1;
        }
        else if (lookDirection.x < 0)
        {
            scale.x = -1;
        } 
        }
        
        transform.localScale = scale;
        
    }
}
