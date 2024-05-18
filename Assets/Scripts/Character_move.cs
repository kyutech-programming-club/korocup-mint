using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character_move : MonoBehaviour
{
    private InputAction move;
    private Vector2 rottate;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
       var input = GetComponent<PlayerInput>();
       move = input.currentActionMap.FindAction("Move");

    }

    // Update is called once per frame
    void Update()
    {
        var moveValue = move.ReadValue<Vector2>();
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        Debug.Log(move.ReadValue<Vector2>());

        if (moveValue.x > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,-90);
        }
        if (moveValue.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if(moveValue.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (moveValue.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
} 
