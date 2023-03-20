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
    private static int counter = 0;
    private float finalTime;
    private bool doneTiming = false;
    private readonly int NUMBER_OF_GUESSES = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter == 10 && !doneTiming) {
            finalTime = currentTime;
            doneTiming = true;
            timerText.text = finalTime.ToString("0.00");
        } else if (!doneTiming) {
            currentTime = currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("0.00");
        }
    }

    public static void UpdateCounter() {
        counter++;
    }
}
