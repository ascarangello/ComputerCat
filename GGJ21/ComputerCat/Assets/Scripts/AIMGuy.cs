using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMGuy : Enemy
{
    protected override void UpdatePursuitState()
    {
        if (!playerDetected)
        {
            SwitchEnemyState(State.PATROL);
        }
        else
        {
            PatrolMovement();
            Vector2 toTarget = (player.transform.position - transform.position).normalized;
            if (Vector2.Dot(toTarget, transform.forward) < 0)
            {
                Debug.Log("Player got behind " + name + ", flip!");
                Flip();
            }
        }
    }
}
