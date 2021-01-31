using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Email : Enemy
{
    override protected void PatrolMovement()
    {
        
        wallDetected = Physics2D.Raycast(wallCheck.position, alive.transform.right, wallCheckDistance, whatIsBoundary);
        //Debug.DrawRay(transform.position, transform.right);
        if (wallDetected)
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
}
