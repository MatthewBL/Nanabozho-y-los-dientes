using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneradorEnemigo : MonoBehaviour
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
        Instantiate(enemigo, transform);
    }
}
