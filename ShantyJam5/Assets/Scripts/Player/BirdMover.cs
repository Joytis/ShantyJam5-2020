using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class BirdMover : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D _rigidbody = null;
    [SerializeField] 
    private float _birdLateralSpeed = 500.0f;
    [SerializeField]
    private float _birdVerticalSpeed = 1200.0f;
    void FixedUpdate()
    {   
        // PLAYER MOVEMENT
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidbody.AddForce(new Vector2(input.x, 0f) * Time.deltaTime * _birdLateralSpeed);
        _rigidbody.AddForce(new Vector2(0f, input.y) * Time.deltaTime * _birdVerticalSpeed);
    }

}
