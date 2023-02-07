using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class HostOnly : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {

    }

    public override void OnNetworkSpawn()
    {
        if (!IsServer)
        {
            gameObject.SetActive(false);
        }
    }
}
