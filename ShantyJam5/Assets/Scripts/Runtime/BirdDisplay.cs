using UnityEngine;

public class BirdDisplay : MonoBehaviour
{

    [SerializeField] 
    private Animator _animator;

    public void ShowFlipped(Vector2 velocity)
    {
        // Don't do anything if we're just standing still. 
        if(Mathf.Approximately(velocity.x, 0f)) return;

        // Check if we're moving left or right!
        bool leftOrRight = velocity.x < 0f;
        transform.localScale = new Vector3(leftOrRight ? 1f : -1f, 1f, 1f);
    }

    public void ShowIdle()
    {
        _animator.Play("Idle");
    }

    public void ShowWalking()
    {
        _animator.Play("Walking");
    }

    public void ShowJumping()
    {
        _animator.Play("Jumping");
    }

}
