using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] float speedCoefficient = 3f;
    Vector2 moveInput;
    Rigidbody2D playerRigidBody;

    void Start() {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Run();
        FlipSprite();
    }

    void Run() {
        Vector2 playerVelocity = new Vector2(moveInput.x * speedCoefficient, playerRigidBody.velocity.y);
        playerRigidBody.velocity = playerVelocity;
    }

    void FlipSprite() {
        bool isPlayerMovingHorizontally = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;
        if(isPlayerMovingHorizontally)
            transform.localScale = new Vector2(Mathf.Sign(playerRigidBody.velocity.x), transform.localScale.y);
    }

    void OnMove(InputValue inputValue) {
        moveInput = inputValue.Get<Vector2>();
        Debug.Log(moveInput);
    }
}
