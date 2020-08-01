using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataormHoriz : MonoBehaviour
{
    float dirX;
    public float speed = 3f;
    public float posA;
    public float posB;

    bool moveingRight = true;

    private void Update()
    {
        if (transform.position.x > posA)
        {
            moveingRight = false;
        }
        else if (transform.position.x < posB)
        {
            moveingRight = true;

        }
        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
