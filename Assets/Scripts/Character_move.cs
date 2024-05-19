using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character_move : MonoBehaviour
{
    private InputAction move;
    private Vector2 rottate;
    private Vector2 moveVector = new Vector2(0, 1);
    [SerializeField] private Rigidbody2D _rigidbody;
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
        _rigidbody.MovePosition(_rigidbody.position + moveVector * moveSpeed * Time.deltaTime);

        // Debug.Log(move.ReadValue<Vector2>());

        if (moveValue.x > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,-90);
            moveVector = new Vector2(1,0);
        }
        if (moveValue.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            moveVector = new Vector2(-1, 0);
        }
        if(moveValue.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            moveVector = new Vector2(0,1);

        }
        if (moveValue.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            moveVector = new Vector2(0,-1);
        }
    }
} 
