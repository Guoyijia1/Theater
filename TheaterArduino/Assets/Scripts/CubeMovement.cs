using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public ArduinoData arduinoData;

    public GameObject[] objectsToMove;
    public float MovementAmount = 1.0f;

    void Update()
    {
        int CubedistanceValue = arduinoData.DistanceValue;
   
        Debug.Log("CubeMovement: " + CubedistanceValue);

        foreach (GameObject obj in objectsToMove)
        {
            // Check if the GameObject has the tag "A"
            if (obj.CompareTag("A"))
            {
                //Debug.Log("Tag of object is A");
                Vector3 movement = new Vector3(0.0f, 0.0f, CubedistanceValue / 10) * MovementAmount;

                // Update the position of the cube
                transform.position += movement;
            }

            if (obj.CompareTag("B"))
            {
                //Debug.Log("Tag of object is A");
                Vector3 movement = new Vector3(0.0f, CubedistanceValue / 10, 0.0f) * MovementAmount;

                // Update the position of the cube
                transform.position += movement;
            }

            if (obj.CompareTag("C"))
            {
                //Debug.Log("Tag of object is A");
                Vector3 movement = new Vector3(CubedistanceValue / 10, 0.0f, 0.0f) * MovementAmount;

                // Update the position of the cube
                transform.position += movement;
            }
        }

        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector based on input and MovementAmount

        
    }
}
