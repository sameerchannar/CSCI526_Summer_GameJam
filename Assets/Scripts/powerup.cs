using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    public float threshold = 0.5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = transform.position - ball.transform.position;
        float dist = direction.magnitude;
        if (dist < threshold && !global.lose)
        {
            Debug.Log("Collected a powerup! dist = " + dist);
            global.lives += 1;
            Debug.Log("Now lives you have = " + global.lives);
            Destroy(gameObject);
        }
    }
}
