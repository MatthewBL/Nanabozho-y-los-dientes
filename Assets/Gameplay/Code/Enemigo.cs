using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PersonajeControlable>() || collision.GetComponent<Nanabozho>())
        {
            Destroy(gameObject);
        }
        if (collision.GetComponent<ZonaDefender>())
        {
            collision.GetComponent<ZonaDefender>().ReducirDefensa(1);
            Destroy(gameObject);
        }
    }
}
