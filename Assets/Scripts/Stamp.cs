using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour
{

    public void SetActive(bool act) { active = act; }
    public bool GetActive() { return active; }


    private bool active = false;

    Color inactiveCol = new Color(1f, 1f, 1f, .5f);
    Color activeCol = new Color(1f, 1f, 1f, 1f);
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
        spriteRenderer.color = inactiveCol;
    }

    // Update is called once per frame
    void Update()
    {

      

    }

    private void OnMouseDown()
    {
        if (!active)
        {
            active = true;
            GameManager.instance.SetStamp(gameObject);
            spriteRenderer.color = activeCol;
        }
        else 
        {
            GameManager.instance.ResumeGame();
            active = false;
            GameManager.instance.SetStamp(null);
            spriteRenderer.color = inactiveCol;
        }
        
    }
}
