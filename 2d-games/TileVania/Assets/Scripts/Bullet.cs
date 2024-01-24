using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D bulletRb;
    [SerializeField] float bulletSpeed = 20f;
    PlayerMovement player;
    float bulletDirectionalSpeed;

    void Start() {
        bulletRb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        bulletDirectionalSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update() {
        bulletRb.velocity = new Vector2(bulletDirectionalSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy")
            Destroy(other.gameObject);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
