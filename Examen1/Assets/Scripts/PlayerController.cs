using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
public class PlayerController : MonoBehaviour
{
    Rigidbody RB;
    [SerializeField] private float Speed;
    bool isjump;
    float horizontal;
    float Zdirection;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpForce;
    [SerializeField] float life;
    public event Action<float> LifeInteractue;
    static public event Action<bool> EventWin;
    static public event Action<bool> EventLosue;
    [SerializeField] GameObject Win;
    [SerializeField] GameObject Losue;
    protected virtual void ActiveEventLife(float damage)
    {
        life = life - damage;
        LifeInteractue?.Invoke(life);
        if (life <= 0)
        {
            ActiveEventLouse();
        }
    }
    protected virtual void ActiveEventWin()
    {
        EventWin?.Invoke(true);
        Time.timeScale = 0;
    }
    protected virtual void ActiveEventLouse()
    {
        EventLosue?.Invoke(true);
        Time.timeScale = 0;
    }
    private void Start()
    {
        Desactivar();
        Time.timeScale = 1;
        ActiveEventLife(0);
    }
    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }
    public void Horizontal(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<float>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        isjump = context.performed;
    }
    public void Zmoment(InputAction.CallbackContext context)
    {
        Zdirection = context.ReadValue<float>();
    }
    private void FixedUpdate()
    {
        RB.velocity = new Vector3(horizontal * Speed, RB.velocity.y,Zdirection*Speed);
        if (Physics.Raycast(transform.position, Vector3.down, 1.03f, groundLayer))
        {
            if (isjump)
            {
                RB.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ganaste"))
        {
            ActiveEventWin();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ActiveEventLife(1);
        }
        if (collision.gameObject.CompareTag("Limit"))
        {
            ActiveEventLouse();
        }
    }

    public void Desactivar()
    {
        enabled = false;
    }
}
