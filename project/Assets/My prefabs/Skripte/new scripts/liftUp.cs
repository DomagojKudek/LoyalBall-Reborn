using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftUp : MonoBehaviour
{
    private bool goFlag = false;
    GameObject rollerBall = null;
    private float speed = 15f;
    private float time = 5;
    private bool trigger = false;
    void Start()
    {
        rollerBall = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (rollerBall == null)
        {
            rollerBall = GameObject.FindGameObjectWithTag("Player");
        }

        
        if (goFlag == true)
        {
            time = 5;
            float step = speed * Time.deltaTime;
            Vector3 target = this.transform.parent.position + Vector3.up*100f;
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, step);
        }
        if (goFlag == false)
        {
            if (trigger == true)
            {
                time -= Time.deltaTime;
            }
            if (time < 0)
            {
                float step = speed * Time.deltaTime;
                Vector3 target = this.transform.parent.position;
                this.transform.position = Vector3.MoveTowards(this.transform.position, target, step);
            }
        }
    }
    
    public void OnTriggerEnter(Collider collision)
    {
        rollerBall.transform.parent = transform;
        goFlag = true;
        trigger = false;
    }
    public void OnTriggerExit(Collider collision)
    {
        rollerBall.transform.parent = null;
        goFlag = false;
        trigger = true;
    }
}
