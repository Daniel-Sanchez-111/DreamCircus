using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangmanMinigame : MonoBehaviour
{
    string[] words = { "palabra1", "palabra2", "palabra3" };

    void Start()
    {
        Debug.Log(words[1]);
        Debug.Log(words[2]);
        Debug.Log(words[2].Length); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
