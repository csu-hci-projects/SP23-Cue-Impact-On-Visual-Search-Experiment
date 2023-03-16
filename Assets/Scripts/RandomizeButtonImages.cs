using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class RandomizeButtonImages : MonoBehaviour
{
    public string folderPath;   // path to the folder containing the images
    
    private string[] imagePaths; // array of all the image paths in the folder
    private int lastIndex = -1;  // index of the last image used
    
    void Start()
    {
        // get all the image paths in the folder
        imagePaths = Directory.GetFiles(folderPath, "*.png");
        
        // set the initial images for all the buttons
        RandomizeImages();
    }
    
    public void RandomizeImages()
    {
        // get all the buttons with an Image component on them
        Image[] images = FindObjectsOfType<Image>();
        
        // iterate through all the buttons
        for (int i = 0; i < images.Length; i++)
        {
            // check if the Image is a child of a Button
            if (images[i].GetComponentInParent<Button>() != null)
            {
                // choose a random image index that's different from the last one used
                int randomIndex = Random.Range(0, imagePaths.Length);
                while (randomIndex == lastIndex)
                {
                    randomIndex = Random.Range(0, imagePaths.Length);
                }
                lastIndex = randomIndex;
                
                // load the image and set it as the Image's sprite
                Texture2D texture = LoadImage(imagePaths[randomIndex]);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one / 2f);
                images[i].sprite = sprite;
            }
        }
    }
    
    private Texture2D LoadImage(string path)
    {
        byte[] imageData = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(imageData);
        return texture;
    }
}