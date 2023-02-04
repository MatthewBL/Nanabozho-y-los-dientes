using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Button boton;

    string nombre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (text.text.Length != 0)
                {
                    text.text = text.text.Substring(0, text.text.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                boton.onClick.Invoke();
            }
            else
            {
                text.text += c;
            }
        }
    }
}
