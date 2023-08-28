using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 1f;
    Vector2 minBounds;
    Vector2 maxBounds;
    Vector2 rawInput;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Shooter shooter;
    LevelManager levelManager;

    private void Awake() 
    {
        levelManager = FindObjectOfType<LevelManager>();
        shooter = GetComponent<Shooter>();    
    }
    void Start() 
    {
        initBouns();    
    }
    void Update()
    {
        Move();
    }
    void initBouns()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    private void Move()
    {
        Vector2 delta = rawInput * Time.deltaTime * MoveSpeed;
        Vector2 newpos = new Vector2();
        newpos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newpos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        transform.position = newpos;
    }

    void OnMove(InputValue vaule)
    {
        rawInput = vaule.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiering = value.isPressed;
        }
    }
     void OnQuit()
     {
        levelManager.LodeGameOver();
     }

}
