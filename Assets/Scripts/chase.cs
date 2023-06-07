using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour
{
    public Rigidbody2D enemy;
    public GameObject ball;
    public float strength_factor = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ball_pos = ball.transform.position;
        Vector2 curr_pos = enemy.transform.position;
        Vector2 direction = ball_pos - curr_pos;
        //Debug.Log("chase Direction: " + direction);

        enemy.AddForce(direction * strength_factor, ForceMode2D.Impulse);
        
    }
}
