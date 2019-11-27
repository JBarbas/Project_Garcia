using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseController : MonoBehaviour
{
    public Image n1,n2,n3,n4,n5,n6,n7,n8,n9,n10;

    public float _noise = 0;


    // Update is called once per frame
    void Update()
    {
        NoiseChange(_noise);
    }

    void NoiseChange(float noiseValue)
    {
        if(noiseValue >= 10.0f)
        {
            n1.transform.gameObject.SetActive(true);
        }
        if (noiseValue >= 20.0f)
        {
            n2.transform.gameObject.SetActive(true);
        }
        if (noiseValue >= 30.0f)
        {
            n3.transform.gameObject.SetActive(true);
        }
        if (noiseValue >= 40.0f)
        {
            n4.transform.gameObject.SetActive(true);
        }
        if (noiseValue >= 50.0f)
        {
            n5.transform.gameObject.SetActive(true);
        }
        if (noiseValue >= 60.0f)
        {
            n6.transform.gameObject.SetActive(true);
        }
        if (noiseValue >= 70.0f)
        {
            n7.transform.gameObject.SetActive(true);
        }
        if (noiseValue >= 80.0f)
        {
            n8.transform.gameObject.SetActive(true);
        }
        if (noiseValue >= 90.0f)
        {
            n9.transform.gameObject.SetActive(true);
        }
        if (noiseValue >= 100.0f)
        {
            n10.transform.gameObject.SetActive(true);
        }
    }
}
