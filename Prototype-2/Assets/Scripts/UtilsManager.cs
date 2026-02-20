using UnityEngine;

public class UtilsManager : MonoBehaviour
{
  public static float minX, minZ, maxX, maxZ;

  private GameObject groundObject;

  void Awake()
  {
    InitBounds();
  }

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  void InitBounds()
  {
    groundObject = GameObject.FindGameObjectWithTag("Ground");
    if (!groundObject)
    {
      Debug.LogError("No game object with tag 'Ground' found!");
      return;
    }
    ;
    Renderer groundRenderer = groundObject.GetComponent<Renderer>();
    if (!groundRenderer) return;
    Bounds bounds = groundRenderer.bounds;
    minX = bounds.min.x; minZ = bounds.min.z;
    maxX = bounds.max.x; maxZ = bounds.max.z;

    Debug.Log($"Boundaries set: X({minX} to {maxX}), Z({minZ} to {maxZ})");

    return;
  }
}
