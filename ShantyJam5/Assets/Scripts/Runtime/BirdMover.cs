using UnityEngine;

public class BirdMover : MonoBehaviour
{

    [SerializeField] 
    private Rigidbody2D _rigidbody = null;
    [SerializeField] 
    private float _birdLateralSpeed = 500.0f;
    [SerializeField]
    private float _birdVerticalSpeed = 1200.0f;

    [SerializeField] 
    private BirdDisplay _birdDisplay = null;

    void FixedUpdate()
    {   
        // PLAYER MOVEMENT
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidbody.AddForce(new Vector2(input.x, 0f) * Time.deltaTime * _birdLateralSpeed);
        _rigidbody.AddForce(new Vector2(0f, input.y) * Time.deltaTime * _birdVerticalSpeed);

        if(!Mathf.Approximately(input.x, 0))
        {
            bool leftOrRight = input.x <= 0f;
            _birdDisplay.transform.localScale = new Vector3(leftOrRight ? 1f : -1f, 1f, 1f);
        }

        // Using the movement, try and figure out our animation state!
        // NOTE(clark): This is usually done in a state machine, but it'll be fine by just checking values here. 
        Vector2 velocity = _rigidbody.velocity;
        bool noHorizontal = Mathf.Approximately(velocity.x, 0f);
        bool noVertical = Mathf.Approximately(velocity.y, 0f);
        _birdDisplay.UpdateDisplay(_rigidbody);
    }
}
