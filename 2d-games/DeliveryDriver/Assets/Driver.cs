using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    /*
     * float değerlerin sonuna f koymazsak unity kızıyor,
     * ancak tam değerlerse koymayabiliyoruz.
     * e.g. float speed = 1;
     */
    [SerializeField] float steerSpeed = 150.0f;
    [SerializeField] float moveSpeed = 15.0f;
    // serializeField is used to import moveSpeed to Unity.
    // Start is called before the first frame update
    
    [SerializeField] float slowedSpeed = 10.0f;
    [SerializeField] float boostedSpeed = 20.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        steerAmount = steerAmount * -1;
        // Debug.Log(steerAmount);
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // Debug.Log(moveAmount);
        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
       moveSpeed = slowedSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Boost") {
            Debug.Log("Movement speed is boosted.");
            moveSpeed = boostedSpeed;
       }
    }
}
