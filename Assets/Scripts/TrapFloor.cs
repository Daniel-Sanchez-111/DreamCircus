using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFloor : MonoBehaviour
{
    [SerializeField] GameObject trap_floor;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            trap_floor.SetActive(false);
        }
    }
}
