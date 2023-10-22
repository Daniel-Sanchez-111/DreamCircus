using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilhouetteMinigame : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasTouchedPlayer;
    public bool allowChange;

    public int chosenAnimal;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform posicionOriginal;

    public SpriteRenderer playerImage;

    public GameObject leon, elefante, caballo;

    [SerializeField] private GameObject humo;
    
    void Start()
    {
        posicionOriginal.position = transform.position;
        Debug.Log(posicionOriginal.position.x);
        allowChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHealthController.instance.currentHealth>0) {
            if (!hasTouchedPlayer)
            {          
                if (TimerController.instance.timer<=0) {
                    humo.SetActive(false);
                    TimerController.instance.timer = 0;
                    transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                    allowChange = false;
                }
            }
            else
            {
                transform.position = posicionOriginal.position;
                if (transform.position == posicionOriginal.position) {
                    playerImage.GetComponent<Renderer>().enabled = true;
                    hasTouchedPlayer = false;
                    TimerController.instance.timer = 10;
                    allowChange = true;
                }
                
            }
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasTouchedPlayer = true;
    }

    public void ChooseAnimal(int animal) {
        if(allowChange) {
            humo.SetActive(true);
            playerImage.enabled = false;
            chosenAnimal = animal;
            allowChange = false;
            switch (animal)
            {
                case 1:
                    leon.SetActive(true);
                    break;
                case 2:
                    elefante.SetActive(true);
                    break;
                case 3:
                    caballo.SetActive(true);
                    break;
                default:

                    break;
            }
            
        }
        
    }



}
