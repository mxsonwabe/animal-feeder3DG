using System.Net;
using UnityEngine;

public class DecectCollision : MonoBehaviour
{
  PlayerController playerController;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    playerController = GetComponent<PlayerController>();
    Debug.Log("Getting Health bar");
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
      Destroy(gameObject);       // destroy the food projectile
      AnimalController animalController = other.GetComponent<AnimalController>();
      if (!animalController)
        Debug.LogError("No COntrooler");
      if (animalController)
      {
        Debug.Log("Animal Controller: Food hit an animal!");
        if (!animalController.ApplyDamage())
        {
          Debug.Log("Food hit an animal!");
          GameManager.Instance.AddScore();
          Destroy(other.gameObject); // destroy the animal
        }
      }
      return;
    }

    // Case 3: Player touches Animal — destroy the player (game over)
    if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Animal"))
    {
      GameManager.Instance.LoseLife();
      if (playerController)
        playerController.TriggerBounce(other.gameObject.transform.position);
      Destroy(other.gameObject); // destroy the animal
      return;
    }
  }

}
