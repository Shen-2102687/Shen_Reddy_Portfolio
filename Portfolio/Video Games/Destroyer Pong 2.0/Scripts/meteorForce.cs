using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorForce : MonoBehaviour

{
    public Rigidbody2D rbMeteor;
    public float mForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(0, -1);
        rbMeteor.AddForce(movement * mForce);
        rbMeteor.velocity = mForce * (rbMeteor.velocity.normalized);
    }
}
