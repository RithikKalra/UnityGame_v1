using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float dmg;
    private float health = 100;

    public int coins = 0;
    public Text coinText;

    private bool isDead = false;
    

    private SceneLoader sceneloader;

    AudioSource audioData;
    public AudioClip clip;


    void Awake()
    {
        sceneloader = GameObject.Find("SceneManager").GetComponent<SceneLoader>();
        audioData = GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coins < 10)
            coinText.text = "0" + coins.ToString();
        else
            coinText.text = coins.ToString();

        if (transform.position.y < -15f || health < 0)
        {
            deathReset();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Coins")){
            Destroy(other.gameObject);
            coins++;
        }

        if(other.gameObject.CompareTag("Diamonds")){
            Destroy(other.gameObject);
            coins = coins + 5;
        }
    }

    private void deathReset()
    {
        health = 100;
        sceneloader.LoadDeathScreen();
    }
}
