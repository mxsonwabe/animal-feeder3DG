using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
  private GameObject camera;
  [SerializeField] private Transform target;
  [SerializeField] private Slider slider;
  [SerializeField] private Vector3 offset;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    slider.value = 1.0f;
    camera = GameObject.FindGameObjectWithTag("MainCamera");
  }

  // Update is called once per frame
  void Update()
  {
    transform.rotation = camera.transform.rotation;
    transform.position = target.position + offset;
  }

  public void UpdateHealthBar(float currVal, float maxVal)
  {
    slider.value = currVal / maxVal;
  }
}
