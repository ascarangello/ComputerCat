using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Email : Enemy
{
    [SerializeField]
    protected GameObject bombPrefab;

    [SerializeField]
    protected Transform bombSpawnPoint;

    [SerializeField]
    protected float attackInterval;

    protected float timeTillNextAttack = 0.0f;

    override protected void PatrolMovement()
    {
        
        wallDetected = Physics2D.Raycast(wallCheck.position, alive.transform.right, wallCheckDistance, whatIsBoundary);
        //Debug.DrawRay(transform.position, transform.right);
        if (wallDetected)
        {
            //if (!groundDetected) { Debug.Log(name + ": No ground, turn around!"); }
            if (wallDetected) { Debug.Log(name + ": Oops a wall, turn around!"); }
            Flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, aliveRB.velocity.y);
            aliveRB.velocity = movement;
        }
    }

    protected override void UpdatePursuitState()
    {
        if (!playerDetected)
        {
            SwitchEnemyState(State.PATROL);
        }
        else
        {
            PatrolMovement();
            if (Time.time >= timeTillNextAttack)
            {
                BombDrop();
                timeTillNextAttack = Time.time + attackInterval;
                Debug.Log(name + " Drops a Bomb!");
            }
        }
    }

    protected void BombDrop()
    {
        Instantiate(bombPrefab, bombSpawnPoint);
    }
}
