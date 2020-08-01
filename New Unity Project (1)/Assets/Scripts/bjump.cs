using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bjump : MonoBehaviour
{
    public float fallHero = 2.5f;
    public float lowJump = 2f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Avake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallHero - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJump - 1 * Time.deltaTime);
        }
    }
}
