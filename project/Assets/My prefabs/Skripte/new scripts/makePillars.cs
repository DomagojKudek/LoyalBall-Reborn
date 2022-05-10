using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makePillars : MonoBehaviour
{
    public GameObject pillar;
    Transform[,] pillarMatrix = new Transform[24, 8];
    float[,] speedMatrix = new float[24, 8];
    bool[,] direction = new bool[24, 8];
    void Start()
    {
        int i = 0;
        int j = 0;
        for (int x = 0; x < this.transform.childCount; x++)
        {
            pillarMatrix[i, j] = this.transform.GetChild(x);
            speedMatrix[i, j] = Random.Range(0.5f, 2f);
            if (Random.Range(0, 2) == 1)
            {
                direction[i, j] = true;
            }
            else
            {
                direction[i, j] = false;
            }
            j++;
            if (j == 8)
            {
                j = 0;
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 24; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (pillarMatrix[i, j] != null)
                {
                    if (direction[i, j] == true)
                    {
                        pillarMatrix[i, j].transform.Translate(Vector3.up * Time.deltaTime * speedMatrix[i, j]);
                        if (pillarMatrix[i, j].transform.position.y >= this.transform.position.y + 3)
                        {
                            pillarMatrix[i, j].transform.position = new Vector3(pillarMatrix[i, j].transform.position.x, this.transform.position.y + 2.99f, pillarMatrix[i, j].transform.position.z);
                            direction[i, j] = !direction[i, j];
                        }
                    }
                    if (direction[i, j] == false)
                    {
                        pillarMatrix[i, j].transform.Translate(Vector3.down * Time.deltaTime * speedMatrix[i, j]);
                        if (pillarMatrix[i, j].transform.position.y <= this.transform.position.y - 3)
                        {
                            pillarMatrix[i, j].transform.position = new Vector3(pillarMatrix[i, j].transform.position.x, this.transform.position.y - 2.99f, pillarMatrix[i, j].transform.position.z);
                            direction[i, j] = !direction[i, j];
                        }
                    }
                }
            }
        }
    }
}

