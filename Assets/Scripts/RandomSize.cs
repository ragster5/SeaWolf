using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSize : MonoBehaviour
{
    public float sizeMin, sizeMax;
    // Start is called before the first frame update
    void Start()
    {
        float size = Random.Range(sizeMin, sizeMax);
        transform.localScale = new Vector2(size, size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
