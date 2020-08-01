using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatform : MonoBehaviour
{
    float dirY;
    public float speed = 3f;
    public float posA;
    public float posB;

    bool moveingRight = true;

    private void Update()
    {
        if (transform.position.y > posA)
        {
            moveingRight = false;
        }
        else if (transform.position.y < posB)
        {
            moveingRight = true;

        }
         if (moveingRight) 
        {
            transform.position = new Vector2 (transform.position.x,transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }
}
