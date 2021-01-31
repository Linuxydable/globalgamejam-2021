using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sol_Mur : MonoBehaviour
{
    [SerializeField] int colonnes;
    [SerializeField] int lignes;
    [SerializeField] PlatformTile tile;
    [SerializeField] bool platformMakerOn = true;

    float offset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        if(!platformMakerOn) { return; };

        for (int j = 0; j < lignes; j++)
        {
            for (int i = 0; i < colonnes; i++)
            {
                //if (i == 0&j==0)
                //{
                //   Instantiate(tile, gameObject.transform);
                //}

                Vector2 newPos = new Vector2(gameObject.transform.position.x + i * offset, gameObject.transform.position.y + j * (-offset));
                PlatformTile newPlatformTile = Instantiate(tile,newPos,transform.rotation);
                newPlatformTile.transform.SetParent(gameObject.transform);
            }

        }
        
    }

    // Update is called once per frame
}
