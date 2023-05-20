using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private GameObject waypoint1;
    [SerializeField] private GameObject waypoint2;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Transform currentPoint;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = waypoint2.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == waypoint2.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < .5f && currentPoint == waypoint2.transform)
        {
            Flip();
            currentPoint = waypoint1.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < .5f && currentPoint == waypoint1.transform)
        {
            Flip();
            currentPoint = waypoint2.transform;
        }

    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
