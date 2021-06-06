using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the interactions with the Tony NPC
public class TonyController : TextController
{
    private bool tonyConvo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, playerObj.transform.position) < 4 && !dialogueController.convoInitialized)
        {
            talkText.gameObject.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                dialogueController.convoInitialized = true;
                tonyConvo = true;
                InitializeConvo();
            }
        }
        else
        {
            talkText.gameObject.SetActive(false);
        }

        if (dialogueController.convoStarted && tonyConvo && Input.GetKeyDown("enter"))
        {
            dialogueController.DisplayNextSentence();
        }

        if(!dialogueController.convoStarted && tonyConvo)
        {
            EndConvo();
        }
    }

    public override void EndConvo()
    {
        tonyConvo = false;
        player.coins += 10;
        print("Good Riddance");
    }
}
