using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonyController : MonoBehaviour
{
    private GameObject player;
    private bool keyPressed = false;

    public GameObject talkText;
    
    void Awake()
    {
        player = GameObject.Find("Player");
        talkText.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 4 && !keyPressed)
        {
            talkText.gameObject.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                keyPressed = true;
                TonyConvo();
            }    
        }
        else
        {
            talkText.gameObject.SetActive(false);
        }
    }

    private void TonyConvo()
    {
        print("Hello");
    }
}
