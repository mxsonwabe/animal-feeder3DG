using UnityEngine;

public class Utils
{
   public static float minX, minZ, maxX, maxZ;
  public static bool ON = false;
   
  private static GameObject groundObject = GameObject.FindGameObjectWithTag("Ground");

  public static bool InitBounds()
  {
    if (!groundObject)
    {
      Debug.LogError("No game object with tag 'Ground' found!");
      return false;
    };
   Renderer groundRenderer = groundObject.GetComponent<Renderer>();
    if (!groundRenderer) return false; 
    Bounds bounds = groundRenderer.bounds;
    minX = bounds.min.x; minZ = bounds.min.z;
    maxX = bounds.max.x; maxZ = bounds.max.z;

    Debug.Log($"Boundaries set: X({minX} to {maxX}), Z({minZ} to {maxZ})");

    ON = true;
    return true;
  }
}
