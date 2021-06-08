using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformX : MonoBehaviour
{
    public float turnPointX, turnPoint2X;
    public float dirX, moveSpeedX = 3f;
    bool moveRight = true;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > turnPointX){
            moveRight = false;
        }
        if(transform.position.x < turnPoint2X){
            moveRight = true;
        }

        if(moveRight){
            transform.position = new Vector2(transform.position.x + moveSpeedX * Time.deltaTime, transform.position.y);
        }
        else{
            transform.position = new Vector2(transform.position.x - moveSpeedX * Time.deltaTime, transform.position.y);
        }
    }
}
