using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody _rb;
    private int _count;

    // Start is called before the first frame update
    void Start()
    {
        //Set to the rigid body component
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        winText.text = "";
        SetCountText();
    }

    // Physics updates (Force, collisions, etc.) are called after a Fixed Update
    // According to the docs, this is called every 0.02 seconds
    // The purpuse is to distinguish the intention of action between Physics and other updates
    void FixedUpdate()
    {
        //Accessing the z-axis movements
        float moveVertical = Input.GetAxis("Vertical");
        //Acessing the x-axis movements
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Y-Axis is not accessed as there should never be player movement in the y-axis

        //Creates a 3D vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Change the force 
        _rb.AddForce(movement*speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //When the trigger property is set, the item does not recognize collisions
        //with incoming bodies
        //Instead methods (OnTriggerEnter, OnTriggerExit, OnTriggerStay) perform a
        //seprate action in the script

        //Adding points based on tags (each prefab should have a unique tag)
        //Selecting the game object, and seeing which tag it has
        if (other.gameObject.CompareTag("Spike"))
        {
            _count += 1;
            //removing the prefab from the game
            DestroyObj(other);
        }
        else if (other.gameObject.CompareTag("Molecule"))
        {
            _count += 3;
            //removing the prefab from the game
            DestroyObj(other);
        }
        SetCountText();
    }

    //This destorys the game object and removes it from the scene view
    private void DestroyObj(Collider other)
    {
        Destroy(other.gameObject);
    }

    //Setting the count text
    private void SetCountText()
    {
        //setting the text
        countText.text = "Count: " + _count.ToString();
        //if win want to clear count text, set win text, and restart
        if (_count >= 16)
        {
            winText.text = "You Win!";
            countText.text = "";
            //Invoke calls the method name after the specified number in seconds
            //In this case restart will be called after 3 secodns
            Invoke("Restart",3);
        }
    }

    private void Restart()
    {
        //Scene Manager Allows for scene management at run time
        //One method is load scene,
        //which loads the scene of the specified name (String) as an arg
        //.GetActiveScene() returns the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}