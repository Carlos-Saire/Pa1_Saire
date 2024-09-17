using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PuntosControl : MonoBehaviour
{
    TMP_Text text;
    float puntos = 0;
    private void Start()
    {
        Puntos(0);
    }
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    void Puntos(float a)
    {
        puntos = puntos + a;
        text.text = "Puntos *" + puntos;
    }
    private void OnEnable()
    {
        Pintitos.puntos += Puntos;
    }
}
