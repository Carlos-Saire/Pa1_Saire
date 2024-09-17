using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaController : MonoBehaviour
{
    Scrollbar scrollbar;
    [SerializeField] PlayerController player;
    private void Awake()
    {
        scrollbar = GetComponent<Scrollbar>();
    }
    void Contador(float life)
    {
        scrollbar.size = life/10;
    }
    private void OnEnable()
    {
        player.LifeInteractue += Contador;
    }
    private void OnDisable()
    {
        player.LifeInteractue -= Contador;
    }
}
