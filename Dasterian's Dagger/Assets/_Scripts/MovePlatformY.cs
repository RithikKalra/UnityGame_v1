using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformY : MonoBehaviour
{
    public float turnPointY, turnPoint2Y;
    public float dirY, moveSpeedY = 3f;
    bool moveUp = true;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > turnPointY){
            moveUp = false;
        }
        if(transform.position.y < turnPoint2Y){
            moveUp = true;
        }

        if(moveUp){
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeedY * Time.deltaTime);
        }
        else{
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeedY * Time.deltaTime);
        }
    }
}
