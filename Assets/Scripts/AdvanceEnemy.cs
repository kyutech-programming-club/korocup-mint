using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceEnemy : MonoBehaviour
{
  public bool rotate = true;
    private bool plus_minsu;
    // Start is called before the first frame update
    private float Speedx;
    private float Speedy;
    private float distancex;
    private float distancey;
    public GameObject Player;
    private Vector2 PlayerPosition;
    private Vector2 EnemyPosition;
    public float Speed; 
    public float absdistancex;
    public float absdistancey;
    public bool Wape_judge = false;
    public GameObject wapeObject;
    private GameObject FindObject;
    // Start is called before the first frame update
    void Start()
    {
   Speedy = 0.1f;
   Speedx = 0.1f;
   FindObject = Player;
    }

    // Update is called once per frame
    void Update()
    {
    PlayerPosition = FindObject.transform.position;
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
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
     if(collisionInfo.transform.tag == "Plyer")
     {
     
     }
    }
    void OnTriggerEnter2D(Collider2D other)
      {
        if(other.gameObject.transform.tag == "TurnPoint")
        {
            if (Wape_judge == true)
            {
            FindObject = wapeObject;
             PlayerSerch();
            }
            else
            {
            FindObject = Player;
              PlayerSerch();
            }
           
        }
      
      } 
    

    public void PlayerSerch()
    {
        absdistancex = Mathf.Abs(distancex);
        absdistancey = Mathf.Abs(distancey);
      if (absdistancex > absdistancey)
      {
       rotate = true; 
       if (distancex >0)
       {
       plus_minsu = true;
       }
       else
       {
        plus_minsu = false;
       }
      }
      else if(absdistancex < absdistancey)
      {
        rotate = false;
             if (distancey >0)
       {
       plus_minsu = true;
       }
       else
       {
        plus_minsu = false;
       }
      }
    }
    private void XMove()
    {
      if (plus_minsu == false){
        EnemyPosition.x -= Speedx;
      }
      if (plus_minsu == true)
      {
         EnemyPosition.x += Speedx;
      } 
    transform.position = EnemyPosition;
    }
    private void YMove()
    {
    if (plus_minsu == false){
        EnemyPosition.y -= Speedx;
      }
      if (plus_minsu == true)
      {
         EnemyPosition.y += Speedx;
      } 
    transform.position = EnemyPosition;
    }
 
}
