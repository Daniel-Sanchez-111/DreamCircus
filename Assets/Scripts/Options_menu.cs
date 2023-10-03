using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
public class Options_menu : MonoBehaviour
{
    public TMP_Dropdown res_dropdown;
    Resolution[] resolutions;
    [SerializeField] private AudioMixer audioMixer;

    public void PantallaCompleta (bool pantallaCompleta) {
        Screen.fullScreen = pantallaCompleta;
    }

    public void CambiarVolumen (float nuevoVolumen) {
        audioMixer.SetFloat("Volumen", nuevoVolumen);
    }
}