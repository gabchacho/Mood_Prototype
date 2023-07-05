using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private void OnMouseDown()
    {

        if (!AudioManager.instance.CheckPlaying("Coloring")) 
        {
            AudioManager.instance.Play("Coloring");
        }

        if (transform.childCount > 0)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = GameManager.instance.GetColor();
                }
            }
        }
        else 
        {
            GetComponent<SpriteRenderer>().color = GameManager.instance.GetColor();
        }
    }
}
