using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    public Vector3 lastPosition;
    void Start()
    {
        lastPosition = new Vector3(0, 0, 0);
    }

    public void OnTriggerEnter(Collider collision)
    {
        LostBallGameManager.gm.checkPointPosition = this.transform.position + new Vector3(0,9,0);
    }

}
