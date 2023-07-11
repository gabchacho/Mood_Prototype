using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    private void OnMouseDown()
    {
        AudioManager.instance.Play("Paint Select");
        GameManager.instance.SetColor(GetComponent<SpriteRenderer>().color);
    }
}
