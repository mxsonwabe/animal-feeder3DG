using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  float _movX, _movZ, _speed;
  //float _minX, _minZ, _maxX, _maxZ;
  InputAction _attackAction;

  public GameObject projectileObject;
  //private GameObject groundObject;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _speed = 5.0f;
    _attackAction = InputSystem.actions.FindAction("Attack");
    if (_attackAction == null)
    {
      Debug.LogError("Attack Action not found. Check your Input Action Asset.", this);
      enabled = false;  // disable update() from running
      return;
    }
  }

  // Update is called once per frame
  void Update()
  {
    Move();
    if (_attackAction.WasPressedThisFrame())
    {
      // launch projectile
      Instantiate(projectileObject, transform.position + Vector3.up, projectileObject.transform.rotation);
    }
  }

  void OnMove(InputValue move)
  {
    Vector2 moveValue = move.Get<Vector2>();
    _movX = moveValue.x;
    _movZ = moveValue.y;
    //Debug.Log("move: <" + moveValue.x + ", " + moveValue.y + ">");
  }

  void Move()
  {
    Vector3 mov = new Vector3(_movX, 0.0f, _movZ);
    // move the player
    transform.Translate(mov * _speed * Time.deltaTime);

    // get world-space coordinates for where the player is after moving
    Vector3 pos = transform.position;
    // if they are outside the boundary get the coordinates pulling them back
    pos.x = Mathf.Clamp(pos.x, UtilsManager.minX, UtilsManager.maxX);
    pos.z = Mathf.Clamp(pos.z, UtilsManager.minZ, UtilsManager.maxZ);
    // place them in the correct position within the boundary
    transform.position = pos;
  }
  // just another implementation i was trying out outside of the direct action referrence. it also works.
  //void OnAttack()
  //{
  //  // Launch projectile from player
  //  Debug.Log("Attacked!");
  //}
}
