using UnityEngine;

public class BirdGroundedChecker : MonoBehaviour
{
    [SerializeField] LayerMask _groundMask = default;
    [SerializeField] Transform _bottomLeft = default;
    [SerializeField] Transform _bottomRight = default;
    [SerializeField] float _skinDistance = 0.05f;

    bool _colliding = false;
    public bool IsColliding => _colliding;

    void Update()
    {
        var leftHit = Physics2D.Raycast(_bottomLeft.position, Vector2.down, _skinDistance, _groundMask);
        var rightHit = Physics2D.Raycast(_bottomLeft.position, Vector2.down, _skinDistance, _groundMask);
        _colliding = leftHit.collider != null || rightHit.collider != null;
    }
}
