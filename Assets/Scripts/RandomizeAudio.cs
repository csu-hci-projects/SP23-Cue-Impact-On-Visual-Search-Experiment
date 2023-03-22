using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections.Generic;
using static Timer;

public class RandomizeAudio : MonoBehaviour
{
    public string folderPath;   // path to the folder containing the images
    public string symbolToFindName;
    public string symbolToFindName2;
    public AudioSource audioSource;
    private string[] imagePaths; // array of all the image paths in the folder
    public Button thisButton;
    private string imageName;
    public Image image;
    


    
    //private int lastIndex = -1;  // index of the last image used

    //Plays the audio of where it was previously
    
    void Start()
    {
        // get all the image paths in the folder
        imagePaths = Directory.GetFiles(folderPath, "*.png");
        // set the initial images for all the buttons
        //RandomizeImages();
    }

    void Update() {
         imageName = image.sprite.name;
         
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
                String imagePathName = imagePaths[z];
                Debug.Log("Sprite Path: " + imagePaths[z]);
                images[i].sprite = sprite;
                sprite.name = imagePathName.Substring(imagePathName.LastIndexOf('\\') + 1);
            }
        }
        //COME BACK TO THIS WHAT WE SHOULD DO IS AFTER THIS CHECK ALL THE BUTTONS AND IF THEY ARE A TRIANGLE PLAY THEIR SOUND!
    }
    
    private Texture2D LoadImage(string path)
    {
        byte[] imageData = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(imageData);
        return texture;
    }

    public void UpdateTimer() {
        if(imageName.Equals(symbolToFindName) || imageName.Equals(symbolToFindName2)) {
            Timer.UpdateCounter();
        } 
    }
}