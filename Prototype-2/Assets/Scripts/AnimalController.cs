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
      Destroy(gameObject);
      // player dies when animal runs through
      // Destroy(player);
      Debug.Log("GameOver!!");
    }
  }
}
