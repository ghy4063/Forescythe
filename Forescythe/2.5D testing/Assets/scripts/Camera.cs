using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    
    public Transform playerTransform;
    public float cameraMoveSpeed;
    // public Vector3 cameraPosition = new Vector3(0, 1, 3);
    public Vector3 cameraPosition;
    // makes sure the camera is focused on the player all the time
    void Update()
    {
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, playerTransform.position + cameraPosition, cameraMoveSpeed * Time.deltaTime);
    }
}
