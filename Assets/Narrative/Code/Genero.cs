using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genero : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGender(string gender)
    {
        PlayerPrefs.SetString("Genero", gender);
    }
}
