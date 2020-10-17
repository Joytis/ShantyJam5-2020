using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class BirdMover : MonoBehaviour
{

    [SerializeField] Rigidbody2D _rigidbody = null;
    [SerializeField] float _birdLateralSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {   
        //HORIZONTAL MOVEMENT
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        _rigidbody.AddForce(new Vector2(horizontalMovement, 0f) * Time.deltaTime * _birdLateralSpeed);
        //VERTICAL MOVEMENT
        float verticalMovement = Input.GetAxisRaw("Vertical");
        _rigidbody.AddForce(new Vector3(0f, verticalMovement) * Time.deltaTime * _birdLateralSpeed * 5);
    }

}
