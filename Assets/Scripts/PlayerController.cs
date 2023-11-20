using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private GameObject gazePlot;
    public int speed = 5;
    public int lookSpeed = 40;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        gazePlot = GameObject.FindGameObjectWithTag("GazePlot");
    }

    private void Update()
    {
        Vector3 move = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = this.transform.TransformDirection(move);
        characterController.Move(move * Time.deltaTime * speed);

        Vector3 rotation = new Vector3(0, Input.GetAxis("Horizontal Look") * Time.deltaTime * lookSpeed, 0);
        this.transform.Rotate(rotation);
        //gazePlot.transform.Rotate(rotation);
    }
}
