using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public float speed;

	private float[] pitches = { 1f/1f, 9f/8f, 6f/5f, 4f/3f, 3f/2f, 8f/5f, 16f/9f, 2f/1f };	// The pitches at which the note can ring while still sounding good
	// From left to right: Tonic, Major 2nd, Minor 3rd, Perfect 4th, Perfect 5th, Minor 6th, Minor 7th, Octave

	private Spawning spawning;
	private AudioSource myAudio;

    // Use this for initialization
    void Start()
    {
		spawning = GameObject.Find("Game Manager").GetComponent<Spawning>();
		myAudio = GetComponent<AudioSource>();

		// Randomly pull this bullet's note from the list of valid pitches
		myAudio.pitch = pitches[Random.Range(0, pitches.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);

        if (Camera.main.WorldToViewportPoint(transform.position).x > 1)
        {
            Destroy(gameObject);
        }
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		// Bullets destroy enemies, but they don't destroy enemy A, which is a projectile
		if(other.gameObject.name.Substring(0, 5) == "Enemy" && other.gameObject.name[6] != 'A')
		{
			Destroy(other.gameObject);
			spawning.enemyHit();
			Destroy(gameObject);
		}
	}
}
