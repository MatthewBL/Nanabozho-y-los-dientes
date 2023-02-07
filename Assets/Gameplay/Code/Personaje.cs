using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Personaje : NetworkBehaviour
{
    public enum Orientation { vertical, horizontal }

    public float velocidadDeMovimiento = 5;
    public float multiplicadorVelocidad = 1;
    public float direccionVert = -1;
    public float direccionHor = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        if (IsOwner)
        {
            RefreshServerRpc(transform.position, this.direccionVert, this.direccionHor);
        }
    }

    void UpdatePosition()
    {
        Vector3 position = transform.position;
        transform.position = new Vector3(CalculateNewCoord(position.x, Orientation.horizontal), CalculateNewCoord(position.y, Orientation.vertical));
    }

    float CalculateNewCoord(float initialCoord, Orientation orientation)
    {
        if (orientation.Equals(Orientation.vertical))
        {
            return initialCoord + (velocidadDeMovimiento * multiplicadorVelocidad) * Time.deltaTime * direccionVert;
        }
        else
        {
            return initialCoord + (velocidadDeMovimiento * multiplicadorVelocidad) * Time.deltaTime * direccionHor;
        }
    }

    public void SetDirection(Orientation orientation, float direction)
    {
        if (orientation.Equals(Orientation.horizontal))
        {
            direccionVert = 0;
            direccionHor = direction;
        }
        else
        {
            direccionVert = direction;
            direccionHor = 0;
        }
    }

    [ServerRpc]
    void RefreshServerRpc(Vector2 position, float direccionVert, float direccionHor)
    {
        RefreshClientRpc(position, direccionVert, direccionHor);
    }

    [ClientRpc]
    void RefreshClientRpc(Vector2 position, float direccionVert, float direccionHor)
    {
        Refresh(position, direccionVert, direccionHor);
    }

    void Refresh(Vector2 position, float direccionVert, float direccionHor)
    {
        if (!IsOwner)
        {
            transform.position = position;
            this.direccionVert = direccionVert;
            this.direccionHor = direccionHor;
        }
    }

    public void SetDiagonalDirection(float direccionVert, float direccionHor)
    {
        this.direccionVert = direccionVert;
        this.direccionHor = direccionHor;
    }
}
