using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImitateText : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = text.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
