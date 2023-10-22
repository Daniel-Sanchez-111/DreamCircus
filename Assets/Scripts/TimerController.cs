using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public float timer = 10;

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(timer>0){
            timer -= Time.deltaTime;
            UIController.instance.UpdateTimerDisplay();
        }
        
    }
}
