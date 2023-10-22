using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    public static UIController instance;

    public TMP_Text hp;
    public TMP_Text timer_tmp;

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay(){
        hp.text = PlayerHealthController.instance.currentHealth.ToString();
    }

    public void UpdateTimerDisplay() {
        timer_tmp.text = TimerController.instance.timer.ToString("f0");
    }

}
