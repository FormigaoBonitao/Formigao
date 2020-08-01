using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthSystem : MonoBehaviour
{
    public int health;
    public int numberOfLives;

    public Image[] lives;
    public Sprite fullLive;
    public Sprite emptyLive;

    private Animator anim;
    public bool die = false;
    public GameObject death;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health > numberOfLives)
        {
            health = numberOfLives;
        }

        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fullLive;
            }
            else
            {
                lives[i].sprite = emptyLive;
            }
            if (i < numberOfLives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
            if (die == true)
            {
                death.gameObject.SetActive(true);
            }

        }

        if (health <= 0)
        {
            die = true;
            Die();
        }
    }
    void Die()
    {
        anim.SetTrigger("Die");
        die = true;
        GameObject.Find("Character").GetComponent<CharacterController>().anim.SetTrigger("Die");
       
        
    }

   
}
