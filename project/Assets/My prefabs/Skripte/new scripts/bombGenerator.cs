using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject bomb;
    private float timer = 1;
    private bool flag = false;

    void Update()
    {

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (flag == true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                for (int i = 0; i < 20; i++)
                {
                    Vector3 position = new Vector3(Random.Range(0, 256f), Random.Range(100, 150f), Random.Range(0, 256f));
                    position += this.transform.position;
                    GameObject newBomb = Instantiate(bomb, position, Quaternion.Euler(Vector3.up * 0));
                    newBomb.transform.parent = this.transform;
                }
                timer = 5;
            }
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        flag = true;
    }

}
