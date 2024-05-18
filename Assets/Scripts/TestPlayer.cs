using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    // Update is called once per frame
    void Update()
    {
        var movement = new Vector3();
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        transform.position += movement * speed * Time.deltaTime;
    }
}
