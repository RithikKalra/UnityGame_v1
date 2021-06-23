using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBossController : MonoBehaviour
{
    public GameObject[] path;

    public GameObject eagleUI;
    public GameObject playerAttack;
    public GameObject playerObj;
    public Player player;
    public HealthBarController healthBar;
    public Transform diamond;

    private int index = 0;
    private float speed = 10f;
    private bool isAttacked = false;

    private CharacterStats eagleStats;

    // Start is called before the first frame update
    void Start()
    {
        eagleStats = this.GetComponent<CharacterStats>();
        healthBar.SetMaxHealth(eagleStats.health);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerObj.transform.position) < 30)
           eagleUI.gameObject.SetActive(true);
        else
           eagleUI.gameObject.SetActive(false);

        if (transform.position.x - playerObj.transform.position.x > -3 && transform.position.x - playerObj.transform.position.x < 3 && playerObj.transform.position.y > transform.position.y && !player.immune)
        {
            playerAttack.gameObject.SetActive(true);
            if (Input.GetKeyDown("space"))
            {
                isAttacked = true;
                player.immune = true;
                Invoke("AttackEagle", 0.1f);
            }
        }
        else
        {
            playerAttack.gameObject.SetActive(false);
        }

        if (!isAttacked)
            EagleMovement();
        else
            Invoke("EagleMovement", 2);

        if (eagleStats.health <= 0)
        {
            Vector2 pos = transform.position;

            for(int i = 0; i < 5; i++)
            {
                pos = new Vector2(transform.position.x + i*2, transform.position.y + 1);
                Instantiate(diamond, pos, Quaternion.identity);
            }
            
            playerAttack.gameObject.SetActive(false);
            eagleUI.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            healthBar.SetHealth(eagleStats.health);
        }
    }

    private void AttackEagle()
    {
        
        playerObj.transform.position = new Vector2(transform.position.x, transform.position.y + 2);

        do
        {
            Vector2 pTransform = playerObj.transform.position;
            pTransform.y -= 1;
            playerObj.transform.position = pTransform;

            Vector2 eTransform = transform.position;
            eTransform.y -= 1;
            transform.position = eTransform;

        } while (transform.position.y > -2);
      
         eagleStats.health -= 50;
         healthBar.SetHealth(eagleStats.health);

        if(eagleStats.health < 25)
        {
             speed = 20f;
        }
    }

    private void EagleMovement()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, path[index].transform.position, step);

        if (transform.position.x == path[index].transform.position.x)
        {
            if (index == 11)
            {
                index = 0;
            }
            if (index == 2 || index == 9)
            {
                Vector2 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            index++;
        }
        isAttacked = false;
        player.immune = false;
    }
}
