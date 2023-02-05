using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationHandler : MonoBehaviour
{
    public GameObject introduction;
    public GameObject badEnding;
    public GameObject goodEnding;
    public GameObject secretEnding;

    // Start is called before the first frame update
    void Start()
    {
        string outcome = PlayerPrefs.GetString("Outcome");
        switch (outcome)
        {
            case "Defeat":
                badEnding.SetActive(true);
                break;
            case "Victory":
                goodEnding.SetActive(true);
                break;
            default:
                introduction.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        PlayerPrefs.SetString("Outcome", "");
    }
}
