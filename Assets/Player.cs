using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public float speed = 2.5f;

    void Update()
    {
        if(Input.GetKey(up))
        {
            //Translate means move
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if(Input.GetKey(down))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
}
