using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject livesText;

    public int maxEnemies = 10;		// Maximum number of enemies allowed in play; if currentEnemies equals or exceeds this, no more enemies can spawn until some are destroyed.
	public float spawnTime = 2.0f;	// Seconds between each spawn. Implemented as minimum wait in seconds per spawn
	public Rect spawnZone;			// The rectangle that defines where enemies can spawn
	public GameObject[] enemies;	// List of every possible enemy or projectile to spawn.
	public int health = 3;			// Remaining HP. If the player being hit drops it to 0, the player is destroyed.

	private int currentEnemies;		// Number of enemies currently in play
	private float currentTick;		// Time in seconds from last enemy spawn. Should it exceed spawnTime, spawning is now possible.
	private int score;				// Current score. Currently represented via enemies destroyed.

	// Use this for initialization
	void Start ()
	{
		currentEnemies = 0;
		currentTick = 0.0f;
		score = 0;
        livesText.GetComponent<TextMesh>().text = "Lives: " + health;
        scoreText.GetComponent<TextMesh>().text = "Score: " + getScore();

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

	// Updates the currentEnemies count, as well as the score.
	public void enemyHit()
	{
		currentEnemies--;
		score++;

		// Currently only here to demonstrate the scoring works. Delete before final release!
		Debug.Log(score);
        changeScore();

    }

    // Subtracts 1 HP from the player. Returns whether or not the player is still alive.
    public bool playerHit()
	{
		health--;

		Debug.Log("HP Remaining: " + health);
        changeLives();

        return health > 0;
	}

	// Returns the current score.
	public int getScore()
	{
		return score;
	}

    public void changeScore()
    {
        scoreText.GetComponent<TextMesh>().text = "Score: " + getScore()*10;
    }

    public void changeLives()
    {
        livesText.GetComponent<TextMesh>().text = "Lives: " + health;
    }
}
