using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private GameObject scribble;
    //public Animator anim;

    private bool colored = false;

    private float zVal = 0.0f;
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

        /*if (Input.GetMouseButtonDown(0)) 
        {
           
        }*/
    }

    private void OnMouseDown()
    {
        /*if (gameObject.tag == "Top")
        {
            ColorIn();
        }
        else 
        {
            ColorIn();
        }*/

        /*RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            //Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
            ColorIn();
        }*/


        RaycastHit2D[] hits;

        hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector2(0, 0), 1f);

        if (hits.Length > 1) 
        {
            foreach (RaycastHit2D hit in hits)
            {

                /*if (hit.collider.gameObject.transform.position.z > zVal)
                {
                    desiredHit = hit;
                    zVal = hit.collider.gameObject.transform.position.z;
                }*/

                if (hit.collider.gameObject.tag == "Top")
                {
                    gameObject.GetComponent<Shape>().ColorIn();
                }
                

            }

            /*if (desiredHit.collider.gameObject.transform.position.z == zVal) 
            {
                ColorIn();
            }*/
        }
        else
        {
            ColorIn();
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

        //Instantiate(scribble);
        //scribble.transform.position = transform.position;

        //scribble.gameObject.GetComponent<Animator>().SetBool("playing", true);*/

        //colorParticles.startColor = GameManager.instance.GetColor();
        colorParticles.Play();
        colorParticles.gameObject.transform.position = transform.position;
    }
}
