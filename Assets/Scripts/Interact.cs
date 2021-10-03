using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private Collider2D interact;
    private Animator anim;
    private Boat boat;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        boat = GameObject.FindGameObjectWithTag("Boat").GetComponentInChildren<Boat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            switch (interact.tag)
            {
                case "Sail":
                    interact.GetComponentInChildren<Sail>().Flag();
                    anim.SetTrigger("Action");
                    GameController.PlaySound(Sound.Sail);
                    break;
                case "Leme":
                    anim.SetTrigger("Action");
                    GameController.PlaySound(Sound.Leme);
                    switch (interact.GetComponentInChildren<Animator>().GetInteger("Route")) {
                        case 0:
                            interact.GetComponentInChildren<Animator>().SetInteger("Route", -1);
                            boat.SetDirection(-1);
                            break;
                        case 1:
                            interact.GetComponentInChildren<Animator>().SetInteger("Route", 0);
                            boat.SetDirection(0);
                            break;

                        case -1:
                            interact.GetComponentInChildren<Animator>().SetInteger("Route", 1);
                            boat.SetDirection(1);
                            break;
                    }
                    break;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        interact = collision;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interact = null;
    }
}

