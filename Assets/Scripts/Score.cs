using UnityEngine;
using System.Collections;

// keeps track of score
// to be attached to a GUIText
public class Score : MonoBehaviour {
 
  private int SCORE;
  public int TIME_LIMIT;
  public AudioClip HURRY_MUSIC;
  private bool boss = false;
  
  public void Increase(int points)
  {
    SCORE += points;
  }

  public void OnGUI() {
    if (GameObject.Find ("Spider").GetComponent<PlayerHealth> ().isDead) {
      string str2 = "GAME OVER\nYou're Score is: " + SCORE;
      GUI.skin.label.fontSize = 100;
      GUI.skin.label.alignment = TextAnchor.MiddleCenter;
      GUI.Label (new Rect (0, 0, Screen.width, Screen.height), str2);
    } else {
      GUI.skin.label.fontSize = 20;
      GUI.skin.label.alignment = TextAnchor.MiddleLeft;
      string str = "Score: " + SCORE;
      GUI.Label (new Rect (0, 0, 200, 20), str);
      if ((TIME_LIMIT - ((int)Time.time)) > 0) {
        GUI.Label (new Rect (400, 0, 200, 20), "Time: " + (TIME_LIMIT - ((int)Time.time)).ToString());
      } else {
        GUI.Label (new Rect (400, 0, 500, 20), "Time: WHO GIVE'S A RAT'S AS'S!!");


        if (!boss) {
          audio.clip = HURRY_MUSIC;
          audio.Play();
          boss = true;
          GameObject go = Instantiate(Resources.Load("ratking1")) as GameObject;
          go.transform.position = new Vector3(62.94728f, 8.423495f, 0);
        }
      }
    }
  }  
}
