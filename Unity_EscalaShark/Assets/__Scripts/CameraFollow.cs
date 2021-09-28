using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	//this script goes to camera
	[Header("Set Basic for Follow Camera")]
	public Transform target; //object to follow
	public float smoothSpeed = 0.125f;
	public Vector3 offset; //put the position of the camera in the perspective you want

	[Header("Specific Values")]
	public float UpAmountPerTime;
	private bool subtractOffset;
	public float MinOffsetY;
	public float MaxOffsetY;


    void FixedUpdate()
	{
		if(offset.y <= 1)
        {
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			{
				offset.y -= UpAmountPerTime;
				subtractOffset = false;
			}
			else 
            {
				subtractOffset = true;
            }

			if (offset.y != 1)
			{
				if(subtractOffset == true)
                {
					offset.y += UpAmountPerTime;
				}				
			}
		}
		offset.y = Mathf.Clamp(offset.y, MinOffsetY, MaxOffsetY);

		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(target);
	}

}

