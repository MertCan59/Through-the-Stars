using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public  uint score;
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
        lives = 3;
        SceneManager.LoadScene("Game Scene");
    }
    public void GetDamage()
    {
        lives--;
    }
    public uint AddScore(uint points)
    {
        score += points;
        return score;
    }
}
