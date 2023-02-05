using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EfectosIntensos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        if (GetComponent<Toggle>().isOn) i = 1;
        PlayerPrefs.SetInt("EfectosIntensos", i);
    }
}
