using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlatfom : MonoBehaviour
{
    public float AmountPerTimer;
    public float MaxLeft;
    public float MaxRight;
    private float SignAmount;
    // Update is called once per frame
    private void Start()
    {
        SignAmount = AmountPerTimer;
    }
    void Update()
    {
        if (transform.localPosition.x >= MaxLeft)
        {
            //Debug.Log("-");
            SignAmount = -AmountPerTimer;
        }
        else if(transform.localPosition.x <= MaxRight)
        {
            //Debug.Log("+");
            SignAmount = AmountPerTimer;
        }

        transform.Translate(new Vector3((Time.deltaTime * SignAmount), 0, 0), Space.Self);
    }
}
