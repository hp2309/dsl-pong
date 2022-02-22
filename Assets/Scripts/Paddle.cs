using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Transform transform;
    float speed = 10f;
    float newY = 0f;
    float input = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        move();
    }

    private void move()
    {
        input = Input.GetAxisRaw("Vertical");
        newY = input*speed*Time.deltaTime + transform.position.y;
        newY = Mathf.Clamp(newY, -4.1f, 4.1f);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
