using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    public Vector3 initialPosition;
    public float dropTimer;
    public float returnTimer;
    public bool falling;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        dropTimer = Random.Range(8f, 12f);
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        dropTimer -= Time.deltaTime;
        if(dropTimer < 0)
        {
            dropTimer = Random.Range(8f, 12f);
            if(Random.Range(0f, 1f) > 0.5f)
            {
                falling = true;
            }
        }
        else if (dropTimer < 2 && dropTimer > 0)
        {
            transform.position = initialPosition;
            falling = false;
        }
        if(falling)
        {
            transform.Translate(Vector3.down* Time.deltaTime * speed);
        }
    }
}
