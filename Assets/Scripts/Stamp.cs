using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour
{

    public void SetActive(bool act) { active = act; }
    public bool GetActive() { return active; }


    private bool active = false;
    private Vector3 origScale;

    Color inactiveCol = new Color(1f, 1f, 1f, 0);
    Color activeCol = new Color(1f, 1f, 1f, 1f);
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
        spriteRenderer.color = inactiveCol;
        origScale = transform.localScale;
    }

    private void Update()
    {
        if (GameManager.instance.GetLevelComplete()) 
        {
            spriteRenderer.color = activeCol;
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.GetLevelComplete())
        {
            if (!active)
            {
                active = true;
                transform.localScale += new Vector3(0.1f, 0.1f, 0);
                GameManager.instance.SetFinishedColoringPanel(true);
                GameManager.instance.SetStamp(gameObject);
            }
            else 
            {
                active = false;
                transform.localScale = origScale;
                GameManager.instance.SetFinishedColoringPanel(false);
                GameManager.instance.SetStamp(null);
            }
        }
    }
}
