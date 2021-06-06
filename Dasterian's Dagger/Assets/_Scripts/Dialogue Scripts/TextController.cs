using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Superclass for all text/dialogue inherited objects
public abstract class TextController : MonoBehaviour
{
    public GameObject playerObj;
    public Player player;
    public DialogueController dialogueController;
    

    public GameObject talkText;
    public Dialogue dialogue;
    
    void Awake()
    {
        talkText.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    public void Update()
    {
        
    }
    public void InitializeConvo()
    {
        dialogueController.StartDialogue(dialogue);
    }
    public abstract void EndConvo();
}
