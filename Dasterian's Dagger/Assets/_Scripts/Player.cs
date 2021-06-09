using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float dmg;
    private bool isDead = false;

    public int coins = 0;
    public Text coinText;
    public bool immune;

    public HealthSystem healthSystem;
    private SceneLoader sceneloader;
    private CharMove2D playerMovement;

    AudioSource audioData;
    public AudioClip clip;

    void Awake()
    {
        sceneloader = GameObject.Find("SceneManager").GetComponent<SceneLoader>();
        playerMovement = this.GetComponent<CharMove2D>();
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

        if (transform.position.y < -15f || healthSystem.health <= 0)
        {
            deathReset();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
            coins++;
        }

        if (other.gameObject.CompareTag("Diamonds"))
        {
            Destroy(other.gameObject);
            coins = coins + 5;
        }

        if (other.gameObject.CompareTag("EnemyTroll") && !immune)
        {
            healthSystem.damagePlayer(1);

            if (this.transform.position.x < other.transform.position.x)
            {
                playerMovement.basicKnockbackLeft(5);
            }
            else
            {
                playerMovement.basicKnockbackRight(5);
            }
        }

        if (other.gameObject.CompareTag("EagleMiniBoss") && !immune)
        {
            healthSystem.damagePlayer(1);

            if (this.transform.position.x < other.transform.position.x)
            {
                playerMovement.basicKnockbackLeft(10);
            }
            else
            {
                playerMovement.basicKnockbackRight(10);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.name.Equals("Platform")){
            this.transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.name.Equals("Platform")){
            this.transform.parent = null;
        }
    }

    private void deathReset()
    {
        healthSystem.health = 3;
        sceneloader.LoadDeathScreen();
    }
}
