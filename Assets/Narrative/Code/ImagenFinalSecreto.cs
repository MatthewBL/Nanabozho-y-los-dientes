using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagenFinalSecreto : MonoBehaviour
{
    public Sprite nejaEnding;
    public Sprite nejoEnding;

    // Start is called before the first frame update
    void Start()
    {
        string genero = PlayerPrefs.GetString("Genero");
        switch (genero)
        {
            case "Neja":
                GetComponent<Image>().sprite = nejoEnding;
                break;
            case "Nejo":
                GetComponent<Image>().sprite = nejaEnding;
                break;
            case "Neje":
                GetComponent<Image>().sprite = nejaEnding;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
