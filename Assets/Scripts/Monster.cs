using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
  public float speed = 3.0f;
   bool monsterdetected = false;
   int direction =-1;
     Rigidbody2D rigidbody2d;
     Collider2D monsterCollider;
     public GameObject elevation;
       public Gamewon Gamewon;

    
    // Start is called before the first frame update
    void Start(){
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void FixedUpdate(){
       flip();
         if(monsterdetected){
         Vector2 position = GetComponent<Rigidbody2D>().position;
         position.x = position.x + Time.deltaTime * speed* direction;
         GetComponent<Rigidbody2D>().MovePosition(position);

         }
     }
     public void Hit(){
       
       elevation.SetActive(true);
       Destroy(gameObject);
       Gamewon.CheckWin();
       

     }


      void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
          monsterdetected = true;


        }
      }
        void OnCollisionEnter2D(Collision2D o){
          UFOController player = o.gameObject.GetComponent<UFOController>();
          if(player!=null){

            player.changehealth(20);
          }


        }
        void flip(){

          Vector3 theScale =transform.localScale;
            
          if(theScale.x ==-1){
          direction= 1;
          }
        }


}
     
     




