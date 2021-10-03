using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatLimits : MonoBehaviour
{
    public Transform boat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = boat.position;
    }
}
