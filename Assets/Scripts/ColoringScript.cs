using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class ColoringScript : MonoBehaviour
{
    [SerializeField] public Animator animator;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;

    }
    void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;

        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rend.enabled = true;
            transform.gameObject.GetComponent<SpriteRenderer>().color = GameManager.instance.GetColor();
            animator.SetBool("playing", true);
        }
    if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            
            rend.enabled = false;
            animator.SetBool("playing", false);
            
        }
    }
    
   


}






