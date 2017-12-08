using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorC : MonoBehaviour {
    public bool isJumping;
    private Rigidbody2D enemyCRigidbody;
    public float speed = 0.1f;
    public float jumpForce = 200.0f;
    public bool hitStage;

    // Use this for initialization
    void Start()
    {
        enemyCRigidbody = GetComponent<Rigidbody2D>();
        isJumping = true;
        hitStage = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
        if (isJumping)
        {
            enemyCRigidbody.constraints = RigidbodyConstraints2D.FreezeAll ^ RigidbodyConstraints2D.FreezePositionY;  // Unfreeze Y
            enemyCRigidbody.AddForce(new Vector2(0.0f, jumpForce));
        }
        if (this.transform.position.x <= -1.88)
        {
            enemyCRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            this.name = "Enemy H";

        }
        isJumping = false;

        if(hitStage == true)
        {
            //this.name = "Enemy H";
        }
    }
}
