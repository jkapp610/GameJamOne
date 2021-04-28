using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PumpkinController : MonoBehaviour
{
public float speed= 3.0f;
public float changeTime = 3.0f;
 Rigidbody2D rigidbody2D;
float timer;
int direction = 1;
public GameObject elevation;
public GameObject  pickup;


    // Start is called before the first frame update
    void Start()
    {
         rigidbody2D = GetComponent<Rigidbody2D>();
         timer = changeTime;

    }

    // Update is called once per frame
    void Update(){
        timer -= Time.deltaTime;
          if (timer < 0){
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate(){
          Vector2 position = GetComponent<Rigidbody2D>().position;
         position.y = position.y + Time.deltaTime * speed * direction;
          GetComponent<Rigidbody2D>().MovePosition(position);

    }

     public void Hitpumpkin(){
       
       elevation.SetActive(true);
       pickup.SetActive(true);
       Destroy(gameObject);
     }
     void OnCollisionEnter2D(Collision2D o){
          UFOController player = o.gameObject.GetComponent<UFOController>();
          if(player!=null){

            player.changehealth(10);
          }


        }
       




}
