using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boat : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D body;
    private bool inBoat;
    private GameController gc;
    private int idDIrection;
    private bool accelerate;
    private Vector2 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        gc = FindObjectOfType(typeof(GameController)) as GameController;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        body = GetComponentInParent<Rigidbody2D>();
        body.AddForce(new Vector2(10, 10));
        
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity -= new Vector2(Time.deltaTime/10, Time.deltaTime/10);
        if (body.velocity.x < 0)
        {
            if (body.transform.localScale.x > 0)
            {
                body.transform.localScale = new Vector2(body.transform.localScale.x * -1, body.transform.localScale.y);
            }
        }
        else if (body.velocity.x > 0)
        {
            if (body.transform.localScale.x < 0)
            {
                body.transform.localScale = new Vector2(body.transform.localScale.x * -1, body.transform.localScale.y);
            }
        }
        
        if (!accelerate)
        {
            switch (idDIrection)
            {
                case -1:
                    if (body.velocity.x > 0)
                    {
                        body.velocity = new Vector2(body.velocity.x * -1.3f, body.velocity.y);
                    }
                    else
                    {
                        body.velocity = new Vector2(Random.Range(-1.2f, -2.2f), 0);
                    }

                    break;
                case 1:
                    if (body.velocity.x < 0)
                    {
                        body.velocity = new Vector2(body.velocity.x * -5, body.velocity.y);
                    }
                    else
                    {
                        body.velocity = new Vector2(Random.Range(3, 6), 0);
                    }
                    break;
            }
            accelerate = true;
        }
        if(body.velocity.x > 15)
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
        if(body.velocity.x < -15)
        {
            body.velocity = new Vector2(-0, body.velocity.y);
        }
        if(body.velocity.y > 15)
        {
            body.velocity = new Vector2(body.velocity.x, 9);
        }
        if(body.velocity.y < -15)
        {
            body.velocity = new Vector2(body.velocity.x, -9);
        }
    }

    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                inBoat = true;
                break;
            case "Rock":
                body.velocity = new Vector2((body.velocity.x * -2) / 2, (body.velocity.y) / 2);
                GameController.PlaySound(Sound.Damage);
                gc.TakeDamage();
                break;
            case "Victory":
                gc.Victory();
                break;
            case "Sea":
                print("Sea");
                if (Random.Range(0, 6) > 2)
                {
                    body.AddForce(new Vector2(Random.Range(-3, 3), Random.Range(-3, 3)));
                }
                else
                {
                    body.AddForce(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)), ForceMode2D.Impulse);
                }
                break;
            case "Forbbiden":
                SceneManager.LoadScene("GameOver");
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                player.transform.position = transform.position;
                inBoat = false;
            break;
        }
    }
    public bool GetInBoat()
    {
        return inBoat;
    }
    public void SetDirection(int direction)
    {
        accelerate = false;
        idDIrection = direction;
    }
}
