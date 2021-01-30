using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial here: https://www.youtube.com/watch?v=K2SbThbGw6w
public class Enemy : MonoBehaviour
{
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
        wallCheck;
    [SerializeField]
    protected LayerMask whatIsGround;
    [SerializeField]
    protected LayerMask whatIsBoundary;
    //[SerializeField]
    //protected Vector2 knockbackSpeed;

    //protected float 
    //    currentHealth,
    //    knockbackStartTime;
    
    protected int facingDirection;

    protected Vector2 movement;

    protected bool
        groundDetected,
        wallDetected;

    protected GameObject alive;
    protected Rigidbody2D aliveRB;
    protected Animator aliveAnim;

    private void Start()
    {
        alive = transform.Find("Alive").gameObject;
        aliveRB = alive.GetComponent<Rigidbody2D>();
        aliveAnim = alive.GetComponent<Animator>();
        facingDirection = 1;
        //SwitchEnemyState(State.PATROL);
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
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
    private void EnterPatrolState()
    {
        Debug.Log("Entered Patrol State!");
        aliveAnim.SetBool("patrol", true);
    }

    private void UpdatePatrolState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsBoundary);
        //Debug.DrawRay(transform.position, transform.right);
        if (!groundDetected || wallDetected)
        {
            if (!groundDetected) { Debug.Log("No ground, turn around!"); }
            if (wallDetected) { Debug.Log("Oops a wall, turn around!"); }
            Flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, aliveRB.velocity.y);
            aliveRB.velocity = movement;
        }
    }

    private void ExitPatrolState()
    {
        Debug.Log("Exited Patrol State.");
        aliveAnim.SetBool("patrol", false);
    }

    //--PURSUIT STATE--------------------------------------------------------------------------------------------------------
    private void EnterPursuitState()
    {
        Debug.Log("Entered Pursuit State!");
        aliveAnim.SetBool("pursuit", true);
    }

    private void UpdatePursuitState()
    {

    }

    private void ExitPursuitState()
    {
        Debug.Log("Exited Pursuit State.");
        aliveAnim.SetBool("pursuit", false);
    }

    //--DEAD STATE-----------------------------------------------------------------------------------------------------------
    private void EnterDeadState()
    {
        Debug.Log("Entered Death State.");
        aliveAnim.SetBool("death", true);
    }

    private void UpdateDeadState()
    {
        // Shouldn't need?
    }

    private void ExitDeadState()
    {
        // Shouldn't need?
    }

    //--OTHER FUNCTIONS------------------------------------------------------------------------------------------------------
    private void SwitchEnemyState(State newState)
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

    private void Flip()
    {
        //Debug.Log("Flip!");
        facingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }

    //private void Damage(float[] attackDetails)
    //{

    //}
}
