using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingEnemy : MonoBehaviour
{
    public Transform enemy;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1f;
    int dircetion = 1;


    private void Update()
    {
        Vector2 target = currentMovementTarget();

        enemy.position = Vector2.Lerp(enemy.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)enemy.position).magnitude;

        if (distance < 0.1f)
        {
            dircetion*=-1;
        }

    }

    Vector2 currentMovementTarget()
    {
        if (dircetion == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        // just for Debug visualization
        if (enemy!=null && startPoint!=null && endPoint != null)
        {
            Gizmos.DrawLine(enemy.transform.position, startPoint.position);
            Gizmos.DrawLine(enemy.transform.position, endPoint.position);
        }
    }

}
