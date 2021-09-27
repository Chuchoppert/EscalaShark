using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWaterPipes : MonoBehaviour
{
    [Header("Set Basic for water")]
    public ParticleSystem WaterSprayer;
    public float DistanceWaterToPipes;

    [Header("Look movements")]
    public float PosY;
    public float PosYWater;
    public bool isActivate;  

    private float TimesIntantiate = 1;

    // Start is called before the first frame update
    void Start()
    {
        PosY = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        PosYWater = WaterRiseLevel.PosWaterY;
     
        if (PosY < (WaterRiseLevel.PosWaterY - DistanceWaterToPipes))
        {
            isActivate = true;
            Invoke("InstantiateWater", 0f);
        }
    }

    void InstantiateWater()
    {    
        if (TimesIntantiate == 1)
        {
            Instantiate(WaterSprayer, this.transform.position, this.transform.localRotation);
            TimesIntantiate -= 1;
        }
    }    
}
