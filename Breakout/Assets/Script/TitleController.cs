using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            SceneManager.LoadScene("Breakout");
        }
        
    }
}
