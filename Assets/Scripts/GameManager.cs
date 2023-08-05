using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //GENERAL VARIABLES
    public ParticleSystem completeParticles;
    public static GameManager instance;
    //private bool endGame = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject winScreen;
    
    //SOUND VARIABLES
    private string currSong;
    private string sfx;

    //COLOR VARIABLES
    private Color color = Color.gray;
    private bool backGroundColor = false;
    public Color GetColor() { return color; }
    public void SetColor(Color col) { color = col; }
    public bool GetBackGroundColor() { return backGroundColor; }

    //SHAPE VARIABLES
    public List<GameObject> allShapes;
    private int shapeCount = 0;
    public void SetShapeCount() { shapeCount++; }

    //PAUSE VARIABLES
    private bool isPaused = false;
    public bool GetPaused() { return isPaused; }
    public void SetPaused(bool pause) { isPaused = pause; }

    //SCENE VARIABLES
    private int currScene = 0;
    private string sceneName;
    public string GetSceneName() { return sceneName; }

    //STAMP VARIABLES
    private GameObject currStamp;
    public void SetStamp(GameObject st) { currStamp = st; }
    public GameObject GetStamp() { return currStamp; }

    //PARTICLES VARIABLES
    public ParticleSystem colorParticles;
    public ParticleSystem GetColorParticles() { return colorParticles; }

    //LEVEL COMPLETE VARIABLES
    private bool levelComplete = false;
    public void SetLevelComplete() { levelComplete = true; }
    public bool GetLevelComplete() { return levelComplete; }
    public GameObject finishedColoringPanel;
    public void SetFinishedColoringPanel(bool finish) { finishedColoringPanel.SetActive(finish); }
    public GameObject completeButton;

    //public bool tester = false;
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
        sceneName = SceneManager.GetActiveScene().name;

        //chooses the song depending on scene + sets num of current scene
        ChooseSong();
        AudioManager.instance.FadeIn(currSong);

        if (sfx != null) 
        {
            AudioManager.instance.FadeIn(sfx);
        }

        pauseMenuUI.SetActive(false);
        winScreen.SetActive(false);
        finishedColoringPanel.SetActive(false);
        completeButton.SetActive(false);
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

        if ((shapeCount == allShapes.Count && !levelComplete)) 
        {
            levelComplete = true;
            completeButton.SetActive(true);

            AudioManager.instance.Play("Page Complete");
        }

        if (currStamp != null) 
        {
            finishedColoringPanel.SetActive(true);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

            if (mousePosition.x < -6 || mousePosition.x > 6 || mousePosition.y < -3 || mousePosition.y > 3)
            {
            }
            else 
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    var newStamp = Instantiate(currStamp);
                    newStamp.gameObject.GetComponent<Collider2D>().enabled = false;
                    newStamp.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                    newStamp.transform.position = mousePosition;

                    if (!AudioManager.instance.CheckPlaying("Stamp Place"))
                    {
                        AudioManager.instance.Play("Stamp Place");
                    }
                }
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
        SceneManager.LoadScene("Title_Screen");
    }

    public void Quit()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void EndLevel() 
    {
        AudioManager.instance.Play("Select");

        StartCoroutine(LoadNextLevel());
    }
    public void SpawnFirework() 
    {
        completeParticles.Play();
    }

    public IEnumerator LoadNextLevel() 
    {
        currScene++;
        
        yield return new WaitForSeconds(2);

        if (AudioManager.instance.CheckPlaying(currSong))
        {
            AudioManager.instance.FadeOut(currSong);
        }

        if (AudioManager.instance.CheckPlaying(sfx))
        {
            AudioManager.instance.FadeOut(sfx);
        }

        SceneManager.LoadScene(currScene);
    }

    public void ChooseSong() 
    {
        switch (sceneName)
        {
            case "Title_Screen":
                currScene = 0;
                currSong = "Title";
                sfx = "Cicadas";
                break;
            case "First_Page":
                currScene = 1;
                currSong = "First Page Music";
                sfx = "Humming";
                break;
            case "Second_Page":
                currScene = 2;
                currSong = "By Your Side";
                sfx = "Garden";
                break;
            case "Third_Page":
                currScene = 3;
                currSong = "BYS Melancholy";
                sfx = "Heavy Rain";
                break;
            case "Fourth_Page":
                currScene = 4;
                currSong = "Fourth Page Music";
                sfx = "Wheat Wind";
                break;
            case "Fifth_Page":
                currScene = 5;
                currSong = "Fifth Page Music";
                sfx = "Family Ambience";
                break;
            case "End_Screen":
                currSong = "Title";
                sfx = "Cicadas";
                break;
            default:
                return;
        }
    }

}
