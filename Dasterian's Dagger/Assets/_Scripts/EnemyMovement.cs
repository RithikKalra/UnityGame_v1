using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public bool MoveRight;

// Use this for initialization
	void Update () {
		// Use this for initialization
		if(MoveRight) {
			transform.Translate(2* Time.deltaTime * speed, 0,0);
			transform.localScale= new Vector2 (-1.35f, 1.35f);
 		}
		else{
			transform.Translate(-2* Time.deltaTime * speed, 0,0);
			transform.localScale= new Vector2 (1.35f,1.35f);
		}
	}
	void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.CompareTag("Turn")){

			if (MoveRight){
				MoveRight = false;
			}
			else{
				MoveRight = true;
			}	
		}
	}

	public void Hurt()
	{
		Destroy(this.gameObject);
	}
}
