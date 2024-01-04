using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] float speedCoefficient = 3f;
    [SerializeField] float jumpSpeed = 4f;
    Vector2 moveInput;
    Rigidbody2D playerRigidBody;
    Animator playerAnimator;
    CapsuleCollider2D playerCollider;

    void Start() {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update() {
        Run();
        FlipSprite();
    }

    void Run() {
        Vector2 playerVelocity = new Vector2(moveInput.x * speedCoefficient, playerRigidBody.velocity.y);
        playerRigidBody.velocity = playerVelocity;
        bool isPlayerMovingHorizontally = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", isPlayerMovingHorizontally);
    }

    void FlipSprite() {
        bool isPlayerMovingHorizontally = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;
        if(isPlayerMovingHorizontally)
            transform.localScale = new Vector2(Mathf.Sign(playerRigidBody.velocity.x), transform.localScale.y);
    }

    void OnMove(InputValue inputValue) {
        moveInput = inputValue.Get<Vector2>();
        Debug.Log("Running: " + moveInput);
    }

    void OnJump(InputValue inputValue) {
        Debug.Log("Jumping: " + inputValue.Get<float>());
        bool isJumpable = inputValue.isPressed && playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Debug.Log("inputValue.isPressed: " + inputValue.isPressed);
        Debug.Log("playerCollider.IsTouchingLayers(LayerMask.GetMask(\"Ground\"): " + playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")));
        Debug.Log("isJumpable: " + isJumpable);
        if(isJumpable) {
            playerRigidBody.velocity += new Vector2(0f, jumpSpeed);
        }
    }
}
