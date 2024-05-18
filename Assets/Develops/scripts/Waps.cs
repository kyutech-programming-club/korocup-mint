using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waps : MonoBehaviour
{
    //横の時に使おう
   public GameObject Player;
    public GameObject Enemy;
    public GameObject Wapepoint;
    private GameObject Wapeobject;
    private Vector3 PlayerPosiiton;
    private Vector3 EnemyPostion;
    private Vector3 Wapepointposiiton;
    public float anotherdistabce;

    public float x;
    public float y; 
     private AdvanceEnemy  AdvanceEnemy ;
     private float absdistancex;
     private float absdistancey;
     private float absx;
     private float absy;
    void Start()
    {
        AdvanceEnemy = Enemy.GetComponent<AdvanceEnemy>();
        PlayerPosiiton = Player.transform.position;
        EnemyPostion = Enemy.transform.position;
        Wapepointposiiton = Wapepoint.transform.position;
    }
    void Update()
    {

     x = transform.position.x - EnemyPostion.x + PlayerPosiiton.x - Wapepointposiiton.x;  
     y = transform.position.y - EnemyPostion.y + PlayerPosiiton.y - Wapepointposiiton.y;     
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Wapeobject = other.gameObject;
        Wapeobject.transform.position = Wapepointposiiton;
        if (other.gameObject.transform.tag == "Player")
        {
        absdistancex = Mathf.Abs(Enemy.transform.position.x - Player.transform.position.x);
        absdistancey = Mathf.Abs(Enemy.transform.position.y - Player.transform.position.y);
        absx = Mathf.Abs(x);
        absy = Mathf.Abs(y);
        if (absx < absdistancex)
        {
        AdvanceEnemy.Wape_judge = true;
        }
        else
        {
        AdvanceEnemy.Wape_judge = false;
        }
        }
       else if (other.gameObject.transform.tag == "Enemy")
       {
        AdvanceEnemy.Wape_judge = false;
       }
}
}
