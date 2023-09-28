using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    private bool isPlayerInRange;
    private Animator animator;

    [SerializeField] private AnimationClip animacionFinal;

    private void Start () {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if(isPlayerInRange) {
            StartCoroutine(CambiarEscena());
        }
    }

    IEnumerator CambiarEscena(){

        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInRange = false;
    }
}
