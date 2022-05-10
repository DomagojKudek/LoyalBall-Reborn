using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestroy : MonoBehaviour
{
    //vrijeme koje čekamo do uništenja
    public float destroyTime;
   
    void Start()
    {
        DestroyObjectDelayed();

    }
    

    void DestroyObjectDelayed()
    {
        // Uništava objekt nakon određenog vremna
        Destroy(gameObject, destroyTime);
    }
   
}
    

