using UnityEngine;
using System.Collections;

public class EmitEnemy : MonoBehaviour {

  public GameObject go;
  public float intiCooldown;
  private float coolDown;

	// Use this for initialization
	void Start () {
    coolDown = intiCooldown;
	}
	
	// Update is called once per frame
	void Update () {
    if (coolDown < 0) {
      GameObject.Instantiate(go);
      go.transform.position = this.transform.position;
      coolDown = intiCooldown;
    }
    coolDown--;
	}
}
