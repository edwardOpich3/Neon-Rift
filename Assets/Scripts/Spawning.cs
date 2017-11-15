using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

	public int maxEnemies = 10;		// Maximum number of enemies allowed in play; if currentEnemies equals or exceeds this, no more enemies can spawn until some are destroyed.
	public float spawnTime = 2.0f;	// Seconds between each spawn. Implemented as minimum wait in seconds per spawn
	public Rect spawnZone;			// The rectangle that defines where enemies can spawn
	public GameObject[] enemies;	// List of every possible enemy or projectile to spawn.

	private int currentEnemies;		// Number of enemies currently in play
	private float currentTick;		// Time in seconds from last enemy spawn. Should it exceed spawnTime, spawning is now possible.

	// Use this for initialization
	void Start ()
	{
		currentEnemies = 0;
		currentTick = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentTick += Time.deltaTime;
		if(currentTick > spawnTime && currentEnemies < maxEnemies)
		{
			// Spawn an enemy at a random location, given our range
			Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(Random.Range(spawnZone.xMin, spawnZone.xMax), Random.Range(spawnZone.yMin, spawnZone.yMax), 0.0f), Quaternion.identity);
			currentTick = 0.0f;
			currentEnemies++;
		}
	}

	public void enemyHit()
	{
		currentEnemies--;
	}
}
