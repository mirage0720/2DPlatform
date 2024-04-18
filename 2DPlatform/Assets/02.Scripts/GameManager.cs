using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public PlayerMove player;
    public GameObject[] Stages;

    public Image[] UIhealth;
    public Text UIPoint;
    public Text UIStage;
    public GameObject UIRestartBtn;

    void Update(){
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }



    // Start is called before the first frame update
    public void NextStage()
    {
        //Change Stage
        if(stageIndex < Stages.Length-1){
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
            totalPoint += stagePoint;
            stagePoint = 0;
            PlayerReposition();

            UIStage.text = "STAGE" + (stageIndex +1);
        }
        else{ //Game Clear
            //Player Control Lock
            Time.timeScale = 0;
            //Restart Button UI
            
            Text btnText = UIRestartBtn.GetComponentInChildren<Text>();
            btnText.text = "Clear!";
            ViewBtn();

        }
        
    }

    public void HealthDwon()
    {
        if(health > 1){
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.2f);
        }
        else{
            //All Health UI Off
            UIhealth[0].color = new Color(1, 0, 0, 0.2f);

            //player Die Effect
            player.OnDie();
            
            //Retry Button UI
            Invoke("ViewBtn",3);

        }
    }

    void ViewBtn()
    {
        UIRestartBtn.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            
            //Player Reposition
            if(health > 1){
                PlayerReposition();
            }

            //Health Down
            HealthDwon();

        }
            
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(0, 0, -1);
        player.VelocityZero();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
