using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goals : MonoBehaviour
{

    public Sprite newSprite;
    private SpriteRenderer image;


    public bool isGoal = false;
    private CreateGoal _createGoal;
    private void Start() 
    {
        image = GetComponent<SpriteRenderer>();
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
            image.sprite = newSprite;
        }
    }
}
