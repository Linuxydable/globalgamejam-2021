using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTile : MonoBehaviour
{
    [SerializeField] int tileNumber;
    [SerializeField] Sprite[] tiles;
    
        
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = tiles[tileNumber];
    }

    // Update is called once per frame
    
}
