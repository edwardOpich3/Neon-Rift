using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start()
    {
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
		if(other.gameObject.name.Substring(0, 5) == "Enemy")
		{
			Destroy(other.gameObject);
		}
	}
}
