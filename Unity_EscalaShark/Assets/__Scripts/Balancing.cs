using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balancing : MonoBehaviour
{
    [Header("Set basics for Movements")]
    public Vector3 SetGravity;
    public float speed = 6f;
    public float ImpulseBeforeGrab = 10f;
    private  Vector3 setPivotWhenisGrabbing;
    public GameObject Canvas;

    [Header("Look the movements")]
    public Vector3 PivotGrabbingWorld;
    public Vector3 PivotNatural;
    public Vector3 SumVecDireccion;
    public bool isGrabbing;
    public bool ActivateLaunch;

    private Rigidbody rb;
    private float HorizMovement;
    private Transform GrabPipeTransform; //pos para linkear el shark al pipe
    
   
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = SetGravity;
        rb = GetComponent<Rigidbody>();
        isGrabbing = false;
        ActivateLaunch = false;
    }

    // Update is called once per frame
    void Update()
    {
        HorizMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        OnGrab();
    }

    private void FixedUpdate()
    {
        rb.AddTorque(Vector3.forward * HorizMovement, ForceMode.Impulse); //6to try

        //PivotNatural = GameObject.FindGameObjectWithTag("SnapNatural").transform.localPosition; //Vector3(0,0,0)
        //PivotGrabbingWorld = GameObject.FindGameObjectWithTag("SnapGrab").transform.localPosition; //Vector3(0,-0.8,0)

        PivotNatural = transform.TransformDirection(GameObject.FindGameObjectWithTag("SnapNatural").transform.localPosition); //Vector3(0,0,0)
        PivotGrabbingWorld = transform.TransformDirection(GameObject.FindGameObjectWithTag("SnapGrab").transform.localPosition); //Vector3(0,-0.8,0)

        //Direccion del vector
        SumVecDireccion = -(setPivotWhenisGrabbing - PivotNatural).normalized;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PipeGrab")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isGrabbing = true;
                ActivateLaunch = true;
            }
            else
            {
                isGrabbing = false;

                //rb.velocity = ForceBeforeGrab;
                //Direccion * magnitud 
                if (ActivateLaunch == true)
                {
                    rb.AddForce(SumVecDireccion * ImpulseBeforeGrab, ForceMode.Impulse);
                    ActivateLaunch = false;
                }
            }
            GrabPipeTransform = other.gameObject.transform;
        }
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * PivotGrabbingWorld, 0.2f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + transform.rotation * PivotNatural, 0.2f);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + transform.rotation * rb.centerOfMass, 0.5f); 
    }*/

    private void OnGrab()
    {
        if (isGrabbing == true)
        {
            transform.position = new Vector3(GrabPipeTransform.position.x, GrabPipeTransform.position.y, transform.position.z);

            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            rb.centerOfMass = GameObject.FindGameObjectWithTag("SnapGrab").transform.localPosition;            
        }            
        else if (isGrabbing == false)
        {
            transform.position = transform.position;

            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            rb.centerOfMass = GameObject.FindGameObjectWithTag("SnapNatural").transform.localPosition;
        }      
    }

    private void OnDisable()
    {
        Canvas.gameObject.SetActive(true);
    }
}

