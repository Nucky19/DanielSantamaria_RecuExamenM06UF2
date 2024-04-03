using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rBody;
    public SpriteRenderer sprite;
    public GroundSensor sensor;
    public float jumpForce = 6;
    public float movementSpeed = 3;
    private float inputHorizontal;

    void Awake(){
        rBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal=Input.GetAxis("Horizontal");
        if(inputHorizontal<0) sprite.flipX = true;
        else if(inputHorizontal>0) sprite.flipX = false;   

        if(Input.GetButtonDown("Jump") && sensor.isGrounded) rBody.AddForce(new Vector2(0,1) * jumpForce, ForceMode2D.Impulse);
    }

    void FixedUpdate(){
        rBody.velocity =  new Vector2(inputHorizontal*movementSpeed, rBody.velocity.y);
    }
}
