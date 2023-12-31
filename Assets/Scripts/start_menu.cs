using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start_menu : MonoBehaviour
{
     private Animator animator;

    [SerializeField] private AnimationClip animacionFinal;

    private void Start () {
        animator = GetComponent<Animator>();
    }
    public void Jugar () {
        GameController.first_flag = false;
        GameController.second_flag = false;
        GameController.third_flag = false;
        GameController.fourth_flag = false;
        GameController.fifth_flag = false;
        StartCoroutine(CambiarEscena());
    }

    public void Salir () {
        Debug.Log("Saliendo");
        Application.Quit();
    }

    IEnumerator CambiarEscena(){

        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
