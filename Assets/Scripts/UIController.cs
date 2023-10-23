using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    public static UIController instance;

    public TMP_Text hp, timer_tmp;

    private void Awake() {
        instance = this;
    }

    public void UpdateHealthDisplay(){
        hp.text = PlayerHealthController.instance.currentHealth.ToString();
    }

    public void UpdateTimerDisplay() {
        timer_tmp.text = TimerController.instance.timer.ToString("f0");
    }


}
