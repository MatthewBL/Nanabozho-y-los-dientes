using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShineEffect : MonoBehaviour
{
    public float wait = 0.4f;
    public GameObject boxDialogue;

    bool hasDone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wait -= Time.deltaTime;
        if (wait <= 0 && !hasDone)
        {
            boxDialogue.SetActive(true);
            hasDone = true;
        }
    }
}
