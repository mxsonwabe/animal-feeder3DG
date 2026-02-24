using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnimalHealthBar : MonoBehaviour
{

  public Slider healthBarSlider;
  public int maxHealthLevel;

  public int currentHealth;
  //private GameManager gameManager;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    healthBarSlider.maxValue = maxHealthLevel;
    healthBarSlider.value = 0;
    healthBarSlider.fillRect.gameObject.SetActive(false);
    //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void ApplyDamage(int amount)
  {
    currentHealth += amount;
    healthBarSlider.fillRect.gameObject.SetActive(true);
    healthBarSlider.value += currentHealth;

    if (currentHealth > maxHealthLevel)
    {
      GameManager.Instance.AddScore();
      Destroy(gameObject, 0.1f);
    }
  }
}
