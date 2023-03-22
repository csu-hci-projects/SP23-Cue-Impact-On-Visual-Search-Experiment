using UnityEngine;
using UnityEngine.UI;

public class ButtonAudioController : MonoBehaviour {
    public string targetImageName;
    public string targetImageName2;
    public void Start () {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons) {
            Image buttonImage = button.GetComponent<Image>();
            if (buttonImage != null && buttonImage.name == targetImageName || buttonImage != null && buttonImage.name == targetImageName2) {
                AudioSource buttonAudio = button.GetComponent<AudioSource>();
                if (buttonAudio != null) {
                    buttonAudio.Play();
                }
            }
        }
    }
}
