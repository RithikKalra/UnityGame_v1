using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove2D : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpSpeed = 1;

    private Rigidbody2D _rigidbody;
    private bool push = false;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
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

        if (!push)
        {
            var movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
                _rigidbody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            }

            Vector3 characterScale = transform.localScale;
            if (Input.GetAxis("Horizontal") < 0)
            {
                characterScale.x = 1.2f;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                characterScale.x = -1.2f;
            }
            transform.localScale = characterScale;
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