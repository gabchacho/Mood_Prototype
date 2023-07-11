using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> allShapes;

    public static GameManager instance;
    
    private Color color = Color.gray;
    public Color GetColor() { return color; }
    public void SetColor(Color col) { color = col; }

    private int shapeCount = 0;
    public void setShapeCount() {  shapeCount++; }

    private bool backGroundColor = false;
    public bool GetBackGroundColor() { return backGroundColor; }

    private bool isPaused = false;
    public bool GetPaused() { return isPaused; }

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject winScreen;

    public bool tester = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("Sad Music");
        AudioManager.instance.FadeIn("Heavy Rain");

        pauseMenuUI.SetActive(false);
        //loseScreen.SetActive(false);
        //winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        if (shapeCount >= allShapes.Count / 2) 
        {
            backGroundColor = true;
        }

        if (shapeCount >= allShapes.Count / 1.3 || tester) 
        {
            
            AudioManager.instance.FadeOut("Heavy Rain");
            AudioManager.instance.FadeOut("Sad Music");

            if (!AudioManager.instance.CheckPlaying("Light Rain")) 
            {
                AudioManager.instance.FadeIn("Light Rain");
            }

            if (!AudioManager.instance.CheckPlaying("Humming"))
            {
                AudioManager.instance.FadeIn("Humming");
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenuUI.SetActive(false);
    }

    public void Reset()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }


  

  

}
