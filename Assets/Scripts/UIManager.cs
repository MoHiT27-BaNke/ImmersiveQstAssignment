using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Score Stuff")]
    public Text scoreText;
    private int score = 0;


    [Space(50)]
    [Header("Results")]
    public GameObject resultPanel;
    public Button restarButton;
    public Text resultScoreText;
    public Text resultEnemyKilledText;


    [Space(50)]
    [Header("Sound Stuff")]
    public AudioSource audioSource;

    [Space(50)]
    [Header("Enemy Stuff")]
    public int enemyKilledCount;
    public const int totalEnemy = 8;
    public Material killedMaterial;

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        restarButton.onClick.AddListener(() => { SceneManager.LoadScene("Assignment");});
    }


    public void UpdateScoreUI(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
        enemyKilledCount++;
        if (enemyKilledCount == totalEnemy)
        {
            resultScoreText.text = "Total Score:"+ score.ToString();
            resultEnemyKilledText.text = "Enemy Killed:"+ totalEnemy.ToString();
            resultPanel.SetActive(true);
        }
    }
    public void PlayeAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
