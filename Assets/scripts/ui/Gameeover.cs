using UnityEngine;
using UnityEngine.SceneManagement ;
public class Gameeover : MonoBehaviour
{
      public GameObject gameover;
    // Start is called once befo re the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameover == null){
          //  gameover = GetObjectWithTag("endscreen");
        }
        gameover.SetActive(!gameover.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
          
    }
    
 public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
