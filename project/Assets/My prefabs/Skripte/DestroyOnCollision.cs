using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour
{

    public bool destroySelfOnImpact = false;
    public float delayBeforeDestroy = 0.0f;
    public GameObject explosionPrefab;


    void OnCollisionEnter(Collision collision)
    {   //uništavanje samog objekta koji se sudario
        Destroy(gameObject, delayBeforeDestroy);
        if (explosionPrefab != null)
        {
            GameObject particle = Instantiate(explosionPrefab, transform.position, transform.rotation);
            particle.transform.parent = this.transform.parent;
        }
    }
}






