using UnityEngine;

public class ChangeBGColor : MonoBehaviour
{

    [SerializeField]
    float duration;

    float t = 0f;
    Color color1, color2;

    void Start()
    {
        color1 = new Color(0.5f, 0.5f, 0.5f, 1);
        color2 = new Color(1, 0.92f, 0.016f, 1);

        Camera.main.backgroundColor = color1;
    }

    void Update()
    {
        if (GameManager.instance.GetBackGroundColor()) 
        {
            Color color = Color.Lerp(color1, color2, t);
            t += Time.deltaTime / duration;
            Camera.main.backgroundColor = color;
        }
    }
}