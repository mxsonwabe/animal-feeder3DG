using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance;
  int lives { get; set; }
  int score { get; set; }
  
  void Awake()
  {
    // implement singleton pattern: Only one GameManager should exist
    if (Instance == null)
      Instance = this;
    else
      Destroy(gameObject);
  }

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    lives = 3;
    score = 0;
    Debug.Log($"Game Started — Lives: {lives}, Score: {score}");
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void AddScore()
  {
    score++;
    Debug.Log($"Score: {score}");
  }

  public void LoseLife()
  {
    lives--;
    Debug.Log($"Lives: {lives}");
    if (lives <= 0)
      GameOver();
  }

  public void GameOver() 
  {
    Debug.Log($"Game Over! Final Score: {score}");
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player) Destroy(player);
    Time.timeScale = 0f;
  }
}
