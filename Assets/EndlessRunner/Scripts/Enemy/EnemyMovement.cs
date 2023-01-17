using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    public void MoveTowardsTarget(Vector2 tragetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, tragetPosition, speed * Time.deltaTime);

    }
}
