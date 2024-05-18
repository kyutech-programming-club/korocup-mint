using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour
{
    public bool isGoal = false;
    private CreateGoal _createGoal;
    private void Start() 
    {
        _createGoal = GameObject.FindObjectOfType<CreateGoal>();
    }
    private void Update() 
    {
        if (isGoal)
        {
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
       if (isGoal)
       {
            _createGoal.OnGoal();
            Debug.Log("Goal: " + name + " has been hit by " + other.gameObject.name);
       }
    }
}
