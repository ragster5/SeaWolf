using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sail : MonoBehaviour
{
    private Rigidbody2D boatBody;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        boatBody = GameObject.FindGameObjectWithTag("Boat").GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Flag()
    {
        box.enabled = !box.enabled;
        anim.SetBool("activate", box.enabled);
        if (box.enabled)
        {
            sprite.sortingLayerName = "InteractObjects";
        } else
        {
            sprite.sortingLayerName = "ObjectsBG";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Wind")){
            if (Random.Range(0, 6) > 2)
            {
                boatBody.AddForce(new Vector2(Random.Range(-3, 3), Random.Range(-2, 2)), ForceMode2D.Impulse);
            }
            else
            {
                boatBody.AddForce(new Vector2(Random.Range(-4.5f, 4.5f), Random.Range(-3.5f, 3.5f)), ForceMode2D.Impulse);
            }
        }
    }
}
