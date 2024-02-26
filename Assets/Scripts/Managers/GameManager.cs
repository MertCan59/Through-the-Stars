using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public  uint score;
    public  int hp;
    public Slider slider;
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
        hp = ((int)slider.maxValue);
        SceneManager.LoadScene("Game Scene");
    }
    public int GetDamage(int damage)
    {
        hp=hp-damage;
        return hp;
    }
    public uint AddScore(uint points)
    {
        score += points;
        return score;
    }
}
