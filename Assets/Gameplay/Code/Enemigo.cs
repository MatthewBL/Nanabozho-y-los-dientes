using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Enemigo : NetworkBehaviour
{
    public AudioClip deathSoundEffect;
    public int power = 1;
    public bool warp = false;

    List<GameObject> warpPoints;

    // Start is called before the first frame update
    void Start()
    {
        warpPoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Warp point"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PersonajeControlable>() || collision.GetComponent<Nanabozho>())
        {
            collision.GetComponent<AudioSource>().clip = deathSoundEffect;
            collision.GetComponent<AudioSource>().Play();
            if (warp)
            {
                int r = Random.Range(0, warpPoints.Count);
                collision.transform.position = warpPoints[r].transform.position;
            }
            DestroyEnemy();
        }
        if (collision.GetComponent<ZonaDefender>())
        {
            collision.GetComponent<ZonaDefender>().ReducirDefensa(power);
            DestroyEnemy();
        }
    }
    void DestroyEnemy()
    {
        gameObject.SetActive(false);
        if (IsServer)
        {
            Destroy(gameObject);
        }
    }
}
