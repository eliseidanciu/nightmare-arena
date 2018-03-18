using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {
    public GameObject player;
    public float x,y,z;
    float smoothSpeed = 0.1f;
    Vector3 offset;

	void Start () {
        offset = new Vector3(x, y, z);
    }
	
	void LateUpdate () {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    
}
