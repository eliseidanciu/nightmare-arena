using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {
    GameObject player;
    float smoothSpeed = 0.1f;
    Vector3 offset;

	void Start () {
        offset = new Vector3(0, 30, -25);
        var target = FindObjectOfType<Player>();
        if (target.CompareTag("Player"))
        {
            player = target.gameObject;
        }
    }
	
	void LateUpdate () {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    
}
