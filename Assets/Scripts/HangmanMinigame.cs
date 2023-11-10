using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class HangmanMinigame : MonoBehaviour
{
    string[] words = { "CIRCO", "PAYASO", "CARPA", "ELEFANTE", "CABALLO", "LEON", "ESPECTACULO", "DIVERSION", "FUNCION", "AMISTAD", "DOMADOR", "MALABARISTA", "MAGIA", "ACROBATA", "APLAUSO", "PISTA"};

    [SerializeField] TMP_Text wordContainer, palabrasCompletas;

    [SerializeField] GameObject stage1, stage2, stage3, stage4, stage5, stage6, platform, player, tutorial, pantallaDerrota, pantallaVictoria;

    public int mistakes = 0, completedWords = 0;
    private bool isComplete, isGameRunning = false, isCorrect = false;
    public bool triggerAlberca = false;

    private char[] wordCh, underscores;
    private Transform playerTransform;

    public static HangmanMinigame instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        ChooseWord();
        PlayerController.instance.isSitting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {
            if (completedWords < 3)
            {
                if (mistakes < 6)
                {
                    if (isComplete)
                    {
                        wordContainer.text = "";
                        isComplete = false;
                        ChooseWord();
                    }
                }
                else
                {
                    isGameRunning = false;
                }
            }
            else
            {
                isGameRunning = false;
            }
        }
        else if (completedWords >= 3)
        {
            pantallaVictoria.SetActive(true);
        }

        if (triggerAlberca)
        {
            pantallaDerrota.SetActive(true);
        }
    }

    public void CheckLetter(string inputLetter){
        char[] letra = new char[inputLetter.Length];

        for (int i = 0; i < inputLetter.Length; i++)
        {
            letra[i] = inputLetter[i];
        }

        for (int i = 0; i < wordCh.Length; i++)
        {
            if (letra[0] == wordCh[i])
            {
                underscores[i] = letra[0];
                isCorrect = true;
            }
        }

        if (isCorrect == false)
        {
            mistakes += 1;
            CheckMistakes();
        }
        isCorrect = false;

        wordContainer.text = "";
        for (int j = 0; j < underscores.Length; j++) {
            wordContainer.text += underscores[j];
        }

        CheckWord();
    }

    public void CheckWord()
    {
        for (int i = 0; i < wordCh.Length; i++)
        {
            if (wordCh[i] == underscores[i])
            {
                isComplete = true;
            }
            else
            {
                isComplete = false;
                break;
            }
        }
        if (isComplete)
        {
            completedWords += 1;
            palabrasCompletas.text = completedWords.ToString();
        }
    }

    public void ChooseWord()
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

    public void CheckMistakes()
    {
        switch (mistakes)
        {
            case 1:
                stage1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                break;
            case 2:
                stage2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                break;
            case 3:
                stage3.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                break;
            case 4:
                stage4.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                break;
            case 5:
                stage5.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                stage5.GetComponent<Rigidbody2D>().rotation = 45f;
                break;
            case 6:
                stage6.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                stage5.GetComponent<Rigidbody2D>().rotation = 60f;
                platform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                PlayerController.instance.isSitting = false;
                break;
            default:

                break;
        }
    }

    public void GameStart()
    {
        tutorial.SetActive(false);
        isGameRunning = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void NextLevel()
    {
        GameController.second_flag = true;
        SceneManager.LoadScene(1);
    }
}
