using UnityEngine;
// keeps track of health
// to be attached to all breakables
public class PlayerHealth : MonoBehaviour {
  public AudioClip SPIDER_HURT_SOUND;
  public float HEALTH;
  public bool isDead = false;
  
  void Start() {

  }
  
  public void Hit(float damage)
  {
    AudioSource.PlayClipAtPoint(SPIDER_HURT_SOUND, transform.position);
    HEALTH -= damage;
    if (HEALTH <= 0 && !isDead) {
      GameObject go = Instantiate(Resources.Load("DeathSystem")) as GameObject;
      go.transform.position = this.transform.position;
      this.isDead = true;
      this.rigidbody2D.velocity = Vector2.zero;
      this.rigidbody2D.isKinematic = true;
      this.renderer.enabled = false;
      this.GetComponent<Movement>().enabled = false;
      this.GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Destroy(GameObject.Find("Ball"));
      GameObject.Destroy(GameObject.Find("Tail"));
    }
  }

  public void OnGUI() {
    string str = "Health: " + HEALTH.ToString();
    GUI.Label (new Rect (200, 0, 100, 20), str);
  }
}