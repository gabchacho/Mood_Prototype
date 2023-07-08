using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class ColoringScript : MonoBehaviour
{
    
    public Renderer rend;
    //public Animator animator;
    //private Animation anim;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
       // anim = gameObject.GetComponent<Animation>();
        

    }
    void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        //transform.position = mousePosition;

        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            transform.position = mousePosition;
            transform.gameObject.GetComponent<SpriteRenderer>().color = GameManager.instance.GetColor();
            rend.enabled = true;

            //anim.Play("Drawing"); 
            //animator.SetBool("playing", true);
            //await Task.Delay(1000);


        }
    if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            
            rend.enabled = false;
            //animator.SetBool("playing", false);
            
        }
    }
    
   


}






