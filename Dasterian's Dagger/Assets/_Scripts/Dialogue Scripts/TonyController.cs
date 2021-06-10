using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the interactions with the Tony NPC
public class TonyController : TextController
{
    private bool tonyConvo = false;
    private int limitedCoins = 1;
    private CharMove2D thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<CharMove2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, playerObj.transform.position) < 4 && !dialogueController.convoInitialized)
        {
            talkText.gameObject.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                thePlayer.canMove = false;
                dialogueController.convoInitialized = true;
                tonyConvo = true;
                InitializeConvo();
            }
        }
        else
        {
            talkText.gameObject.SetActive(false);
        }

        if (dialogueController.convoStarted && tonyConvo && (Input.GetKeyDown("enter") || Input.GetKeyDown("return")))
        {
            dialogueController.DisplayNextSentence();
        }

        if(!dialogueController.convoStarted && tonyConvo)
        {
            EndConvo();
            if(limitedCoins > 0)
            {
                player.coins += 10;
                limitedCoins--;
            }
        }
    }

    public override void EndConvo()
    {
        thePlayer.canMove = true;
        tonyConvo = false;
    }
}
