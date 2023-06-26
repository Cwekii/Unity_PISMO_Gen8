using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_4_Lovro_DZ : MonoBehaviour
{   // Declaring variables for each of the scale axes and one for the sum of those variables
    float scaleX;
    float scaleY;
    float scaleZ;
    float scaleXYZ;

    // Declaring variables for each of the position axes and one for the sum of those variables
    float positionX;
    float positionY;
    float positionZ;
    float positionXYZ;

    // Declaring variables for each of the rotation axes and one for the sum of those variables
    float rotationX;
    float rotationY;
    float rotationZ;
    float rotationXYZ;

    private void Start()
    {   // Setting our scale variables to be equal to each scale axis of the object
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        scaleZ = transform.localScale.z;
        
        // Setting our position variables to be equal to each position axis of the object
        positionX = transform.position.x;
        positionY = transform.position.y;
        positionZ = transform.position.z;
        
        // Setting our rotation variables to be equal to each rotation axis of the object
        rotationX = transform.eulerAngles.x;
        rotationY = transform.eulerAngles.y;
        rotationZ = transform.eulerAngles.z;

        // Setting the positionXYZ value to the sum of position axes
        positionXYZ = positionX + positionY + positionZ;
        // Setting the scaleXYZ value to the sum of scale axes
        scaleXYZ = scaleX + scaleY + scaleZ;
        // Setting the rotationXYZ value to the sum of rotation axes
        rotationXYZ = rotationX + rotationY + rotationZ;

        // Checking if the sum of either rotation, position or scale is greater than 20
        if(scaleXYZ > 20 || positionXYZ > 20 || rotationXYZ > 20)
        {
            // Setting the scale to values x = 1, y = 1 and z = 1 
            transform.localScale = Vector3.one;
            // Setting the position to values x = 0, y = 0 and z = 0 
            transform.position = Vector3.zero;
            // Rotating to values x = 0, y = 0 and z = 0
            transform.eulerAngles = new Vector3(0,0,0);
        }
        // Checking if the sum of either rotation, position or scale is smaller than 20
        else if (scaleXYZ <= 20 || positionXYZ <= 20 || rotationXYZ <= 20)
        {
            // Adding the sum of scale axes x, y and z to each of the scale axes
            transform.localScale += new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
            // Adding the sum of position axes x, y and z to each of the position axes
            transform.position += new Vector3(positionXYZ,positionXYZ,positionXYZ);
            // I set the rotation values to x = 69, y = 420 and z = 911 here, but they will revert to x = 111, y = -120 and z = 10.99998
            transform.eulerAngles = new Vector3(69, 420, 911); 
        }
    }
}
