using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySurvivalLevel : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Level " + PlayerPrefs.GetInt("SurvivalLevel");
    }
}
