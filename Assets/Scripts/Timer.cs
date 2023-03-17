using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class Timer : MonoBehaviour
{
    
    public TextMeshProUGUI timerText;
    public float currentTime;
    public Image imageComponent;
    private int counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counter == 10) {
            
        } else {
        currentTime = currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("0.00");
        }
    }
}
