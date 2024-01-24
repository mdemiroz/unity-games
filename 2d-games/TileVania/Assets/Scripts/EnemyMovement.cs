using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float enemyMoveSpeed = 1f;
    Rigidbody2D enemyRigidBody;

    void Start() {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        enemyRigidBody.velocity = new Vector2(enemyMoveSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("OnTriggerEnter2D is called by: " + other.name);
        enemyMoveSpeed = -enemyMoveSpeed;
        FlipEnemy();
    }

    void FlipEnemy() {
        transform.localScale = new Vector2(-Mathf.Sign(enemyRigidBody.velocity.x), transform.localScale.y);
    }
}
