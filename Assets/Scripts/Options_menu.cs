using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Options_menu : MonoBehaviour
{

    public Volume volume;
    [SerializeField] private GameObject purple_filter;
    [SerializeField] private AudioMixer audioMixer;

    private void Start() {

    }

    public void PantallaCompleta (bool pantallaCompleta) {
        Screen.fullScreen = pantallaCompleta;
    }

    public void CambiarVolumen (float nuevoVolumen) {
        audioMixer.SetFloat("Volumen", nuevoVolumen);
    }

    public void ActivarFiltro (bool filtro) {
        volume.gameObject.SetActive(filtro);
    }

}
