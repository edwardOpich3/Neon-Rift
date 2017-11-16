using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 0.1f;

	private Spawning spawning;

	// Use this for initialization
	void Start ()
	{
		spawning = GameObject.Find("Game Manager").GetComponent<Spawning>();
	}
	
	// Update is called once per frame
	void Update () {
        
		if(Input.GetKey(KeyCode.W))
        {
			transform.Translate(new Vector3(0.0f, speed, 0.0f));

			if(Camera.main.WorldToViewportPoint(transform.position).y > 1)
			{
				transform.Translate(0.0f, -speed, 0.0f);
			}
        }
        else if(Input.GetKey(KeyCode.S))
        {
			transform.Translate(new Vector3(0.0f, -speed, 0.0f));

			if(Camera.main.WorldToViewportPoint(transform.position).y < 0)
			{
				transform.Translate(0.0f, speed, 0.0f);
			}
        }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name.Substring(0, 5) == "Enemy")
		{
			// Replace this with whatever should happen when the player gets hit by an enemy!
			if(!spawning.playerHit())
			{
				Destroy(gameObject);
			}
		}
	}
}
