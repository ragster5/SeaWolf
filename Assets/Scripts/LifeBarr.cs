using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarr : MonoBehaviour
{
    public float life;
    private float lifemax;
    public float maxSize;
    private float tamanhoAtual;
    public GameObject lifebar;
    // Start is called before the first frame update
    void Start()
    {
        lifemax = life;
    }

    // Update is called once per frame
    void Update()
    {
        tamanhoAtual = life * maxSize / lifemax;
        transform.localScale = new Vector2(tamanhoAtual, transform.localScale.y);
    }
    private void OnBecameInvisible()
    {
        Destroy(lifebar);
    }
}
