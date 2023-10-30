using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int stars = 0;

    //public static GameController instance;

    public GameObject first_level_wall, second_level_wall, third_level_wall, fourth_level_wall, fifth_level_wall;
    public GameObject star, star2, star3, star4, star5;

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
        UpdateStarsDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStarsDisplay () {
        switch (stars) {
            case 1:
                star.SetActive(true);
                break;
            default :
                
                break;
        }
    }
}
