using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBossController : MonoBehaviour
{
    public GameObject[] path;
    private int index = 0;
    private float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, path[index].transform.position, step);

        if (transform.position.x == path[index].transform.position.x)
        {
            if(index == 11)
            {
                index = 0;
            }
            if (index == 2 || index == 9)
            {
                Vector2 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
                index++;
        }
    }
}
