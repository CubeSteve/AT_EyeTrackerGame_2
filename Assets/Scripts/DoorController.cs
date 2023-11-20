using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject[] linkedButtions;
    public bool reverse = false;
    private int counter = 0;

    private void Update()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        for (int i = 0; i < linkedButtions.Length; i++)
        {
            // Check if button is full
            if (linkedButtions[i].GetComponent<GazeButton>().gradientControl <= 0)
            {
                counter++;
                // If all full
                if (counter == linkedButtions.Length)
                {
                    if (!reverse)
                    {
                        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    }
                    else
                    {
                        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
                        this.gameObject.GetComponent<BoxCollider>().enabled = true;
                    }

                    this.gameObject.GetComponent<DoorController>().enabled = false;
                }
            }
            // Else end function
            else
            {
                counter = 0;
                return;
            }
        }
    }
}
