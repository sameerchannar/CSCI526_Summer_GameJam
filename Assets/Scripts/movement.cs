using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float strength_limit = 1000;
    public Rigidbody2D ball;
    public float strength_factor = 0.1f;
    private LineRenderer lineRenderer;


    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
    }

    Vector2 startPoint = new Vector2();
    Vector2 endPoint = new Vector2();

    int started_stroke = 0;
    // Update is called once per frame
    void Update()
    {
        // starting stroke
        if (Input.GetMouseButtonDown(0) && started_stroke == 0)
        {
            startPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //Debug.Log(startPoint[0]);
            //Debug.Log(startPoint[1]);
            started_stroke = 1;
            Vector3 line_start = Camera.main.ScreenToWorldPoint(startPoint) + Vector3.forward;
            lineRenderer.SetPosition(0, line_start);
            lineRenderer.SetPosition(1, line_start);
            lineRenderer.enabled = true;

        }

        if (Input.GetMouseButton(0))
        {
            endPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 line_end = Camera.main.ScreenToWorldPoint(endPoint) + Vector3.forward;
            lineRenderer.SetPosition(1, line_end);
        }

        //ending stroke
        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;

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

    void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log("Collided with: " + other.gameObject.tag);
        if (other.gameObject != null)
        {
            if (other.gameObject.tag == "enemy" && !global.win)
            {
                Debug.Log("Heyy! Collided with: " + other.gameObject.tag);
                if (global.lives <= 1)
                {

                    global.lose = true;
                    Debug.Log("You LOSE!! Collided with enemy and no lives left! ");


                }
                else
                {
                    global.lives -= 1;
                    Debug.Log("Collided with enemy! Lives left = " + global.lives);
                }
            }



        }
    }
}
