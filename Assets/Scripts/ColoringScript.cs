using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class ColoringScript : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
       animator = GetComponent<Animator>();

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
            
            animator.SetTrigger("Draw");
        }
    }
    
   


}






