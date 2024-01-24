using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float jumpSpeed = 4f;
    [SerializeField] float climbSpeed = 3f;
    Vector2 moveInput;
    Rigidbody2D playerRigidBody;
    Animator playerAnimator;
    CapsuleCollider2D playerBodyCollider;
    BoxCollider2D playerFeetCollider;
    float normalGravity;
    bool isAlive;
    [SerializeField] Vector2 deathKick;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    void Start() {
        isAlive = true;
        deathKick = new Vector2(10f, 10f);
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
        normalGravity = playerRigidBody.gravityScale;
        Debug.Log("Initial normalGravity: " + normalGravity);
    }

    void Update() {
        if(isAlive) {
            Run();
            FlipSprite();
            ClimbLatter();
        }
        Die();
    }

    void Die() {
        bool hasTouchedEnemy = playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards"));
        if(hasTouchedEnemy) {
            isAlive = false;
            playerAnimator.SetTrigger("dying");
            playerRigidBody.velocity = deathKick;
        }
    }

    void Run() {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, playerRigidBody.velocity.y);
        playerRigidBody.velocity = playerVelocity;
        bool isPlayerMovingHorizontally = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;

        // set running animation
        playerAnimator.SetBool("isRunning", isPlayerMovingHorizontally);
    }

    void FlipSprite() {
        bool isPlayerMovingHorizontally = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;
        if(isPlayerMovingHorizontally)
            transform.localScale = new Vector2(Mathf.Sign(playerRigidBody.velocity.x), transform.localScale.y);
    }

    void ClimbLatter() {
        bool isClimbable = playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"));
        if(!isClimbable) {
            playerAnimator.SetBool("isClimbing", false);
            playerRigidBody.gravityScale = normalGravity;
            // Debug.Log("playerRigidBody.gravityScale is set to = " + normalGravity);
            return;
        }

        // set gravity = 0 when on latter
        playerRigidBody.gravityScale = 0f;
        Debug.Log("playerRigidBody.gravityScale is set to = " + playerRigidBody.gravityScale + " and normalGravity = " + normalGravity);

        // set y-axis movement
        Vector2 climbVelocity = new Vector2(playerRigidBody.velocity.x, moveInput.y * climbSpeed);
        playerRigidBody.velocity = climbVelocity;

        bool isPlayerClimbing = isClimbable && Mathf.Abs(playerRigidBody.velocity.y) > Mathf.Epsilon;
        Debug.Log("isPlayerClimbing: " + isPlayerClimbing);
        Debug.Log("isClimbable: " + isClimbable);
        Debug.Log("Mathf.Abs(playerRigidBody.velocity.y): " + Mathf.Abs(playerRigidBody.velocity.y));
        // set climbing animation
        playerAnimator.SetBool("isClimbing", isPlayerClimbing);
    }

    void OnFire(InputValue inputValue) {
        if(!isAlive) return;
        // 1st param what we are spawning, 2nd param where we are spawning
        Instantiate(bullet, gun.position, transform.rotation);
    }

    void OnMove(InputValue inputValue) {
        moveInput = inputValue.Get<Vector2>();
        Debug.Log("Running: " + moveInput);
    }

    void OnJump(InputValue inputValue) {
        Debug.Log("Jumping: " + inputValue.Get<float>());
        bool isJumpable = inputValue.isPressed && playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Debug.Log("inputValue.isPressed: " + inputValue.isPressed);
        Debug.Log("playerCollider.IsTouchingLayers(LayerMask.GetMask(\"Ground\"): " + playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")));
        Debug.Log("isJumpable: " + isJumpable);
        if(isJumpable) {
            playerRigidBody.velocity += new Vector2(0f, jumpSpeed);
        }
    }
}
