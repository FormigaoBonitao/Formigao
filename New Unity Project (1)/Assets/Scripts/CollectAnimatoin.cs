using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAnimatoin : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            FruitsCollect.fruitsCount += 1;
            GetComponent<Collider2D>().enabled = false;
            anim.SetTrigger("collect");
            

            Destroy(gameObject, 1);
        }
    }
}
