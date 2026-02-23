using UnityEngine;

public class DecectCollision : MonoBehaviour
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  void OnTriggerEnter(Collider other)
  {
    // Case 1: Player touches Food — do nothing, player should not be harmed
    if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Food"))
    {
      Debug.Log("Player picked up food — no damage.");
      return;
    }

    // Case 2: Food touches Animal — destroy both (the "shooting" mechanic)
    if (gameObject.CompareTag("Food") && other.gameObject.CompareTag("Animal"))
    {
      Debug.Log("Food hit an animal!");
      Destroy(gameObject);       // destroy the food projectile
      Destroy(other.gameObject); // destroy the animal
      return;
    }

    // Case 3: Player touches Animal — destroy the player (game over)
    if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Animal"))
    {
      Destroy(other.gameObject); // destroy the animal
      Destroy(gameObject);       // destroy the player
      return;
    }
  }

}
