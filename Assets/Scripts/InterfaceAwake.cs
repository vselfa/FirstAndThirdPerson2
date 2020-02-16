using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To manage scenes 
using UnityEngine.SceneManagement;

public class InterfaceAwake : MonoBehaviour {

   public void GoFirstPerson ()    {
        SceneManager.LoadScene ("FirstPerson");
    }

    public void GoThirdPerson ()    {
        SceneManager.LoadScene ("ThirdPerson");
    }

    public void GoAwake ()    {
        SceneManager.LoadScene ("Awake");
    }
}

