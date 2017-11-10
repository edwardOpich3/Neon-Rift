using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorB : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector3 pos;
    public float speed;
    public float frequency;
    public float magnitude;
    private Vector3 axis;


    // Use this for initialization
    void Start ()
    {
        pos = transform.position;
        axis = transform.up;
        //rigidbody = GetComponent<Rigidbody2D>();
        //rigidbody.AddForce(new Vector2(-500.0f, 400.0f));
    }

// Update is called once per frame
void Update ()
    {
        pos -= transform.right * Time.deltaTime * speed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
