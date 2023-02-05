using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImitateText : MonoBehaviour
{
    public Text text;
    public TextMeshProUGUI textPro;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (text)
        {
            GetComponent<Text>().text = text.text;
        }
        if (textPro)
        {
            GetComponent<TextMeshProUGUI>().text = textPro.text;
        }
    }
}
