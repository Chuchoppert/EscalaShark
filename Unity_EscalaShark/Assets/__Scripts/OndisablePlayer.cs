using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndisablePlayer : MonoBehaviour
{
    public GameObject Canvas;
    private void OnDisable()
    {
        Canvas.gameObject.SetActive(true);
    }
}
