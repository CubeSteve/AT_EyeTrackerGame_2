using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject[] linkedButtions;
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
                    this.gameObject.SetActive(false);
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
