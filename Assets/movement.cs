using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float strength_limit = 1000;
    public Rigidbody2D ball;
    public float strength_factor = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
    }

    Vector2 startPoint = new Vector2();
    Vector2 endPoint = new Vector2();

    int started_stroke = 0;
    // Update is called once per frame
    void Update()
    {
        // starting stroke
        if (Input.GetMouseButtonDown(0) && started_stroke == 0) {
            startPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //Debug.Log(startPoint[0]);
            //Debug.Log(startPoint[1]);
            started_stroke = 1;
        }

        //ending stroke
        if (Input.GetMouseButtonUp(0)) {
            endPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //Debug.Log(endPoint[0]);
            //Debug.Log(endPoint[1]);

            //calculate angle and strength
            Vector2 direction = endPoint - startPoint;
            direction *= -1; // like golf backswing
            float strength = direction.magnitude * strength_factor;
            //Debug.Log("Direction: " + direction);
            //Debug.Log("Strength: " + strength);
            started_stroke = 0;
            strength = Mathf.Min(strength, strength_limit);

            // send ball
            ball.AddForce(direction.normalized * strength, ForceMode2D.Impulse);
        }


    }
}
