using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamond : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    public float threshold = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = transform.position - ball.transform.position;
        float dist = direction.magnitude;
        if (dist < threshold)
        {
            Debug.Log("Collected a diamond!");
            global.collectedCount += 1;
            Destroy(gameObject);
        }
    }
}
