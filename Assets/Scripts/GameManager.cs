using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> allShapes;
    public ParticleSystem pageComplete;
    public static GameManager instance;
    public Color GetColor() { return color; }
    public void SetColor(Color col) { color = col; }
    public void setShapeCount() {  shapeCount++; }
    public bool GetBackGroundColor() { return backGroundColor; }
    public bool GetPaused() { return isPaused; }
    public void SetPaused(bool pause) { isPaused = pause; }
    public void SetStamp(GameObject st) { currStamp = st; }
    public GameObject GetStamp() { return currStamp; }
    //public GameObject complete;

    private Color color = Color.gray;
    private bool endGame = false;
    private bool isPaused = false;
    private bool backGroundColor = false;
    private int shapeCount = 0;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject winScreen;
    private GameObject currStamp;
    private int currScene = 0;

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
        winScreen.SetActive(false);
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

        if (shapeCount >= allShapes.Count / 1.3) 
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

        if ((shapeCount == allShapes.Count && !endGame) || tester) 
        {
            endGame = true;
            EndGame();
        }

        if (currStamp != null) 
        {
            PauseGame();

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var newStamp = Instantiate(currStamp);
                newStamp.transform.position = mousePosition;
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

    public void EndGame() 
    {
        if (!AudioManager.instance.CheckPlaying("Shapes Colored")) 
        {
            AudioManager.instance.Play("Shapes Colored");
        }

        winScreen.SetActive(true);

        winScreen.gameObject.GetComponent<Animator>().SetTrigger("Painting_Complete");

        tester = false;

        StartCoroutine(LoadNextLevel());
    }
    public void SpawnFirework() 
    {
        pageComplete.Play();
    }

    public IEnumerator LoadNextLevel() 
    {
        currScene++;

        yield return new WaitForSeconds(5);

        //if (SceneManager.GetSceneAt(currScene) != null)
        //{
            SceneManager.LoadScene(currScene);
        //}
        //else 
        //{
           // Reset();
        //}

    }

}
