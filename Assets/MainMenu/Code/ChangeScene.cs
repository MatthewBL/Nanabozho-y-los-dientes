using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : NetworkBehaviour
{
    bool changeScene = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changeScene)
        {
            ChangeServerScene("Survival");
        }
    }

    void ChangeServerScene(string scene)
    {
        PlayerPrefs.SetInt("SurvivalLevel", 1);
        //SceneManager.LoadScene(scene);
        NetworkManager.SceneManager.LoadScene(scene, LoadSceneMode.Single);


    }

    public void PrepareChangeScene()
    {
        changeScene = true;
    }
}
