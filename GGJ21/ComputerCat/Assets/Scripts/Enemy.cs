using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial here: https://www.youtube.com/watch?v=K2SbThbGw6w
public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected GameObject player;

    protected enum State
    {
        PATROL,
        PURSUIT,
        DEAD
    }

    [SerializeField]
    [Tooltip("State of the enemy.")] protected State currentState;

    [SerializeField]
    protected float
        groundCheckDistance,
        wallCheckDistance,
        movementSpeed;//,
        //maxHealth,
        //knockbackDuration;
    [SerializeField]
    protected Transform
        groundCheck,
        wallCheck,
        playerCheck;
    [SerializeField]
    protected LayerMask whatIsGround;
    [SerializeField]
    protected LayerMask whatIsBoundary;
    //[SerializeField]
    //protected Vector2 knockbackSpeed;

    //protected float 
    //    currentHealth,
    //    knockbackStartTime;
    
    protected int facingDirection = 1;

    protected Vector2 movement;

    [SerializeField]
    protected bool
        groundDetected,
        wallDetected,
        playerDetected;

    protected GameObject alive;
    protected Rigidbody2D aliveRB;
    protected Animator aliveAnim;

    protected void Start()
    {
        alive = transform.Find("Alive").gameObject;
        aliveRB = alive.GetComponent<Rigidbody2D>();
        aliveAnim = alive.GetComponent<Animator>();
        //SwitchEnemyState(State.PATROL);
    }

    // Update is called once per frame
    void Update()
    {
        playerDetected = PlayerInRange();
        switch (currentState)
        {
            case State.PATROL:
                UpdatePatrolState();
                break;
            case State.PURSUIT:
                UpdatePursuitState();
                break;
            case State.DEAD:
                UpdateDeadState();
                break;
        }
    }

    //--PATROLLING STATE------------------------------------------------------------------------------------------------------
    protected void EnterPatrolState()
    {
        Debug.Log(name + " Entered Patrol State!");
        currentState = State.PATROL;
        aliveAnim.SetBool("patrol", true);
    }

    protected void UpdatePatrolState()
    {
        if (playerDetected)
        {
            SwitchEnemyState(State.PURSUIT);
        }
        else
        {
            PatrolMovement();
        }
    }

    protected void ExitPatrolState()
    {
        Debug.Log(name + " Exited Patrol State.");
        aliveAnim.SetBool("patrol", false);
    }

    virtual protected void PatrolMovement()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, alive.transform.right, wallCheckDistance, whatIsBoundary);
        //Debug.DrawRay(transform.position, transform.right);
        if (!groundDetected || wallDetected)
        {
            if (!groundDetected) { Debug.Log(name + ": No ground, turn around!"); }
            if (wallDetected) { Debug.Log(name + ": Oops a wall, turn around!"); }
            Flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, aliveRB.velocity.y);
            aliveRB.velocity = movement;
        }
    }

    //--PURSUIT STATE--------------------------------------------------------------------------------------------------------
    protected void EnterPursuitState()
    {
        Debug.Log(name + " Entered Pursuit State!");
        currentState = State.PURSUIT;
        aliveAnim.SetBool("pursuit", true);
    }

    protected void UpdatePursuitState()
    {
        if (!playerDetected)
        {
            SwitchEnemyState(State.PATROL);
        }
        else
        {
            PatrolMovement();
        }
    }

    protected void ExitPursuitState()
    {
        Debug.Log(name + " Exited Pursuit State.");
        aliveAnim.SetBool("pursuit", false);
    }

    //--DEAD STATE-----------------------------------------------------------------------------------------------------------
    protected void EnterDeadState()
    {
        Debug.Log(name + " Entered Death State.");
        currentState = State.DEAD;
        aliveAnim.SetBool("death", true);
    }

    protected void UpdateDeadState()
    {
        // Shouldn't need?
    }

    protected void ExitDeadState()
    {
        // Shouldn't need?
    }

    //--OTHER FUNCTIONS------------------------------------------------------------------------------------------------------
    protected void SwitchEnemyState(State newState)
    {
        switch(currentState)
        {
            case State.PATROL:
                ExitPatrolState();
                break;
            case State.PURSUIT:
                ExitPursuitState();
                break;
            case State.DEAD:
                ExitDeadState();
                break;
        }
        switch (newState)
        {
            case State.PATROL:
                EnterPatrolState();
                break;
            case State.PURSUIT:
                EnterPursuitState();
                break;
            case State.DEAD:
                EnterDeadState();
                break;
        }
    }

    protected void Flip()
    {
        //Debug.Log("Flip!");
        facingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    protected void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + (wallCheckDistance * facingDirection), wallCheck.position.y));
    }

    protected bool PlayerInRange()
    {
        return playerCheck.GetComponent<Collider2D>().OverlapPoint(player.transform.position);
    }

    //private void Damage(float[] attackDetails)
    //{

    //}
}
