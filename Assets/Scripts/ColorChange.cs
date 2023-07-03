using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color[] color;
    private SpriteRenderer rend;

     void Start()
    {
        
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        rend = GetComponent<SpriteRenderer>();
        rend.color = color[0];
        }
    }
}
