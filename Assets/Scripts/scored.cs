using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scored : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hole;
    public GameObject ball;
    public float threshold;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = hole.transform.position - ball.transform.position;
        float dist = direction.magnitude;
        if (dist < threshold)
        {
            if (global.collectedCount == global.needToCollect && global.lives > 0 && global.timeRemaining >= 0)
            {
                Debug.Log("You Win!!!!!");
                global.win = true;
            }


        }
    }
}
