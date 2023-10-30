using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangmanMinigame : MonoBehaviour
{
    string[] words = { "Circo", "Payaso", "Carpa", "Elefante", "Caballo", "Leon", "Espectaculo", "Diversion", "Funcion", "Amistad", "Domador", "Malabarista", "Magia", "Acrobata", "Aplauso", "Pista"};

    void Start()
    {
        int randomWord = Random.Range(1, 4);
        Debug.Log(words[1]);
        Debug.Log(words[2]);
        Debug.Log(words[2].Length); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
