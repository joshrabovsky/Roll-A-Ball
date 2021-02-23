using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{

    public GameObject firstPrefab;
    public GameObject secondPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate takes three args, game object, vector3 position, quanterion
        //Quanternion is used to represent rotations
        //Identity is the identity matrix (i.e no rotation)
        Instantiate(firstPrefab, new Vector3(3f, 1f, 0f), Quaternion.identity);
        Instantiate(firstPrefab, new Vector3(-3f, 1f, 0f), Quaternion.identity);
        Instantiate(firstPrefab, new Vector3(0f, 1f, 3f), Quaternion.identity);
        Instantiate(firstPrefab, new Vector3(0f, 1f, -3f), Quaternion.identity);
        Instantiate(secondPrefab, new Vector3(3f, 1f, 2.75f), Quaternion.identity);
        Instantiate(secondPrefab, new Vector3(-3f, 1f, 2.75f), Quaternion.identity);
        Instantiate(secondPrefab, new Vector3(3f, 1f, -2.75f), Quaternion.identity);
        Instantiate(secondPrefab, new Vector3(-3f, 1f, -2.75f), Quaternion.identity);
    }

}
