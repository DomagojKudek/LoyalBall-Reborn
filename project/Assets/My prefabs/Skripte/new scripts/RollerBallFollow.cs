using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBallFollow : MonoBehaviour
{


    public GameObject target;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.transform.position + offset;
        }
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }
    }
}