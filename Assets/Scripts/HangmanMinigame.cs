using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HangmanMinigame : MonoBehaviour
{
    string[] words = { "CIRCO", "PAYASO", "CARPA", "ELEFANTE", "CABALLO", "LEON", "ESPECTACULO", "DIVERSION", "FUNCION", "AMISTAD", "DOMADOR", "MALABARISTA", "MAGIA", "ACROBATA", "APLAUSO", "PISTA"};

    [SerializeField] TMP_Text wordContainer;

    private char[] wordCh, underscores;
    void Start()
    {
        int randomNumber = Random.Range(0, 16);
        string randomWord = words[randomNumber];
        wordCh = new char[randomWord.Length];
        underscores = new char[randomWord.Length];

        for (int i = 0; i < randomWord.Length; i++)
        {
            wordCh[i] = randomWord[i];
            underscores[i] = '_';
            wordContainer.text += underscores[i].ToString();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckLetter(string inputLetter){
        char[] letra = new char[inputLetter.Length];
        for (int i = 0; i < inputLetter.Length; i++)
        {
            letra[i] = inputLetter[i];
        }
        for(int i = 0; i < wordCh.Length; i++) {
            if (letra[0] == wordCh[i])
            {
                underscores[i] = letra[0];
            }
        }
        wordContainer.text = "";
        for (int j = 0; j < underscores.Length; j++) {
            wordContainer.text += underscores[j];
        }
    }
}
