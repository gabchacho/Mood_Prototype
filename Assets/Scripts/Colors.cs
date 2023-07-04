using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.instance.SetColor(GetComponent<SpriteRenderer>().color);
    }
}
