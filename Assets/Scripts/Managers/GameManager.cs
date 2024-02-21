using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public  int score;
    public  int lives;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);  
        }
    }
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    private void Start()
    {
        NewGame();
    }
    public void NewGame()
    {
        score = 0;
        lives = 5;
        SceneManager.LoadScene("Game Scene");
    }
    public void GetDamage()
    {
        lives--;
    }
    public void IncreaseScore()
    {
        score++;
    }
}
