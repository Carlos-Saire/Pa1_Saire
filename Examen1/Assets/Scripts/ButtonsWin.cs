using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonsWin : MonoBehaviour
{
    Button button;
    [SerializeField] LoadSceneControl ld;
    [SerializeField] GameObject canvas;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onclick);
    }
    private void Start()
    {
        canvas.SetActive(false);
    }
    void onclick()
    {
        ld.CambiarScene("Game");
    }
    public void Activar(bool a)
    {
        canvas.SetActive(a);
    }
    private void OnEnable()
    {
        PlayerController.EventWin += Activar;
    }
}
