using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    private Player player;
    public GameObject sword;
    private GameObject temp;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = transform.position;
            pos = new Vector2(transform.position.x + 2, transform.position.y);
            temp = (GameObject)Instantiate(sword, pos, Quaternion.identity);
            animator.SetBool("isAttacking", true);

            Invoke("FinishAttack", 0.9f);
        }
    }

    private void FinishAttack()
    {
        Destroy(temp);
        animator.SetBool("isAttacking", false);
    }
}
