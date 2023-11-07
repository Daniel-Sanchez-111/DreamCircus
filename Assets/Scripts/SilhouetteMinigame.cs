using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    public bool isGameRunning;

    public static SilhouetteMinigame instance;
    public int chosenAnimal, chosenSilhouette;

    public int aciertos;

    public TMP_Text aciertos_text;

    public SpriteRenderer playerImage;

    public GameObject leon, elefante, caballo, siluetaLeon;
    public GameObject siluetaElefante, siluetaCaballo, tutorial, pantallaVictoria, pantallaDerrota;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        posicionOriginal.position = transform.position;
        allowChange = true;
        aciertos = 0;
        ChooseSilhouette();
        isGameRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameRunning) {
            if (aciertos < 3)
            {
                if (PlayerHealthController.instance.currentHealth > 0)
                {
                    if (!hasTouchedPlayer)
                    {
                        if (TimerController.instance.timer <= 0)
                        {
                            TimerController.instance.timer = 0;
                            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                            allowChange = false;
                        }
                    }
                    else
                    {
                        transform.position = posicionOriginal.position;
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
                else
                {
                    isGameRunning = false;
                    pantallaDerrota.SetActive(true);
                }
            }
            else
            {
                isGameRunning = false;
            }
        }
        else if (aciertos >= 3 && !isGameRunning)
        {
            pantallaVictoria.SetActive(true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (chosenAnimal == chosenSilhouette)
        {
            aciertos+=1;
            aciertos_text.text = aciertos.ToString();
        }
        if( chosenAnimal!=chosenSilhouette)
        {
            PlayerHealthController.instance.DealDamage();
        }
        hasTouchedPlayer = true;

    }

    public void ChooseAnimal(int animal) {
        if(allowChange) {
            ParticleSystem ps = GameObject.Find("msVFX_Stylized Smoke 1").GetComponent<ParticleSystem>();
            ps.Play();
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

    public void ChooseSilhouette(){
        //Se desactivan los gameObjects para evitar que sigan apareciendo al iniciar otra ronda.
        siluetaLeon.SetActive(false);
        siluetaElefante.SetActive(false);
        siluetaCaballo.SetActive(false);
        
        //Se obtiene un numero aleatorio del 1 al 3, despues se le asigna a la variable chosenSilhouette con la que podremos evaluar si es igual al animal elegido por el jugador.
        int randomAnimal = Random.Range(1, 4);    
        chosenSilhouette = randomAnimal;
        Debug.Log(randomAnimal);
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

    public void GameStart(){
        tutorial.SetActive(false);
        isGameRunning = true;
        TimerController.instance.isGameRunning = true;
    }

    public void NextLevel(){
        GameController.first_flag = true;
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
