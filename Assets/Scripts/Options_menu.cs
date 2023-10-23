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

    [SerializeField] private Toggle fullscreen, filter;
    [SerializeField] private Slider volumenSlider;

    private void Start() {
        LoadPrefs();
    }

    public void PantallaCompleta (bool pantallaCompleta) {
        Screen.fullScreen = pantallaCompleta;
        PlayerPrefs.SetInt("pantallaCompleta", pantallaCompleta ? 1 : 0);
    }

    public void CambiarVolumen (float nuevoVolumen) {
        audioMixer.SetFloat("Volumen", nuevoVolumen);
        PlayerPrefs.SetFloat("nuevoVolumen", nuevoVolumen);
        
    }

    public void ActivarFiltro (bool filtro) {
        volume.gameObject.SetActive(filtro);
        PlayerPrefs.SetInt("filtro", filtro ? 1 : 0);
    }

    public void SavePrefs () {
        PlayerPrefs.Save();
    }

    public void LoadPrefs () {
        bool pantallaCompleta = PlayerPrefs.GetInt("pantallaCompleta") == 1;
        float nuevoVolumen = PlayerPrefs.GetFloat("nuevoVolumen",50);
        bool filtro = PlayerPrefs.GetInt("filtro") == 1;
        Screen.fullScreen = pantallaCompleta;
        audioMixer.SetFloat("Volumen", nuevoVolumen);
        volume.gameObject.SetActive(filtro);
        fullscreen.isOn = pantallaCompleta;
        filter.isOn = filtro;
        volumenSlider.value = nuevoVolumen;
    }
}
