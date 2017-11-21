using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject bullet;
	public GameObject godBullet;
    public GameObject player;

	public float shootRate = 2.0f;		// How many bullets can the player shoot per second?

	public bool isRockOn;				// Is the rock on meter currently draining?
	public bool isRockGod;				// Is the rock GOD meter currently draining?

	private Spawning spawning;

	private float shootTimer;			// How long has passed since last shot?
	private bool canShoot;				// Can the player currently shoot?

	// Use this for initialization
	void Start ()
    {
		shootTimer = 0.0f;
		canShoot = true;
		isRockOn = false;
		isRockGod = false;

		spawning = GameObject.Find("Game Manager").GetComponent<Spawning>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown("space") && (canShoot || isRockOn || isRockGod))
        {
			if(!isRockGod)
			{
            	GameObject clone = Instantiate(bullet, player.transform.position, Quaternion.identity);
			}
			else
			{
				GameObject clone = Instantiate(godBullet, new Vector3(player.transform.position.x, 0.0f, 0.0f), Quaternion.identity);
				spawning.godBulletFired();
			}

			shootTimer = 0.0f;
			canShoot = false;
        }

		shootTimer += Time.deltaTime;
		if(shootTimer >= (1.0f / shootRate))
		{
			canShoot = true;
		}

		// Activate Rock ON meter if it's full and the player hits C
		if(Input.GetKeyDown(KeyCode.C) && spawning.getRockOn() == 1.0f && !isRockGod)
		{
			isRockOn = true;
		}
		else if(spawning.getRockOn() == 0.0f)
		{
			isRockOn = false;
		}

		// Activate God mode if the Rock GOD meter is full and the player hits V
		if(Input.GetKey(KeyCode.V) && spawning.getRockGod() == 1.0f && !isRockOn)
		{
			isRockGod = true;
		}
		else if(spawning.getRockGod() == 0.0f)
		{
			isRockGod = false;
		}
    }
}
