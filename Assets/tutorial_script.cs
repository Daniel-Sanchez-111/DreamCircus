using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_script : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;

    void OnTriggerEnter2D(Collider2D other)
    {
        tutorial.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        tutorial.SetActive(false);
    }
}
