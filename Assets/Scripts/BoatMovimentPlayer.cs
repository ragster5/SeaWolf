using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovimentPlayer : MonoBehaviour
{
    private Transform boat;
    // Start is called before the first frame update
    void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Boat").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (boat.GetComponentInChildren<Boat>().GetInBoat())
        {
            transform.position = Vector3.Lerp(transform.position, boat.position, 10);
        }
    }
}
