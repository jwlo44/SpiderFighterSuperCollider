using UnityEngine;
using System.Collections;

public class Tether : MonoBehaviour
{

  public Transform objA;
  public Transform objB;
  public Vector2 vecB;
  private LineRenderer lineRenderer;

  // Use this for initialization
  void Start ()
  {
    this.lineRenderer = this.GetComponent<LineRenderer> ();
  }
  
  // Update is called once per frame
  void Update ()
  {
    this.lineRenderer.SetPosition (0, new Vector3(objA.position.x, objA.position.y, -10));
    if (objB != null) {
      this.lineRenderer.SetPosition (1, new Vector3(objB.position.x, objB.position.y, -10));
    } else {
      this.lineRenderer.SetPosition (1, vecB);
    }
  }
}