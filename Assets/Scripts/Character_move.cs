using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Character_move : MonoBehaviour
{

    public Sprite rightSprite;
    public Sprite leftSprite;
    public Sprite upSprite;
    public Sprite downSprite;
    private SpriteRenderer image;
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
        image = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        var moveValue = move.ReadValue<Vector2>();
        _rigidbody.MovePosition(_rigidbody.position + moveVector * moveSpeed * Time.deltaTime);

        Debug.Log(move.ReadValue<Vector2>());

        if (moveValue.x > 0)
        {
            moveVector = new Vector2(1,0);
            image.sprite = rightSprite;
        }
        if (moveValue.x < 0)
        {
            image.sprite = leftSprite;
            moveVector = new Vector2(-1, 0);
        }
        if(moveValue.y > 0)
        {
            image.sprite = upSprite;
            moveVector = new Vector2(0,1);

        }
        if (moveValue.y < 0)
        {
            image.sprite = downSprite;
            moveVector = new Vector2(0,-1);
        }
    }
} 
