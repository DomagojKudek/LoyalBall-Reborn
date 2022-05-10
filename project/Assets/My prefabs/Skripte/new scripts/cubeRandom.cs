using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeRandom : MonoBehaviour
{
    public GameObject[] spawnObjects;
    void Start()
    {
        Vector3 spawnPosition = Vector3.zero;
        Transform cubeHolder = new GameObject("cubes").transform;
        cubeHolder.parent = this.transform;
        for (int i = 0; i < 12; i++)
        {
            Vector3 currentPosition = new Vector3();
            currentPosition = this.transform.position;

            spawnPosition.x = Random.Range(-7.5f + currentPosition.x, 7.5f + currentPosition.x);
            spawnPosition.y = currentPosition.y + 0.5f;
            spawnPosition.z = Random.Range(-7.5f + currentPosition.z, 7.5f + currentPosition.z);
            int objectToSpawn = Random.Range(0, spawnObjects.Length);

            GameObject spawnedObject = Instantiate(spawnObjects[objectToSpawn], spawnPosition, transform.rotation) as GameObject;
            spawnedObject.transform.parent = cubeHolder;
            spawnedObject.GetComponent<TargetMover>().spinSpeed = Random.Range(120f, 200f);
            spawnedObject.GetComponent<TargetMover>().motionMagnitude = Random.Range(0.05f, 0.1f);
        }
    }

}
