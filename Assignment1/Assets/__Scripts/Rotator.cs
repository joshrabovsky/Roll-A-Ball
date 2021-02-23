using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Transform is automatically attached to the game object which uses the script
        //How much we want to rotate is determined by the vector
        //Vector * scalar = Vector -> Time.deltaTime is the time between frames and
        //it is used to rotate the prefabs more slowly
        transform.Rotate(new Vector3(45, 30, 15) * Time.deltaTime);
    }
}
