using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
#region Public Variables
    public float attackDistance; // Minimum distance for attack
    public float moveSpeed;
    public float timer; // Timer for cooldown between attacks
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector]
    public Transform target;
    [HideInInspector]
    public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    public Transform playerBird;
    public Consumable _consumable;
    public GameObject _EATME;
    public float force = 200; // How much to throw player backwards
#endregion

#region Private Variables
    private Animator anim = default;
    private float distance = default; // Stores distance b/w Enemy and Player
    private bool attackMode = default;
    private bool onCooldown = default; // Check if Enemy is in cooldown after attack
    private float intTimer = default;
    private BirdGirth _birdGirth = default;
#endregion

    private static HashSet<EnemyBehavior> _currentEnemies = new HashSet<EnemyBehavior>();
    public static IEnumerable<EnemyBehavior> CurrentEnemies => _currentEnemies;

    void Awake()
    {
        SelectTarget();
        intTimer = timer; // Store the initial value of timer
        anim = GetComponent<Animator>();
        _birdGirth = playerBird.GetComponent<BirdGirth>();
    }

    void OnEnable() => _currentEnemies.Add(this);
    void OnDisable() => _currentEnemies.Remove(this);

    // Update is called once per frame
    void Update()
    {
        if (!attackMode)
        {
            Move();
        }

        if (
            !InsideofLimits() &&
            !inRange &&
            !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack.anim")
        )
        {
            SelectTarget();
        }

        intTimer -= Time.deltaTime;
        onCooldown = intTimer >= 0;

        if (inRange)
        {
            EnemyLogic();
        }

        _EATME.SetActive(_birdGirth.currentHealth >= _consumable.RequiredGirthToConsume);

    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance && !onCooldown)
        {
            Attack();
        }

        if (!onCooldown)
        {
            anim.SetBool("canAttack", false);
        }
    }

    // Enemy Move Functions
    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack.anim"))
        {
            Vector2 targetPosition =
                new Vector2(target.position.x, transform.position.y);

            transform.position =
                Vector2
                    .MoveTowards(transform.position,
                    targetPosition,
                    moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        intTimer = timer; // Reset Timer when Player enter Attack Range
        attackMode = true; // To check if Enemy can still attack or not

        anim.SetBool("canWalk", false);
        anim.SetBool("canAttack", true);

        // Calculate Angle Between the collision point and the player
        var collider = triggerArea.GetComponent<Collider2D>();
        Vector3 closestPoint = collider.ClosestPoint(playerBird.position);
        Vector3 dir = (playerBird.position - transform.position).normalized;

        _birdGirth = playerBird.GetComponent<BirdGirth>();
        // Only do Attack stuff if the bird is small and WEAK. 
        if(_birdGirth.currentHealth < _consumable.RequiredGirthToConsume)
        {
            // Add force in direction of dir and multiply by force
            // Push back that boiiiii
            playerBird.GetComponent<Rigidbody2D>().AddForce(dir * force);


            // AFFECT PLAYER GIRTH
            playerBird.GetComponent<BirdGirth>().TakeDamage(5);
        }
    }

    void StopAttack()
    {
        attackMode = false;
        anim.SetBool("canAttack", false);
    }

    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x &&
        transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft =
            Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight =
            Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }

        transform.eulerAngles = rotation;
    }
}
