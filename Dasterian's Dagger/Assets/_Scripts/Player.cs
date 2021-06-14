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

    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider1;
    public Collider2D triggerCollider2;
    public Collider2D triggerCollider3;
    public SpriteRenderer mySprite;


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

        if (other.gameObject.CompareTag("EnemyTroll"))
        { 
            if(!immune)
            {
                healthSystem.damagePlayer(1);

                if (this.transform.position.x < other.transform.position.x)
                {
                    playerMovement.basicKnockbackLeft(3);
                }
                else
                {
                    playerMovement.basicKnockbackRight(3);
                }

                StartCoroutine(FlashCo());
            }

            
        }

        if (other.gameObject.CompareTag("EagleMiniBoss"))
        { 
            if(!immune)
            {
                healthSystem.damagePlayer(1);

                if (this.transform.position.x < other.transform.position.x)
                {
                    playerMovement.basicKnockbackLeft(3);
                }
                else
                {
                    playerMovement.basicKnockbackRight(3);
                }

                StartCoroutine(FlashCo());
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

    private IEnumerator FlashCo()
    {
        int temp = 0;
        immune = true;
        triggerCollider1.enabled = false;
        triggerCollider2.enabled = false;
        while(temp < numberOfFlashes)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        triggerCollider1.enabled = true;
        triggerCollider2.enabled = false;
        immune = false;
    }

    private void deathReset()
    {
        healthSystem.health = 3;
        sceneloader.LoadDeathScreen();
    }
    private void ResetImmunity()
    {
        immune = false;
    }
}
