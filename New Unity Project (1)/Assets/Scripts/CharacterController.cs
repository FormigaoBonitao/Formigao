using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    
    public float speed = 5f;
    public float move;
    Rigidbody2D rb;
    public float jumpForce;
    public bool isGrounded;
    public LayerMask whatIsGroud;
    public GameObject Groud;
    public Transform groundChek;
    public float checkRadius;
    public bool extraJumps = true ;
    public int extraJumpsValue = 1;
    //private bool facingRight = true;
    public Animator anim;
    [SerializeField] private int direction;

    public bool Grouded;

    public bool IGrouded
    {
        get
        {
            return Grouded;
        }
        set
        {
            Grouded = value;
        }
    }
   
    

    

    int playerObject, colliderObject;

   
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        playerObject = LayerMask.NameToLayer("Player");
        colliderObject = LayerMask.NameToLayer("Ground");
    }
    private void Update()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        if (direction != 0)
        {
            anim.SetBool("Run", true);
        }
        else if (direction == 0)
        {
            anim.SetBool("Run", false);
        }
        Flip();

       
        if (rb.velocity.y >= 0)
        {
            Physics2D.IgnoreLayerCollision(playerObject, colliderObject, true && isGrounded == false);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(playerObject, colliderObject, false && isGrounded == false);
        }

       
    }

    public void ChangeDirection(int buttonDirection)
    {
        direction = buttonDirection;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       
        isGrounded = Physics2D.OverlapCircle(groundChek.position, checkRadius, whatIsGroud);
        //move = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.W))
            Jump();      
              
    }
    public void Jump()
    {
        if (isGrounded == true)
        {
            anim.SetTrigger("jump");

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

    }
   public void Flip()
    {
        if (direction > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        
        if (collision.tag.Equals("Enemy"))
        {
            
            Damage();
        }
             
   
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Damage()
    {
        anim.Play("Hit");
        GetComponent<HealthSystem>().health -=1;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("tiles"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("tiles"))
        {
            this.transform.parent = null;
        }
    }








}