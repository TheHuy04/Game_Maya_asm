using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public Transform pointA, pointB; 
    private Vector3 targetPosition; 

    void Start()
    {
        targetPosition = pointB.position; 
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

       
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        if (targetPosition == pointB.position)
            localScale.x = Mathf.Abs(localScale.x); 
        else
            localScale.x = -Mathf.Abs(localScale.x); 

        transform.localScale = localScale;
    }
}
