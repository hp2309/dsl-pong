using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    public GameObject Ball;
    float speedMultiplier = 1f;
    float speed;
    int delta = 0;
    public float decisionBoundary = 0f;
    // Update is called once per frame
    private void Update()
    {
        if(Ball.transform.position.x > decisionBoundary)
        {
            Ball = GameObject.FindGameObjectWithTag("ball");
            delta = (Ball.transform.position.y > this.transform.position.y) ? 1 : -1;
            speed = speedMultiplier * (Ball.transform.position.x - decisionBoundary);
            move(delta, speed);
        }
    }

    private void move(int delta, float speed)
    {
        this.transform.position = new Vector3(this.transform.position.x, Mathf.Clamp(this.transform.position.y + delta * speed * Time.deltaTime, -4.1f, 4.1f), this.transform.position.z);
    }
}
