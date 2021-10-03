using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTitle : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] positions;
    private float timer = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 10)
        {
            GameObject tempPrefab = Instantiate(prefab) as GameObject;
            tempPrefab.transform.position = positions[Random.Range(0, positions.Length)].position;
            timer = 0;
        }
    }
}
