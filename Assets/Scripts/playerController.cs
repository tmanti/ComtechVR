using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 moveVector = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        movement();   
    }

    //TODO: change movement to facing direction of player
    //TODO: implement camera

    private void FixedUpdate()
    {
        Vector3 movement = moveVector;
        movement.Normalize();
        movement*= playerSpeed;
        transform.Translate(movement*Time.deltaTime);
    }

    void movement()
    {
        this.moveVector.x = Input.GetAxisRaw("Horizontal");
        this.moveVector.z = Input.GetAxisRaw("Vertical");
    }
}
