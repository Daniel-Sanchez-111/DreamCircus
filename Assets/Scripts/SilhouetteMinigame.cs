using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilhouetteMinigame : MonoBehaviour
{
    // DECLARACION DE VARIABLES


    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform posicionOriginal;

    [SerializeField]
    private GameObject humo;

    public bool hasTouchedPlayer;

    public bool allowChange;

    public int chosenAnimal, chosenSilhouette, wins;

    public SpriteRenderer playerImage;

    public GameObject leon, elefante, caballo, siluetaLeon, siluetaElefante, siluetaCaballo;

    public static SilhouetteMinigame instance;
    

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        posicionOriginal.position = transform.position;
        Debug.Log(posicionOriginal.position.x);
        allowChange = true;
        wins = 0;
        ChooseSilhouette();
    }

    // Update is called once per frame
    void Update()
    {
        if(wins<3) {
            if (PlayerHealthController.instance.currentHealth > 0)
            {
                if (!hasTouchedPlayer)
                {
                    if (TimerController.instance.timer <= 0)
                    {
                        humo.SetActive(false);
                        TimerController.instance.timer = 0;
                        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                        allowChange = false;
                    }
                }
                else
                {
                    transform.position = posicionOriginal.position;
                    if (transform.position == posicionOriginal.position)
                    {
                        leon.SetActive(false);
                        elefante.SetActive(false);
                        caballo.SetActive(false);
                        playerImage.GetComponent<Renderer>().enabled = true;
                        hasTouchedPlayer = false;
                        TimerController.instance.timer = 10;
                        allowChange = true;
                        chosenAnimal = 0;
                        ChooseSilhouette();
                    }

                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (chosenAnimal == chosenSilhouette)
        {
            wins+=1;
            UIController.instance.UpdateWinsDisplay();
            Debug.Log("WINS: "+ wins);
        }
        else
        {
            PlayerHealthController.instance.DealDamage();
        }
        hasTouchedPlayer = true;

    }

    public void ChooseAnimal(int animal) {
        if(allowChange) {
            humo.SetActive(true);
            playerImage.enabled = false;
            chosenAnimal = animal;
            Debug.Log("CHA: Animal" + chosenAnimal);
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

    public void ChooseSilhouette(){
        //Se desactivan los gameObjects para evitar que sigan apareciendo al iniciar otra ronda.
        siluetaLeon.SetActive(false);
        siluetaElefante.SetActive(false);
        siluetaCaballo.SetActive(false);
        
        //Se obtiene un numero aleatorio del 1 al 3, despues se le asigna a la variable chosenSilhouette con la que podremos evaluar si es igual al animal elegido por el jugador.
        int randomAnimal = Random.Range(1, 3);    
        chosenSilhouette = randomAnimal;

        //Se utiliza un switch para evaluar el numero aleatorio, dependiendo del resultado se activa dicho gameObject.
        switch (randomAnimal) {
            case 1:
                siluetaLeon.SetActive(true);
                break;
            case 2:
                siluetaElefante.SetActive(true);
                break;
            case 3:
                siluetaCaballo.SetActive(true);
                break;
            default :
                
                break;
        }
    }

}