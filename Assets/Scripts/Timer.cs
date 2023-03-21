using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class Timer : MonoBehaviour
{
    
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public float currentTime;
    public Image imageComponent;
    private static int counter;
    private float finalTime;
    private bool doneTiming = false;
    private readonly int NUMBER_OF_GUESSES = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        counter = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter == NUMBER_OF_GUESSES && !doneTiming) {
            finalTime = currentTime;
            doneTiming = true;
            timerText.text = finalTime.ToString("0.00");
            scoreText.text = counter.ToString();
        } else if (!doneTiming && counter >= 0) {
            currentTime = currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("0.00");
            scoreText.text = counter.ToString();
        }
    }

    public static void UpdateCounter() {
        counter++;
    }
}
