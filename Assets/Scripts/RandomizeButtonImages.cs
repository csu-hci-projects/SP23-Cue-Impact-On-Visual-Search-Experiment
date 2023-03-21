using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections.Generic;
using static Timer;

public class RandomizeButtonImages : MonoBehaviour
{
    public string folderPath;   // path to the folder containing the images
    public ButtonImageCheck ButtonImageCheck;

    private string[] imagePaths; // array of all the image paths in the folder
    //private int lastIndex = -1;  // index of the last image used
    
    
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

        List<int> indexes = new List<int>();
        System.Random random = new System.Random();

        while (indexes.Count < 21) {
            int randomNumber = random.Next(0, 21);

            if (!indexes.Contains(randomNumber)) {
                indexes.Add(randomNumber);
            }
        }

        Debug.Log("indexes: " + indexes);

        // iterate through all the buttons
        for (int i = 0; i < images.Length; i++)
        {
            // check if the Image is a child of a Button
            if (images[i].GetComponentInParent<Button>() != null)
            {
                // choose a random image index that's different from the last one used
                /*
                int randomIndex = Random.Range(0, imagePaths.Length);
                while (randomIndex == lastIndex)
                {
                    randomIndex = Random.Range(0, imagePaths.Length);
                }
                lastIndex = randomIndex;
                
                // load the image and set it as the Image's sprite
                */
                
                int z = indexes[0];
                indexes.RemoveAt(0);
                if (indexes.Count == 0) {
                    indexes.Add(0);
                }
                Texture2D texture = LoadImage(imagePaths[z]);
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

    public void UpdateTimer() {

        if(ButtonImageCheck.CheckImage() == true) {
            Debug.Log("Images match!");
            Timer.UpdateCounter();
        } else {
            Debug.Log("Images don't match.");
        }
    
    
    }
}