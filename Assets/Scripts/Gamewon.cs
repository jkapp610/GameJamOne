using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamewon: MonoBehaviour
{
    int monsterskilled = 0;

    public void CheckWin()
    {
        monsterskilled++;
        if(monsterskilled >= 5)
        {
            SceneManager.LoadScene("WiN Scene");
            Debug.Log("5");
        }
    }
}