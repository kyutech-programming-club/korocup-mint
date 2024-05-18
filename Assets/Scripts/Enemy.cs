using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool rotate = true;
    private bool plus_minasu;
    // Start is called before the first frame update
    private float Speedx;
    private float Speedy;
    public float distancex;
    public float distancey;
    public GameObject Player;
    private Vector2 PlayerPosition;
    private Vector2 EnemyPosition;
    public float Speed; 
    // Start is called before the first frame update
    void Start()
    {
   Speedy = 0.1f;
   Speedx = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
    PlayerPosition = Player.transform.position;
    EnemyPosition = transform.position;
    distancex = PlayerPosition.x - transform.position.x;
    distancey = PlayerPosition.y - transform.position.y;
       if (rotate == true){
         XMove();
       }
       else 
       {
        YMove();
       }
   
    }
    void OnTriggerEnter2D(Collider2D other)
      {
       PlayerSerch();
      } 
    

    void PlayerSerch()
    {
    if (distancex > 0)
    {
     plus_minasu  = true;
    }
    else if (distancey  < 0)
    {
    plus_minasu = false;
    }
    else{}
    if (distancey > 0)
    {
     plus_minasu  = true;
    }
    else if (distancey < 0)
    {
      plus_minasu = false;
    }
    if (distancex >= distancey)
    {  
     rotate = true;
    }
    else
    {
     rotate = false;
    }
    }
    private void XMove()
    {
      if (plus_minasu == false){
        EnemyPosition.x -= Speedx;
      }
      if (plus_minasu == true)
      {
         EnemyPosition.x += Speedx;
      } 
    transform.position = EnemyPosition;
    }
    private void YMove()
    {
    if (plus_minasu == false){
        EnemyPosition.y -= Speedx;
      }
      if (plus_minasu == true)
      {
         EnemyPosition.y += Speedx;
      } 
    transform.position = EnemyPosition;
    }
 
}
