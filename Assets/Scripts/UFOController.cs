using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UFOController : MonoBehaviour
{

    public GameObject projectilePrefab;
     Rigidbody2D rigidbody2d;
    private bool isDead;
     Collider2D myCollider;
     public Text AummoText;
     //public Text GameoverText;
    //public Text QuitText;
     public Text HealthText;
      //public Text DirText;
    //public Text instructionText;
    public static int health;
    bool facingRight;
    public Text EText;
    public GameObject pausemenu;
    bool menusetactive;
    public GameObject Gameoverpanel;
    //public Text RestartText;
     float horizontal;
     public float Jump = 10f;
     float maxspeed= 50.0f;
     float time;
     static int count;
    public float speed = 10.0f;
    Vector2 lookDirection = new Vector2(1,0);
     public int eleivation;
    //public Text EleivationText;
    public GameObject elevationtext;
    public GameObject directionpanel;

    // Start is called before the first frame update
    void Start(){
        rigidbody2d = GetComponent<Rigidbody2D>();
        //transform.position = new Vector3(, 0.73f, 0.0f);
        myCollider = GetComponent<Collider2D>();
      
        count =0;
        eleivation =2;
        SetAmmoText();
        SetElevationText();
       
        eleivation =2;
        //EleivationText.text =" ";
        //DirText.text = " ";
        health = 100;
        facingRight =true;
        SetHealthText();
      
    }

    // Update is called once per frame
    void Update(){
         horizontal = Input.GetAxis("Horizontal");
        
         //if((!isDead)){
            if (Input.GetKeyDown(KeyCode.Space)){
                //time =2.0f;
                //rigidbody2d.AddForce(transform.up * Jump, ForceMode2D.Impulse);
                 if(eleivation > 0){
                    rigidbody2d.velocity = Vector2.up * Jump;
                    eleivation--;
                    SetElevationText();
             

                }
                else{
                   // EleivationText.text = "Need More Elevation Power Ups";
                   elevationtext.SetActive(true);

                
                }
            
             Debug.Log("Jump");
         }

       
            if (Input.GetKeyDown(KeyCode.M)&&(!isDead)){

                menusetactive= !menusetactive;

                if(menusetactive){
                    pausemenu.SetActive(true);
                    Time.timeScale=0;
                }
                else{
                    pausemenu.SetActive(false);
                     Time.timeScale=1; 
                }
            }
        

          if (Input.GetKeyDown(KeyCode.C)){
              if(count>0){
              
                Launch();
                count--;
                SetAmmoText();
              }

          }
         //}
          //if ((Input.GetKeyDown(KeyCode.Q))&&(isDead)||(Input.GetKeyDown(KeyCode.R))&&(menusetactive)){
             if (Input.GetKeyDown(KeyCode.Q)){
                 Debug.Log("Q Hit");
                 QuitGame();
                 
                
            }
            //if ((Input.GetKeyDown(KeyCode.R))&&(isDead)||(Input.GetKeyDown(KeyCode.R))&&(menusetactive)){
                if (Input.GetKeyDown(KeyCode.R)) {
                
                  Debug.Log(" R Hit");
                  RestartGame();
                  Time.timeScale=1; 

             }
            



        
       
    }
    void FixedUpdate(){

       
         //if(!isDead){
        Vector2 movement = new Vector2(horizontal*speed,rigidbody2d.velocity.y );
         rigidbody2d.velocity = movement;
         flip(horizontal);
        //Vector2 movement = new Vector2(horizontal,0);
            if(speed> maxspeed){
                speed = 10.0f;

            }
        
          // rigidbody2d.AddForce (movement*speed);

            
        }
    //}


    void OnTriggerEnter2D(Collider2D other) {

	if (other.gameObject.CompareTag("Pickup")){
    	other.gameObject.SetActive(false);
        count ++;
        SetAmmoText();
        }
        if (other.gameObject.CompareTag("GameOver")){
            //gameObject.SetActive(false);
            
            Gameoverpanel.SetActive(true);
             Time.timeScale=0; 
            //SetGameoverText();
            isDead = true;
            
            
        }
        if (other.gameObject.CompareTag("Epickup")){
          
            other.gameObject.SetActive(false);
             Debug.Log("elivation incressed");
            //EleivationText.text =" ";
             elevationtext.SetActive(false);

            eleivation++;
            SetElevationText();
            }
        if (other.gameObject.CompareTag("Ejumbopickup")){
            other.gameObject.SetActive(false);
            eleivation =eleivation+ 3;
            //EleivationText.text =" ";
            SetElevationText();
             elevationtext.SetActive(false);

            }
        if (other.gameObject.CompareTag("Direction")){
            //DirText.text = "To exit, get to the top of the platform that was behind you at the start ";
            directionpanel.SetActive(true);

        }
        if (other.gameObject.CompareTag("Disappear")){
            //DirText.text = " ";
            directionpanel.SetActive(false);


        }

        if (other.gameObject.CompareTag("Transition")){
           SceneManager.LoadScene("Loading");
            //SceneManager.LoadScene("WiN Scene");


        }
            

           
    }



    void SetHealthText(){
        HealthText.text= "Health: "+health.ToString() +"%";
    }
    void SetElevationText(){
         EText.text = "Elevation Power Ups: "+eleivation.ToString();
    } 

    void SetAmmoText(){
          AummoText.text = "Ammo: "+ count.ToString();
          

    }
    /*void SetGameoverText(){
        GameoverText.text ="GAME OVER!";
        QuitText.text = "Hit Q to Quit";
        RestartText.text = "Hit R to Restart";
    }*/

    void Launch(){

         if(!facingRight){
            lookDirection.x =-1 ;
        }
        else{
            lookDirection.x= 1;
        }

        GameObject projectileObject = Instantiate(projectilePrefab, 
        transform.position , Quaternion.identity);

        //GameObject projectileObject = Instantiate(projectilePrefab, 
        //rigidbody2d.position + Vector2.right* 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
       
        projectile.Launch(lookDirection, 300);

    }
    public void QuitGame(){
        Application.Quit(); //quit the game
      
    }
    public void RestartGame() {
         Gameoverpanel.SetActive(false);
        health =5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public void changehealth(int amount){
        if(health >0){
        health= health - amount;
        SetHealthText();
        }
        else{
            //SetGameoverText();
            Gameoverpanel.SetActive(true);
            Time.timeScale=0; 
            isDead = true;
            
        }
          Debug.Log("healthchanged"+health);
    }

    private void flip(float horizontal){
        if(horizontal >0 && !facingRight|| horizontal<0 &&facingRight){
            facingRight=!facingRight;
            Vector3 theScale =transform.localScale;
            theScale.x *=-1;
            transform.localScale = theScale;
            /* if(!facingRight){
            lookDirection= -lookDirection;

            }*/
        }
    }



     





}
