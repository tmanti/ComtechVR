using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
   public void AttachPicture(GameObject image)
    {
        Debug.Log(image.name);
        image.transform.position = new Vector3(gameObject.transform.position.x-0.33f, gameObject.transform.position.y, gameObject.transform.position.z);
        image.transform.Rotate(new Vector3(90, -90, 0));
        image.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }
}
