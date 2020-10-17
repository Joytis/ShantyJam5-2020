using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMover : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody = null;
    [SerializeField] float _birdLateralSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        _rigidbody.AddForce(new Vector2(horizontalMovement, 0f) * Time.deltaTime);
    }

}
