using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorA : MonoBehaviour
{
	private Rigidbody2D rigidbody;
	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.AddForce(new Vector2(-500.0f, 0.0f));
		rigidbody.AddTorque(Random.Range(20.0f, 200.0f));

		player = GameObject.Find("Rocker Dude");

		// TODO: Add physics here to make the enemy's arc intercept the player's, regardless of y-position
		rigidbody.AddForce(new Vector2(0.0f, 400.0f));
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
