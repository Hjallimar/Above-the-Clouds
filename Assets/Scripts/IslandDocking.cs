using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandDocking : MonoBehaviour
{

    [SerializeField] private List<Transform> dockingPos = new List<Transform>();
    [SerializeField] private Collider seaBlockade = null;


    private void OnTriggerStay(Collider other)
    {
        BoatMovement boat = other.GetComponent<BoatMovement>();
        if (boat != null)
        {
            Debug.Log("I'm called");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("I'm called");
                seaBlockade.enabled = false;
                float distance = 0;
                Transform boatDock = null;
                foreach (Transform trans in dockingPos)
                {
                    if (distance == 0)
                    {
                        boatDock = trans;
                    }
                    else
                    {
                        distance = (trans.position - boat.transform.position).magnitude;

                        if(distance < (boatDock.position - boat.transform.position).magnitude)
                        {
                            boatDock = trans;
                        }
                    }
                }

                boat.GettingDocked(true);
                boat.transform.position = boatDock.position;
                boat.transform.rotation = boatDock.rotation;

            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        BoatMovement boat = other.GetComponent<BoatMovement>();
        if(boat != null)
        {
            seaBlockade.enabled = true;
        }
        
    }
}
