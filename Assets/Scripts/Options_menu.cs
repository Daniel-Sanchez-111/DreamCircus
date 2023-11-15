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
    [SerializeField] private AudioMixer audioMixerEfectos;
    [SerializeField] private AudioMixer audioMixerMusica;

    [SerializeField] private Toggle fullscreen, filter;
    [SerializeField] private Slider volumenSliderEfectos;
    [SerializeField] private Slider volumenSliderMusica;


    private void Start() {
        LoadPrefs();
    }

    public void PantallaCompleta (bool pantallaCompleta) {
        Screen.fullScreen = pantallaCompleta;
        PlayerPrefs.SetInt("pantallaCompleta", pantallaCompleta ? 1 : 0);
    }

    public void CambiarVolumenEfectos(float nuevoVolumen)
    {
        audioMixerEfectos.SetFloat("Volumen", nuevoVolumen);
        PlayerPrefs.SetFloat("VolumenEfectos", nuevoVolumen);

    }

    public void CambiarVolumenMusica(float nuevoVolumen)
    {
        audioMixerMusica.SetFloat("Volumen", nuevoVolumen);
        PlayerPrefs.SetFloat("VolumenMusica", nuevoVolumen);

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
        float nuevoVolumenEfectos = PlayerPrefs.GetFloat("VolumenEfectos", 50);
        float nuevoVolumenMusica = PlayerPrefs.GetFloat("VolumenMusica", 50);
        bool filtro = PlayerPrefs.GetInt("filtro") == 1;
        Screen.fullScreen = pantallaCompleta;
        audioMixerEfectos.SetFloat("Volumen", nuevoVolumenEfectos);
        audioMixerMusica.SetFloat("Volumen", nuevoVolumenMusica);
        volume.gameObject.SetActive(filtro);
        fullscreen.isOn = pantallaCompleta;
        filter.isOn = filtro;
        volumenSliderEfectos.value = nuevoVolumenEfectos;
        volumenSliderMusica.value = nuevoVolumenMusica;
    }
}
