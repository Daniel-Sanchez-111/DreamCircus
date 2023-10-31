using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{

    [SerializeField] private GameObject activarInteraccion;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogue1;
    [SerializeField] private TMP_Text dialogue2;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.1f;

    public int idPresentador;
    public Transform playerTransform;
    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Fire2")) {
            if(!didDialogueStart) {
                StartDialogue();                
            }
            else if(dialogue1.text ==  dialogueLines[lineIndex]){
                NextDialogueLine();
            }

        }
    }
    //Funcion para iniciar el dialogo
    private void StartDialogue () {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        activarInteraccion.SetActive(false);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine(){
        lineIndex++;
        if(lineIndex<dialogueLines.Length) {
            StartCoroutine(ShowLine());
        }else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            activarInteraccion.SetActive(true);
            switch (idPresentador) {
                case 1:
                    break;
                case 2:
                    SceneManager.LoadScene(2);
                    break;
                case 3:
                    SceneManager.LoadScene(3);
                    break;
                default :
                    
                    break;
            }
        }
    }

    //Co rutina la cual escribe el texto un caracter a la vez dado un typingtime
    private IEnumerator ShowLine(){
        dialogue1.text = string.Empty;
        dialogue2.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex]) {
            dialogue1.text += ch;  
            yield return new WaitForSeconds(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        isPlayerInRange = true;
        activarInteraccion.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        isPlayerInRange = false;
        activarInteraccion.SetActive(false);
    }
}
