using UnityEngine;
using System.Collections;

// keeps track of health
// to be attached to all breakables
public class KingHealth : MonoBehaviour {
  public AudioClip DEATH_SOUND;
  public float HEALTH;
  private int INITIAL_HEALTH;
  private bool win = false;
  
  void Start() {
    INITIAL_HEALTH = (int)HEALTH;
  }
  
  public void Hit(float damage)
  {
    HEALTH -= damage;
    if (HEALTH <= 0 && !win) {
      Camera.main.GetComponent<Score>().Increase(INITIAL_HEALTH);
      GameObject go = Instantiate(Resources.Load("DeathSystem")) as GameObject;
      go.transform.position = this.transform.position;
      AudioSource.PlayClipAtPoint(DEATH_SOUND, this.transform.position);
      win = true;
      this.renderer.enabled = false;
      this.collider2D.enabled = false;
    }
  }

  public void OnGUI() {
    if (win) {
      GUI.skin.label.fontSize = 100;
      GUI.skin.label.alignment = TextAnchor.MiddleCenter;
      GUI.Label (new Rect (0, 0, Screen.width, Screen.height), "YOU'RE WIN RAR\nYAY GO TEAM!!");
    }
  }
  
}
