using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 1f;
    Vector2 rawInput;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput * Time.deltaTime * MoveSpeed;
        transform.position += delta;
    }

    void OnMove(InputValue vaule)
    {
        rawInput = vaule.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
