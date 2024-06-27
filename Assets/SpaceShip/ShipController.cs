using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    public float speed, horizontalSpeed, verticalSpeed, maxSpeed, smoothTime;
    private float xMov, yMov, zMov, zVelocity = 0.0f, breakValue = 65, rotationSpeed = 100.0f;
    Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xMov = -Input.GetAxisRaw("Horizontal");
        yMov = Input.GetAxisRaw("Vertical");
        zMov = 0.0f;
        
        if(Input.GetKey(KeyCode.LeftShift)) zMov = -1.0f;
        if(Input.GetKey(KeyCode.Space)) zMov = 1.0f;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector3(xMov * horizontalSpeed, yMov * verticalSpeed, -speed + zMov * breakValue), ref velocity, smoothTime);

        transform.Rotate(Vector3.forward, xMov * rotationSpeed * Time.deltaTime);
    }
}
