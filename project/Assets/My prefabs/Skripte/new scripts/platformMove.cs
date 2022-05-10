using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    GameObject rollerBall = null;


    private void Start()
    {
        rollerBall = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (rollerBall == null)
        {
            rollerBall = GameObject.FindGameObjectWithTag("Player");
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == rollerBall)
        {
            rollerBall.transform.parent = transform;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == rollerBall)
        {
            rollerBall.transform.parent = null;
        }
    }
     
}
