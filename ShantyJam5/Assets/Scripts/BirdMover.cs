using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMover : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody = null;
    [SerializeField] float _birdLateralSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveRight()
    {
        _rigidbody.AddForce(new Vector2(_birdLateralSpeed, _birdLateralSpeed) * Time.deltaTime);
    }
}
