using UnityEngine;

public class ChangeBGColor : MonoBehaviour
{

    [SerializeField]
    float duration;

    float t = 0f;
    Color color1, color2;

    private bool colorChange = false;
    //[SerializeField] float r, g, b, a;

    void Start()
    {
        color1 = new Color(0.5f, 0.5f, 0.5f, 1);
        //color2 = new Color(1, 0.92f, 0.016f, 1);
        //color2 = new Color(0, 1, 1, 0.5f);
        //color2 = new Color(r, g, b, a);
        color2 = new Color(0, 0.8f, 0.9f, 0);

        switch (GameManager.instance.GetSceneName())
        {
            case "First_Page":
                Camera.main.backgroundColor = color2;
                break;
            case "Second_Page":
                Camera.main.backgroundColor = color1;
                colorChange = true;
                break;
            default:
                Camera.main.backgroundColor = color1;
                break;
        }

    }

    void Update()
    {
        if (colorChange)
        {
            if (GameManager.instance.GetBackGroundColor())
            {
                Color color = Color.Lerp(color1, color2, t);
                t += Time.deltaTime / duration;
                Camera.main.backgroundColor = color;
            }
        }
        /*else 
        {
                Camera.main.backgroundColor = new Color(r, g, b, a);
        }
        */
    }
}