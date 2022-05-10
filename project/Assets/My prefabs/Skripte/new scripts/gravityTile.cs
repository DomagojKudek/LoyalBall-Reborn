using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Ball;

public class gravityTile : MonoBehaviour
{
    GameObject rollerBall = null;
    Ball ball = null;
    float jumpPower = 0f;
    private void Start()
    {
        rollerBall = GameObject.FindGameObjectWithTag("Player");
        ball = rollerBall.GetComponent<Ball>();
    }

    private void Update()
    {
        if (rollerBall == null)
        {
            rollerBall = GameObject.FindGameObjectWithTag("Player");
            if (rollerBall != null)
            {
                ball = rollerBall.GetComponent<Ball>();
            }
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == rollerBall)
        {
            jumpPower = ball.m_JumpPower;
            ball.m_JumpPower = 0;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == rollerBall)
        {
            ball.m_JumpPower = jumpPower;
        }
    }
}
