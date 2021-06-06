using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles the interactions with all signs/labels
public class SignController : TextController
{
    public bool signConvo = false;
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
                signConvo = true;
                InitializeConvo();
            }
        }
        else
        {
            talkText.gameObject.SetActive(false);
        }

        if (dialogueController.convoStarted && signConvo && Input.GetKeyDown("enter"))
        {
            dialogueController.DisplayNextSentence();
        }

        if (!dialogueController.convoStarted && signConvo)
        {
            EndConvo();
        }
    }

    public override void EndConvo()
    {
        signConvo = false;
        print("WTF");
    }
    
}
