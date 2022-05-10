/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundTriggerWithSnapshot : MonoBehaviour
{
    //Koji zvuk ćemo puštati prilikom udarca    
    public AudioClip zvukUdara;
    public AudioMixerSnapshot aktivnaSnimka;
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
         //jako loš način rada, bolje bi bilo napraviti poseban collider
            aktivnaSnimka.TransitionTo(1f);

        }
    }

    /*  void OnCollisionExit(Collision collision)
      {

          if (collision.gameObject.tag == "Player")
          {
              izvorZvuka.Play();

          }
      }*/
//}

