using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public float duration, interval;
    private float durationCounter, IntervalCounter;
    public ParticleSystem Water;

    private void Start()
    {
        //duration = Random.Range(.5f,3f);
        interval = Random.Range(3f, 12f);
    }

    private void Update()
    {
        //Debug.Log("duration:" + duration);
        //Debug.Log("Interval:" + interval);

        IntervalCounter += Time.deltaTime;
        
        if (IntervalCounter >= interval)
        {
            Water.Play();
            durationCounter += Time.deltaTime;
            //if (durationCounter >= duration)
            //{
                Water.Stop();
                //duration = Random.Range(.5f, 3f);
                interval = Random.Range(1f, 10f);
                //durationCounter = 0;
                IntervalCounter = 0;
            //}
        }

    }

  
}
