using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int stars = 0;

    //public static GameController instance;

    [SerializeField] private GameObject first_level_wall, second_level_wall, demoscreen, pausescreen;
    [SerializeField] private GameObject star, star2, star3, star4, star5;

    [SerializeField] private GameObject pauseButton;

    public static bool first_flag, second_flag, third_flag, fourth_flag, fifth_flag;
    public Transform playerTransform;

    /*private void Awake() {
        instance = this;
    }*/

    void Start()
    {
        if(first_flag == true) {
            first_level_wall.SetActive(false);
            playerTransform.position = new Vector3(19, 0, 0); 
            stars += 1;
        }
        if (second_flag == true)
        {
            second_level_wall.SetActive(false);
            playerTransform.position = new Vector3(40, 0, 0);
            stars += 1;
        }
        if (third_flag == true)
        {
            playerTransform.position = new Vector3(10, 0, 0);
            demoscreen.SetActive(true);
        }
        UpdateStarsDisplay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateStarsDisplay()
    {
        switch (stars) {
            case 1:
                star.SetActive(true);
                break;
            case 2:
                star.SetActive(true);
                star2.SetActive(true);
                break;
            case 3:
                star.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                break;
            case 4:
                star.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                star4.SetActive(true);
                break;
            case 5:
                star.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                star4.SetActive(true);
                star5.SetActive(true);
                break;
            default :
                
                break;
        }
    }


    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        pausescreen.SetActive(true);
        PlayerController.instance.moveSpeed = 0;
        pauseButton.SetActive(false);
    }

    public void Resume()
    {
        pausescreen.SetActive(false);
        PlayerController.instance.moveSpeed = 3;
        pauseButton.SetActive(true);
    }


}
