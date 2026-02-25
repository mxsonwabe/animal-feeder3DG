using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
  [SerializeField] private Slider slider;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    slider.value = 1.0f;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void UpdateHealthBar(float currVal, float maxVal)
  {
    slider.value = currVal / maxVal;
  }
}
