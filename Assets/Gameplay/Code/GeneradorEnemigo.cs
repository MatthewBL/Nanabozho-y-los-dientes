using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneradorEnemigo : NetworkBehaviour
{
    public GameObject enemigo;
    public int survivalLevel = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (SceneManager.GetActiveScene().name != "Gameplay")
        {
            if (survivalLevel > PlayerPrefs.GetInt("SurvivalLevel"))
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemigo, transform);
        enemy.GetComponent<NetworkObject>().Spawn();
    }
}
