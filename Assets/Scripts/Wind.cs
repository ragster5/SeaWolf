using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private Rigidbody2D body;
    private float timer;
    private bool invisible;
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType(typeof(GameController)) as GameController;
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
    }

    // Update is called once per frame
    void Update()
    {
        if (invisible)
        {
            timer += Time.deltaTime;
            if (timer > 10)
            {
                gc.CreatWind();
                Destroy(gameObject);
            }
        }
    }
    private void OnBecameInvisible()
    {
        invisible = true;
    }
    private void OnBecameVisible()
    {
        invisible = false;
    }
}
