using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5.25f;
    public Rigidbody2D rb;
    public GameManager manager; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
        manager = GameObject.FindObjectOfType<GameManager>();
    }

    //Calculate angle for ball
    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Get the actual name of the thing we are hitting
        string colName = collision.gameObject.name;
        if (colName == "PlayerOne")
        {
            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized; //direction
            rb.velocity = dir * speed;
        }
        if (colName == "PlayerTwo")
        {
            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized; //direction
            rb.velocity = dir * speed;
        }
        if (colName == "WallLeft")
        {
            //manager.scoreB = manager.scoreB + 1;
            manager.scoreB += 1;
            transform.position = new Vector3(0f, 0f, 0f); //Re-center the ball
            Vector2 dir = new Vector2(1f, 0);
            rb.velocity = dir * speed;
        }
        if (colName == "WallRight")
        {
            manager.scoreA += 1;
            transform.position = new Vector3(0f, 0f, 0f);
            Vector2 dir = new Vector2(-1f, 0);
            rb.velocity = dir * speed;
        }
    }
}

