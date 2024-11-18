using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    float speedX, speedY;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        //speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
        
        rb.velocity = new Vector2(speedX, 0);

    }
}
