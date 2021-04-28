using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    public float  timer = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        Vector2 position = transform.position;
        position.x = position.x +.2f;
        //position.y = position.y +.05f;
        transform.position = position;
          if(timer >0){
                timer  -= Time.deltaTime;
            }
           else {
                SceneManager.LoadScene("Level2");
                      
                }
          
    }
}
