using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaForce : MonoBehaviour
{
    public string orientation;
    private Rigidbody2D body;
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        gc = FindObjectOfType(typeof(GameController)) as GameController;
        if (orientation.Equals("Horizontal"))
        {
            body.velocity = new Vector2(Random.Range(-3, 3), body.velocity.y);
        } else
        {
            body.velocity = new Vector2(body.velocity.x, Random.Range(-3, 3));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < gc.leftUp.position.x)
        {
            body.velocity = Vector2.zero;
            body.AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
        }
        if (transform.position.x > gc.rightDown.position.x)
        {
            body.velocity = Vector2.zero;
            body.AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
        }
        if (transform.position.y < gc.rightDown.position.y)
        {
            body.velocity = Vector2.zero;
            body.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
        }
        if (transform.position.y > gc.leftUp.position.y)
        {
            body.velocity = Vector2.zero;
            body.AddForce(new Vector2(0, -2), ForceMode2D.Impulse);
        }
    }
}
