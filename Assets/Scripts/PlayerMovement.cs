using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float x, z;
    public int speed = 5;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = SimpleInput.GetAxis("Horizontal");
        z = SimpleInput.GetAxis("Vertical"); 
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(x, 0, z) * speed;
    }
}
