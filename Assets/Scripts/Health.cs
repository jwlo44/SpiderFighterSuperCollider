using UnityEngine;
using System.Collections;

// keeps track of health
// to be attached to all breakables
public class Health : MonoBehaviour {
  public AudioClip DEATH_SOUND;
  public float HEALTH;
  private int INITIAL_HEALTH;

  void Start() {
    INITIAL_HEALTH = (int)HEALTH;
  }

  public void Hit(float damage)
  {
    HEALTH -= damage;
    if (HEALTH <= 0) {
      Camera.main.GetComponent<Score>().Increase(INITIAL_HEALTH);
      GameObject go = Instantiate(Resources.Load("DeathSystem")) as GameObject;
      go.transform.position = this.transform.position;
      AudioSource.PlayClipAtPoint(DEATH_SOUND, this.transform.position);
      GameObject.Destroy(gameObject);
    }

  }

}
