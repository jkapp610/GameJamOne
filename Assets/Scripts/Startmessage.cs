using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Startmessage : MonoBehaviour
{

public float  timer = 1.0f;
bool start;
public GameObject startmes;
public GameObject loading;


    // Start is called before the first frame update
    void Start()
    {
      startmes.SetActive(true);
      loading.SetActive(false);

    }  

    // Update is called once per frame
    void Update(){
        if (start){
        Vector2 position = transform.position;
        position.x = position.x +.1f;
        //position.y = position.y +.05f;
        transform.position = position;
          if(timer >0){
                timer  -= Time.deltaTime;
            }
           else {
                SceneManager.LoadScene("Level1");
                      
                }
        }
                 

        if (Input.GetKeyDown(KeyCode.S)){
            start = true;

            startmes.SetActive(false);
            loading.SetActive(true);
            

            
          


        }
    }
}
