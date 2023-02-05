using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorAnzuelo : MonoBehaviour
{
    public GameObject anzuelo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBait()
    {
        GetComponent<AudioSource>().Play();
        Instantiate(anzuelo, transform);
    }
}
