using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlatfom : MonoBehaviour
{
    public float AmountPerTimer;

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x <= 89.9)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + (Time.deltaTime * AmountPerTimer), transform.localPosition.y, transform.localPosition.z);
        }
        else if(transform.localPosition.x >= 118)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - (Time.deltaTime * AmountPerTimer), transform.localPosition.y, transform.localPosition.z);
        }
    }
}
