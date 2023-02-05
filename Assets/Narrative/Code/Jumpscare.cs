using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public float timeOut = 0.1f;
    public GameObject boxDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeOut -= Time.deltaTime;
        if (timeOut <= 0)
        {
            boxDialogue.SetActive(true);
            Destroy(gameObject);
        }
    }
}
