using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameManagerController : MonoBehaviour
{
    [SerializeField] PlayerController[] player;
    int index=0;
    private void Start()
    {
        Invoke("CPersonaje", 0.1f);
    }
    public void CambiarPErsonaje(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            if (context.ReadValue<float>()>0&&index<3)
            {
                player[index].Desactivar();
                index = index + 1;
                CPersonaje();
            }if(context.ReadValue<float>() < 0 && index > 0)
            {
                player[index].Desactivar();
                index = index - 1;
                CPersonaje();
            }
        }
        
    }
    void CPersonaje()
    {
        player[index].enabled = true;
    }
}
