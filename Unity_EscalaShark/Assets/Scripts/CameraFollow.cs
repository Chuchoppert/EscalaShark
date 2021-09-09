using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	//this script goes to camera
	public Transform target; //object to follow

	public float smoothSpeed = 0.125f;
	public Vector3 offset; //put the position of the camera in the perspective you want

	void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(target);
	}

}

