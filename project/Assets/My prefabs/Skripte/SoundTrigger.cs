using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    //Koji zvuk ćemo puštati prilikom udarca    
    public AudioClip zvukUdara;
    AudioSource izvorZvuka;
    // Start is called before the first frame update
    void Start()
    {
        izvorZvuka = GetComponent<AudioSource>();
        izvorZvuka.clip = zvukUdara;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            izvorZvuka.Play();

        }
    }

  /*  void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            izvorZvuka.Play();

        }
    }*/
}
