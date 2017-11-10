using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorA : MonoBehaviour
{
	private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.AddForce(new Vector2(-500.0f, 400.0f));
		rigidbody.AddTorque(25.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
