using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuAnimation : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController.instance.isSitting = true;
    }
}
