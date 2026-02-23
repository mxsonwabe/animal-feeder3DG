using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance;
  public float lives { get; private set; }
  public float score { get; private set; }
  
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

  public void Loselife()
  {
    lives--;
    Debug.Log($"Lives: {lives}");
    if (lives == 0)
    {
      Debug.Log($"Gameover: {lives}");
      Debug.Log($"Score: {score}");
    }
  }
}
