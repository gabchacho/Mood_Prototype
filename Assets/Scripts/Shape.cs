using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private bool colored = false;

    RaycastHit2D desiredHit;

    public bool GetColored() { return colored; }

    public ParticleSystem colorParticles;

    private Animator anim;

    //public Material plantDefault;
    public Material plantMoving;

    private void Start()
    {
        
         colorParticles = GameManager.instance.GetColorParticles();
      

        if (GetComponent<Animator>() != null) 
        {
            anim = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        var main = colorParticles.main;
        main.startColor = GameManager.instance.GetColor();

        if (colored) 
        {
            SetAnims();
        }
    }

    private void OnMouseDown()
    {
        if (!GameManager.instance.GetPaused()) 
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
    }


    private void ColorIn() 
    {
        
        
        AudioManager.instance.Play("First Color");

        if (!colored)
        {
            colored = true;
            GameManager.instance.SetShapeCount();
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

        /*if (gameObject.tag == "Plant")
        {
            gameObject.GetComponent<SpriteRenderer>().material = plantMoving;
        }*/

        //colorParticles.GetComponent<Renderer>().sortingLayerName = "Particle";
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

    private void SetAnims() 
    {
        switch (transform.tag) 
        {
            case "Flower":
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    transform.GetChild(i).GetComponent<Animator>().SetTrigger("Flower_Colored");
                }
                break;
            /*case "Puff":
                GetComponent<Animator>().SetTrigger("Puff_Colored");
                break;
            case "Sun":
                GetComponent<Animator>().SetTrigger("Sun_Colored");
                break;
            case "Leaf":
                GetComponent<Animator>().SetTrigger("Leaf_Colored");
                break;
            case "Fruit":
                GetComponent<Animator>().SetTrigger("Fruit_Colored");
                break;
            case "Window":
                GetComponent<Animator>().SetTrigger("Window_Colored");
                break;*/
            default:
                if (anim != null) 
                {
                    GetComponent<Animator>().SetTrigger(transform.tag + "_Colored");
                }
                break;
        }
    }

}
