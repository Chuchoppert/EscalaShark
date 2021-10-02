using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRiseLevel : MonoBehaviour
{
    static public float PosWaterY;

    [Header("Set Basic for water")]
    public float timeToStar;
    public float Speed;
    public AudioSource DeathAudio;

    [Header("Look movements")]
    public bool isActivate;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        PosWaterY = transform.position.y;

        Invoke("ActivateRiseLevel", timeToStar);

        if (isActivate == true)
        {
            gameObject.transform.position = new Vector3(0, Time.deltaTime * Speed, 0) + gameObject.transform.position;
        }
    }

    void ActivateRiseLevel()
    {
        isActivate = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DeathAudio.Play();
            other.gameObject.SetActive(false);
        }
    }
}
