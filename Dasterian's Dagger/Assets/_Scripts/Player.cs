using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float dmg;
    private float health = 100;

    private bool isDead = false;

    private SceneLoader sceneloader;

    void Awake()
    {
        sceneloader = GameObject.Find("SceneManager").GetComponent<SceneLoader>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -15f || health < 0)
        {
            deathReset();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Coins")){
            Destroy(other.gameObject);
        }
    }

    private void deathReset()
    {
        health = 100;
        sceneloader.LoadDeathScreen();
    }
}
