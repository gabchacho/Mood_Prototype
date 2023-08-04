using UnityEngine;

public class ChangeBGColor : MonoBehaviour
{

    [SerializeField]
    float duration;

    float t = 0f;
    Color gray, blue, oldColor, newColor;
    private bool colorChange = false;
    //[SerializeField] float r, g, b, a;

    void Start()
    {
        gray = new Color(0.5f, 0.5f, 0.5f, 1);
        blue = new Color(0, 0.8f, 0.9f, 0);

        switch (GameManager.instance.GetSceneName())
        {
            case "First_Page":
                Camera.main.backgroundColor = blue;
                break;
            case "Second_Page":
                Camera.main.backgroundColor = blue;
                oldColor = blue;
                newColor = Color.green;
                colorChange = true;
                break;
            case "Third_Page":
                Camera.main.backgroundColor = gray;
                break;
            case "Fourth_Page":
                Camera.main.backgroundColor = gray;
                oldColor = gray;
                newColor = Color.green;
                colorChange = true;
                break;
            case "Fifth_Page":
                Camera.main.backgroundColor = Color.green;
                break;
            default:
                Camera.main.backgroundColor = blue;
                break;
        }

    }

    void Update()
    {
        if (colorChange)
        {
            if (GameManager.instance.GetBackGroundColor())
            {
                Color color = Color.Lerp(oldColor, newColor, t);
                t += Time.deltaTime / duration;
                Camera.main.backgroundColor = color;
            }
        }
    }
}