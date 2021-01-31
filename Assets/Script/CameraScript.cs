using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Player character;

    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position.x = character.transform.position.x;
        position.y = transform.position.y;
        position.z = transform.position.z;
        transform.position = position;
    }
}
