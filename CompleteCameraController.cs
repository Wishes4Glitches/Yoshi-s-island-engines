using UnityEngine;
using System.Collections;

public class CompleteCameraController : MonoBehaviour
{

    //Public variable to store a reference to the player game object
    public Transform Yoshi;
    public Transform Followplatform;


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera


    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = Followplatform.position - Yoshi.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = Yoshi.position + offset;
        //Followplatform.position = new Vector3(Yoshi.position.x, 6.14f, -10f) + offset;
    }
}