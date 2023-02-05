using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorDefensa : MonoBehaviour
{
    public int value = 23;
    public List<GameObject> dientes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = 22;
        while (i >= 0)
        {
            dientes[i].SetActive(i < value);
            i -= 1;
        }
    }
}
