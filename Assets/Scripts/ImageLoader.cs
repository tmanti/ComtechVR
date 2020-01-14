using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader
{
    public static string ImageFolderPath = Application.dataPath + "/Images/";

    public static Texture2D[] initImages()
    {
        string[] files = Directory.GetFiles(ImageFolderPath);
        List<Texture2D> texList = new List<Texture2D>();

        foreach(string str in files)
        {
            if (str.EndsWith("png") || str.EndsWith("jpg"))
            {
                try
                {
                    texList.Add(LoadPNG(str));
                } catch(IOException e)
                {
                    Debug.LogError(e);
                }
            }

        }
           
        return texList.ToArray();
    }

    public static Texture2D LoadPNG(string filePath)
    {
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }
}
