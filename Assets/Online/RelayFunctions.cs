using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class RelayFunctions : MonoBehaviour
{
    UnityTransport transport;

    // Start is called before the first frame update
    async void Awake()
    {
        transport = FindObjectOfType<UnityTransport>();

        await Authenticate();

    }

    // Update is called once per frame
    void Update()
    {

    }

    static async Task Authenticate()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void CreateGame()
    {
        Allocation a = await RelayService.Instance.CreateAllocationAsync(8);
        string code = await RelayService.Instance.GetJoinCodeAsync(a.AllocationId);

        transport.SetHostRelayData(a.RelayServer.IpV4, (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData);

        NetworkManager.Singleton.StartHost();

        Debug.Log(code);
    }

    public async void JoinGame(TextMeshProUGUI text)
    {
        string code = text.text.Remove(text.text.Length - 1);

        JoinAllocation a = await RelayService.Instance.JoinAllocationAsync(code.Trim());

        transport.SetClientRelayData(a.RelayServer.IpV4, (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData, a.HostConnectionData);

        NetworkManager.Singleton.StartClient();
    }
}
