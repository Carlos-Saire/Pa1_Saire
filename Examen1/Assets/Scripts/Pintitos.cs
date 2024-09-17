using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pintitos : MonoBehaviour
{
    static public event Action<float> puntos;
    protected virtual void sumar()
    {
        puntos?.Invoke(1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sumar();
            Destroy(this.gameObject);
        }
    }
}
