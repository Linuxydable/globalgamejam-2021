using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrallaxScroller : MonoBehaviour
{
    [SerializeField] float ParrallaxFactor = 1f;
    Material myMaterial;
    Vector2 offset;

    private Transform cam;
    private Vector3 previousCamPosition;

    // Start is called before the first frame update

    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        previousCamPosition = cam.position;
        myMaterial = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2((previousCamPosition.x - cam.position.x)* ParrallaxFactor, 0);
        //Debug.Log("l'offset est de" + offset.ToString());
            

        myMaterial.mainTextureOffset -= offset*0.001f ;
        previousCamPosition = cam.position;
    }
}