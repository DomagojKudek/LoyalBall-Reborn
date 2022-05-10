using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateDisk : MonoBehaviour
{

    GameObject rollerBall = null;
    float spinSpeed = 0;
    private void Start()
    {
        float angle = 0f;
        spinSpeed = Random.Range(-70f, 70f);
        rollerBall = GameObject.FindGameObjectWithTag("Player");
        if (Random.Range(0, 2) > 1)
        {
            angle = Random.Range(-15f, -5f);
        }
        else
        {
            angle = Random.Range(5f, 15f);
        }
        transform.Rotate(0, 0, angle);
    }
    void Update()
    {
        if (rollerBall == null)
        {
            rollerBall = GameObject.FindGameObjectWithTag("Player");
        }
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
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
