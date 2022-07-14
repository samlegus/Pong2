using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5.25f;
    public Rigidbody2D rb;
    public GameManager manager;
    public AudioSource sound;
    public AudioClip clipA;     //Assign this in Unity (hit the paddle sound)
    public AudioClip clipB;     //Assign this in Unity as well
    public TrailRenderer tr;

    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
        manager = GameObject.FindObjectOfType<GameManager>();
        sound = GetComponent<AudioSource>();
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
            sound.PlayOneShot(clipA);
        }
        if (colName == "PlayerTwo")
        {
            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized; //direction
            rb.velocity = dir * speed;
            sound.PlayOneShot(clipA);
        }
        if (colName == "WallLeft")
        {
            //manager.scoreB = manager.scoreB + 1;
            manager.scoreB += 1;
            transform.position = new Vector3(0f, 0f, 0f); //Re-center the ball
            Vector2 dir = new Vector2(1f, 0);
            rb.velocity = dir * speed;
            sound.PlayOneShot(clipB);
            tr.Clear();
        }
        if (colName == "WallRight")
        {
            manager.scoreA += 1;
            transform.position = new Vector3(0f, 0f, 0f);
            Vector2 dir = new Vector2(-1f, 0);
            rb.velocity = dir * speed;
            sound.PlayOneShot(clipB);
            tr.Clear();
        }
    }
}

