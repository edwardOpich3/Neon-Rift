using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;

	public float shootRate = 2.0f;		// How many bullets can the player shoot per second?

	private float shootTimer;			// How long has passed since last shot?
	private bool canShoot;				// Can the player currently shoot?

	// Use this for initialization
	void Start ()
    {
		shootTimer = 0.0f;
		canShoot = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space") && canShoot)
        {
            GameObject clone = Instantiate(bullet, player.transform.position, Quaternion.identity);
			shootTimer = 0.0f;
			canShoot = false;
        }

		shootTimer += Time.deltaTime;
		if(shootTimer >= (1.0f / shootRate))
		{
			canShoot = true;
		}
    }
}
