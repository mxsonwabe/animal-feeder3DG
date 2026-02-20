
using UnityEngine;
public class ProjectileController : MonoBehaviour
{
  float _speed;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _speed = 20.0f;
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    if (transform.position.z > UtilsManager.maxZ)
    {
      Destroy(gameObject);
    }

  }
}
