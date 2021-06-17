using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove2D : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpSpeed = 1;
    bool jumped;
    public bool isGrounded = true;

    private Rigidbody2D _rigidbody;
    private bool push = false;
    public bool canMove = true;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumped = true;
        }
    }

    void FixedUpdate()
    {
        if(!canMove)
        {
            if(_rigidbody.velocity.y > 0.001f || _rigidbody.velocity.y < -0.001f)
            {
                transform.position += new Vector3(0, -3.5f, 0) * Time.deltaTime;
            }
            else
            {
                _rigidbody.velocity = Vector2.zero;
            }
           return;
        }

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * movementSpeed * Time.deltaTime;
       

        if (jumped == true && (Mathf.Abs(_rigidbody.velocity.y) < 0.0001f) && isGrounded)
        {
            jumped = false;
            isGrounded = false;
            _rigidbody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }

        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -0.8f;
            animator.SetFloat("speed", -movement);

        }
        if (Input.GetAxis("Horizontal") >= 0)
        {
            characterScale.x = 0.8f;
            animator.SetFloat("speed", movement);
        }
        
        transform.localScale = characterScale;
        
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "Ground" || Collision.gameObject.tag == "Platform" )
        {
            isGrounded = true;
        }
    }

    public void basicKnockbackLeft(float strength)
    {
        Invoke("RemoveControl", 25);
        _rigidbody.AddForce(new Vector2(-strength, strength*0.5f), ForceMode2D.Impulse);
        push = false;

    }

    public void basicKnockbackRight(float strength)
    {
        Invoke("RemoveControl", 25);
        _rigidbody.AddForce(new Vector2(strength, strength * 0.5f), ForceMode2D.Impulse);
        push = false; 
    }

    private void RemoveControl()
    {
        push = true;
    }
}