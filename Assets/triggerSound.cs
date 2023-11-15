using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSound : MonoBehaviour
{
    public GameObject errorSound;

    public static triggerSound instance;

    void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Terrain")
        {
            errorSound.SetActive(true);
        }
    }
}
