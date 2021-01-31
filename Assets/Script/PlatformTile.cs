using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTile : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;


    [SerializeField] int tileNumber;
    [SerializeField] Sprite[] tiles;

    public bool left;
    public bool right;
    public bool up;
    public bool down;

    private Collision coll;

    private int testTile;

    [Header("Collision")]

    public float collisionRadius = 0.25f;
    public Vector2 upOffset, bottomOffset, rightOffset, leftOffset;
    private Color debugCollisionColor = Color.red;    

    // Start is called before the first frame update
    void Awake()
    {


        down = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);

        right = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer);

        left = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);

        up = Physics2D.OverlapCircle((Vector2)transform.position + upOffset, collisionRadius, groundLayer);

        if (!up)
        {
            if (!left)
            {
                Debug.Log("0");
                testTile = 0;
            }else if (!right)
            {
                Debug.Log("2");
                testTile = 2;
            }
            else
            {
                Debug.Log("1");
                testTile = 1;
            }
        }else if (!down)
        {
            if (!left)
            {
                Debug.Log("6");
                testTile = 6;
            }
            else if (!right)
            {
                Debug.Log("8");
                testTile = 8;
            }
            else
            {
                Debug.Log("7");
                testTile = 7;
            }
        }
        else
        {
            if (!left)
            {
                Debug.Log("3");
                testTile = 3;
            }
            else if (!right)
            {
                Debug.Log("5");
                testTile = 5;
            }
            else
            {
                Debug.Log("4");
                testTile = 4;
            }
        }

        
        gameObject.GetComponent<SpriteRenderer>().sprite = tiles[testTile];
    }

    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + upOffset, collisionRadius);

    }
    
}
