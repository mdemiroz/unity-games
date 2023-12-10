using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostAmount = 30f;
    [SerializeField] float baseAmount = 20f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    public bool isKeysDisabled;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        isKeysDisabled = false;
    }

    void Update() {
        if(!isKeysDisabled) {
            RotatePlayer();
            BoostSpeed();
        }
    }

    private void BoostSpeed() {
        if(Input.GetKey(KeyCode.W))
            surfaceEffector2D.speed = boostAmount;
        else
            surfaceEffector2D.speed = baseAmount;
    }

    private void RotatePlayer() {
        if(Input.GetKey(KeyCode.D))
            rb2d.AddTorque(torqueAmount);
        else if(Input.GetKey(KeyCode.A))
            rb2d.AddTorque(-torqueAmount);
    }
}
