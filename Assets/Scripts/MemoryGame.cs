using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MemoryGame : MonoBehaviour
{

    public const int columns = 4;
    public const int rows = 2;

    public const float Xspace = 3f;
    public const float Yspace = -5f;

    [SerializeField] private MainImageScript startObject;
    [SerializeField] private Sprite[] images;

    [SerializeField] private GameObject tutorial;

    [SerializeField] private GameObject rightAnswerSound;
    [SerializeField] private GameObject victoriaSound;
    [SerializeField] private GameObject errorSound;

    private MainImageScript firstOpen;
    private MainImageScript secondOpen;

    private int score = 0;
    private int attempts = 0;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text attemptsText;

    private int[] Randomiser(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for (int i = 0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3 };
        locations = Randomiser(locations);

        Vector3 startPosition = startObject.transform.position;
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                MainImageScript gameImage;
                if (i == 0 && j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as MainImageScript;
                }
                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    private void Update()
    {
        if (score == 4)
        {
            victoriaSound.SetActive(true);
        }
    }



    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    public void ImageOpened(MainImageScript startObject)
    {
        rightAnswerSound.SetActive(false);
        errorSound.SetActive(false);
        if (firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId)
        {
            rightAnswerSound.SetActive(true);
            score++;
            scoreText.text = score.ToString();
        }
        else
        {
            errorSound.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            firstOpen.Close();
            secondOpen.Close();
        }

        attempts++;
        attemptsText.text = attempts.ToString();

        firstOpen = null;
        secondOpen = null;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Salir()
    {
        GameController.third_flag = true;
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {
        GameController.third_flag = true;
        SceneManager.LoadScene(1);
    }

    public void CerrarTutorial()
    {
        tutorial.SetActive(false);
    }


}
