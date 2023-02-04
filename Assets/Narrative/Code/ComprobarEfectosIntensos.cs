using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarEfectosIntensos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("EfectosIntensos") == 1)
        {
            GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            GetComponent<AudioSource>().enabled = false;
        }
    }
}
