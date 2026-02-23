using UnityEngine;

public class AnimalController : MonoBehaviour
{
  public float speed;
  private GameObject player;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector3.forward * speed * Time.deltaTime);
    if (transform.position.z < UtilsManager.minZ)
    {
      // player dies when animal runs through
      // but we also clear the animal in the screen
      GameManager.Instance.Loselife();
      if (GameManager.Instance.lives <= 0)
      {
        Debug.Log("GameOver!!");
        Destroy(player);
      }
    }
    else if (
      transform.position.x < UtilsManager.minX ||
      transform.position.x > UtilsManager.maxX)
    {
      // animal went off screen on the side so delete it
      Destroy(gameObject);
    }
  }
}
