using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private GameObject player;
    private DialogueController dialogueController;
    

    public GameObject talkText;
    public Dialogue dialogue;
    
    void Awake()
    {
        player = GameObject.Find("Player");
        talkText.gameObject.SetActive(false);
        dialogueController = FindObjectOfType<DialogueController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 4 && !dialogueController.convoInitialized)
        {
            talkText.gameObject.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                dialogueController.convoInitialized = true;
                InitializeConvo();
            }    
        }
        else
        {
            talkText.gameObject.SetActive(false);
        }

        if(dialogueController.convoStarted && Input.GetKeyDown("space"))
        {
            dialogueController.DisplayNextSentence();
        }
    }

    private void InitializeConvo()
    {
        dialogueController.StartDialogue(dialogue);
    }
    public static void EndConvo()
    {

    }
}
