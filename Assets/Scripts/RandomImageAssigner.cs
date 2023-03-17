using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class RandomImageAssigner : MonoBehaviour
{
    public string folderPath;
    public Image imageComponent;
    
    void Start()
    {
        // Get all image files in the specified folder
        string[] imageFiles = Directory.GetFiles(folderPath, "*.png");

        // Select a random image file
        string randomImageFile = imageFiles[Random.Range(0, imageFiles.Length)];

        // Load the selected image file as a texture
        byte[] imageData = File.ReadAllBytes(randomImageFile);
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(imageData);

        // Set the texture as the source for the image component
        imageComponent.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
}
