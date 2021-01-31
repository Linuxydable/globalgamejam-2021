using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWall : MonoBehaviour
{

    public Player character;
    private SpriteRenderer m_SpriteRenderer;
    private BoxCollider2D m_boxColl;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_boxColl = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(character.isRed)
        {
            Color tmp = m_SpriteRenderer.color;
            tmp.a = 0.5f;

            m_SpriteRenderer.color = tmp;

            m_boxColl.enabled = false;
        }
        else
        {
            Color tmp = m_SpriteRenderer.color;
            tmp.a = 1f;

            m_SpriteRenderer.color = tmp;
            m_boxColl.enabled = true;
        }
    }
}
