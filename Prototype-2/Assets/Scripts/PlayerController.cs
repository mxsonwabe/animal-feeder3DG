using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  float _movX, _movZ, _speed;
  float _minX, _minZ, _maxX, _maxZ;

  public GameObject groundObject;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _speed = 5.0f;
    groundObject = GameObject.FindGameObjectWithTag("Ground");
    CalculateBoundaries();
  }

  void CalculateBoundaries()
  {
    if (!groundObject) return;
    Renderer groundRenderer = groundObject.GetComponent<Renderer>();
    if (!groundRenderer) return;
    Bounds bounds = groundRenderer.bounds;
    _minX = bounds.min.x; _minZ = bounds.min.z;
    _maxX = bounds.max.x; _maxZ = bounds.max.z;

    Debug.Log($"Boundaries set: X({_minX} to {_maxX}), Z({_minZ} to {_maxZ})");
  }

  // Update is called once per frame
  void Update()
  {
        Vector3 mov = new Vector3(_movX, 0.0f, _movZ);
        // move the player
        transform.Translate(mov * _speed * Time.deltaTime);

        // get world-space coordinates for where the player is after moving
        Vector3 pos = transform.position;
        // if they are outside the boundary get the coordinates pulling them back
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        pos.z = Mathf.Clamp(pos.z, _minX, _maxZ);
        // place them in the correct position within the boundary
        transform.position = pos;
  }

  void OnMove(InputValue move)
  {
    Vector2 moveValue = move.Get<Vector2>();
    _movX = moveValue.x;
    _movZ = moveValue.y;
    Debug.Log("move: <" + moveValue.x + ", " + moveValue.y + ">");
  }
}
