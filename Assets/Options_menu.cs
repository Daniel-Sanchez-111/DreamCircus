using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Options_menu : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;

    public void PantallaCompleta (bool pantallaCompleta) {
        Screen.fullScreen = pantallaCompleta;
    }

    public void CambiarVolumen (float nuevoVolumen) {
        audioMixer.SetFloat("Volumen", nuevoVolumen);
    }
}
