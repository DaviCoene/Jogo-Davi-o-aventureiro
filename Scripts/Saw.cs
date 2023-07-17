using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Saw : MonoBehaviour
{
 
    public float speed;
    public float moveTime;
    

    private bool dirRight = false;
    private float timer;
    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}
