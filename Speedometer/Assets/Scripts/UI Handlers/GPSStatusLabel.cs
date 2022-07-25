using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSStatusLabel : MonoBehaviour
{
    [SerializeField] GameObject Off, On;

    void Update()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            Off.SetActive(false);
            On.SetActive(true);
        } else
        {
            Off.SetActive(true);
            On.SetActive(false);
        }
    }
}
