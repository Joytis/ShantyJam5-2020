using UnityEngine;

public class BirdDisplay : MonoBehaviour
{
    enum States
    {
        Idle,
        Walking,
        Jumping,
        Falling,
    }

    enum Triggers
    {
        Grounded,
        Airborne,
        Movement,
        NoMovement,
        NovVerticalMovement,
    }

    FiniteStateMachine<States, Triggers> _fsm = new FiniteStateMachine<States, Triggers>(States.Idle);

    [SerializeField] 
    private Animator _animator = null;

    [SerializeField] 
    private BirdGroundedChecker _groundChecker = null;

    void Awake() 
    {
        _fsm.AddState(States.Idle, new State() { enter = () => _animator.Play("Idle") });
        _fsm.AddState(States.Walking, new State() { enter = () => _animator.Play("Walking") });
        _fsm.AddState(States.Jumping, new State() { enter = () => _animator.Play("Jumping") });
        _fsm.AddState(States.Falling, new State() { enter = () => _animator.Play("Jumping") });

        _fsm.AddTransition(States.Idle, States.Jumping, Triggers.Airborne);
        _fsm.AddTransition(States.Idle, States.Walking, Triggers.Movement);

        _fsm.AddTransition(States.Walking, States.Jumping, Triggers.Airborne);
        _fsm.AddTransition(States.Walking, States.Idle, Triggers.NoMovement);

        _fsm.AddTransition(States.Jumping, States.Falling, Triggers.NovVerticalMovement);
        _fsm.AddTransition(States.Jumping, States.Walking, Triggers.Grounded);

        _fsm.AddTransition(States.Falling, States.Walking, Triggers.Grounded);
    }

    public void UpdateDisplay(Rigidbody2D rigidbody)
    {
        var velocity = rigidbody.velocity;

        var isMovingHorizontally = Mathf.Abs(velocity.x) <= 0.05f; 
        if(isMovingHorizontally) _fsm.SetTrigger(Triggers.NoMovement);
        else _fsm.SetTrigger(Triggers.Movement);

        if(velocity.y <= 0f) _fsm.SetTrigger(Triggers.NovVerticalMovement);

        if(_groundChecker.IsColliding) _fsm.SetTrigger(Triggers.Grounded);
        else _fsm.SetTrigger(Triggers.Airborne);
    }

    void Update() 
    {
        _fsm.Update(Time.deltaTime);
        Debug.Log(_fsm.CurrentState);
    }

}
