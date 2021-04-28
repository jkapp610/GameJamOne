using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Projectile : MonoBehaviour{

     Rigidbody2D rigidbody2d;
    int killed =0;
    Vector3 dir;
    public float speed =17.0f;
 


    // Start is called before the first frame update
    void Awake(){

       rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
  

   public void Launch(Vector3 direction,float force){
       //rigidbody2d.AddForce(direction * force);
       dir = direction;
   }
 // Update is called once per frame
   void Update(){

       if(transform.position.magnitude > 1000.0f){
           Destroy(gameObject);

       }
   }

   void FixedUpdate(){
       transform.position += dir*Time.deltaTime *speed;
        //Vector2 movement = new Vector2(horizontal*speed,rigidbody2d.velocity.y );
         //rigidbody2d.velocity = dir*speed;



   }

   void OnCollisionEnter2D(Collision2D other){
       Monster m = other.collider.GetComponent<Monster>();
       PumpkinController pumpkin = other.collider.GetComponent<PumpkinController>();
       if(m!=null){
             m.Hit();
            //Destroy(gameObject);
         
       }
       if(pumpkin!=null){
           pumpkin.Hitpumpkin();
           //Destroy(gameObject);
       }

       //Debug.Log("projectile collision with");
       Destroy(gameObject);
   }
}
