using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private bool colored = false;

    RaycastHit2D desiredHit;

    public bool GetColored() { return colored; }

    public ParticleSystem colorParticles;

    private void Start()
    {
        //scribble = GameObject.FindGameObjectWithTag("Scribble");
        colorParticles = FindObjectOfType<ParticleSystem>();
    }

    private void Update()
    {
        var main = colorParticles.main;
        main.startColor = GameManager.instance.GetColor();
    }

    private void OnMouseDown()
    {
        RaycastHit2D[] hits;

        hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector2(0, 0), 1f);

        GameObject topObject = null;
        foreach (RaycastHit2D hit in hits)
        {
            if (topObject == null)
            {
                topObject = hit.collider.gameObject;
            }
            else if (hit.collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder >
                     topObject.GetComponent<SpriteRenderer>().sortingOrder)
            {
                topObject = hit.collider.gameObject;
            }
        }

        if (topObject && topObject.TryGetComponent(out Shape shape))
        {
            shape.ColorIn();
        }
    }


    private void ColorIn() 
    {
        if (!colored)
        {
            colored = true;
            AudioManager.instance.Play("First Color");
            GameManager.instance.setShapeCount();
        }

        if (!AudioManager.instance.CheckPlaying("Coloring"))
        {
            AudioManager.instance.Play("Coloring");
        }

        if (CheckParent())
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

        colorParticles.Play();
        colorParticles.gameObject.transform.position = transform.position;
    }


    private bool CheckParent() 
    {

        if (transform.childCount > 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

}
