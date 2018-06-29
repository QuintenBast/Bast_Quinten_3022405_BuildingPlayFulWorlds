using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Again : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel(0); //or whatever number your scene is

    }
}
