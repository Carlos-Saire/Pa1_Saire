using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject objetivo;
    [SerializeField] float speed;
    private void Update()
    {
        Move();
    }
    public void SetObjetive(GameObject NewObjetivo)
    {
        objetivo = NewObjetivo;
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, objetivo.transform.position, speed * Time.deltaTime);
    }
}
