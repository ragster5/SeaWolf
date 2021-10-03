using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    private float horizontal, vertical;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
    }
    void PlayerControls()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        anim.SetBool("walking", horizontal != 0 || vertical != 0);
        if(horizontal != 0 && vertical != 0)
        {
            body.velocity = new Vector2((horizontal * speed)/1.5f, (vertical * speed)/1.5f);
        } else
        {
            body.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        if(horizontal < 0) {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
        } else if(horizontal > 0)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
        }
        
    }
}
