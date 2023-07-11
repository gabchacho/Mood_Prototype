using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    [SerializeField]
    float duration;

    float t = 0f;
    Color color1, color2;

    void Start()
    {
        color1 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        color2 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
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