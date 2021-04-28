using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerwin : MonoBehaviour
{
    public Text YouWin;
     public Text RestartText;
    // Start is called before the first frame update
    void Start()
    {
        YouWin.text = " "; 
        RestartText.text =" ";
    }

    // Update is called once per frame
    void Update()
    {
       Vector2 position = transform.position;
        position.x = position.x + .0001f;
        position.y = position.y +0.005f;
        transform.position = position;
        updateText(); 
         if (Input.GetKeyDown(KeyCode.R)){
              SceneManager.LoadScene("Start Scene");
         } 
    }

    void updateText(){
        YouWin.text = "You WIN!!!";
        RestartText.text ="TO Restart Hit R";

    }
}
