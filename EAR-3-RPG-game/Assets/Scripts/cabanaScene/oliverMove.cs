using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oliverMove : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public bool startDialog;

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position)>1f)
        {
            transform.position=Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
        }
        else
        {
            startDialog=true;
        }
    }
}
