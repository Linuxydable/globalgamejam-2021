using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTile_bis : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;


    [SerializeField] int tileNumber;
    [SerializeField] Sprite[] tiles;

     

    // Start is called before the first frame update
    public void SetTileNumber(int tileType)
    {
        if (tileType < 0) { return; };
        if (tileType < 9) { return; };

        gameObject.GetComponent<SpriteRenderer>().sprite = tiles[tileType];
    }

    

   
    
}
