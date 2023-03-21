using UnityEngine;
using UnityEngine.UI;

public class ButtonImageCheck : MonoBehaviour
{
    public Image targetImage; // The specific image to check against
    
    private Image buttonImage; // The image on the button

    private void Start()
    {
        // Get the image component on the button
        buttonImage = GetComponent<Image>();
    }

    public bool CheckImage()
    {
        
        buttonImage = GetComponent<Image>();
        // Check if the button image is the same as the target image
        if (buttonImage == targetImage)
        {
            // Do something here if the images match
            Debug.Log("Images match!");
            return true;
        }
        else
        {
            // Do something here if the images don't match
            return false;
        }
    }
}
