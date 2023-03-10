using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
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

    public void SetDiagonalDirection(float direccionVert, float direccionHor)
    {
        this.direccionVert = direccionVert;
        this.direccionHor = direccionHor;
    }
}
