using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [Header ("Patrol points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;


    [Header ("Enemy")]
    [SerializeField] private Enemy enemy;

    [Header ("Movement parameters")]
    [SerializeField] private float speed;
    [SerializeField] private int movingDirection;

    [Header ("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    [SerializeField] private float idleTimer;

    // Constants
    public const int LEFT = -1;
    public const int RIGHT = 1;

    private void Update()
    {
        if ((enemy.currentDirection == LEFT && enemy.transform.position.x >= leftEdge.position.x) ||
            (enemy.currentDirection == RIGHT && enemy.transform.position.x <= rightEdge.position.x))
        {
            idleTimer = 0;
            enemy.MoveInDirection(enemy.currentDirection, speed);
            enemy.WalkAnimation(); 
        } else 
        {
            enemy.StopWalkAnimation();
            // Move only after idling for idleDuration
            idleTimer += Time.deltaTime;
           if (idleTimer > idleDuration)
            {
                // Walk the opposite way
                enemy.MoveInDirection(enemy.currentDirection * -1, speed);
                enemy.WalkAnimation();
            }
        }

        idleTimer += Time.deltaTime; 
    }

    private void OnDisable()
    {
        enemy.StopWalkAnimation();   
    }
}
