using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text equation_panel;
    public Text threshold_panel;
    public Text score_panel;
    public Text gameOver;
    private string Gameo;
    private string objectd;
    private string BASE_URL="https://docs.google.com/forms/d/e/1FAIpQLSe9yNVWR0ab2MrXVYWYKbxWDa_rYX-YvVdmvteH6DTe190ifw/formResponse";
    private int flag = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Collision.count == 3 || Timer.currentTime == 0)
        {
            gameOverPanel.SetActive(true);
            if(scoreCalc.score >= int.Parse(Collision.threshold))
            {
                gameOver.text = "Success! Level complete!";
                equation_panel.text = "Equation: " + Collision.math_eq;
            }
            else
            {
                  
                IEnumerator Post(string gameo, string objectd){
                    WWWForm form = new WWWForm();
                    form.AddField("entry.230878790",gameo);
                    form.AddField("entry.558777034",objectd);

                    byte[] rawd= form.data;
                    WWW www = new WWW(BASE_URL, rawd);
                    yield return www;

                }
                if(flag == 0) {
                    Gameo = "GameEnd~Timer-"+Time.time+"~equation-"+Equation.display+"~threshold-"+Collision.threshold+"~Order-"+Collision.count+"\n";
                    StartCoroutine(Post(Gameo,""));
                    flag = 1;
                }

                if (Timer.currentTime == 0)
                {
                    
                    gameOver.text = "Time's up! You Lost :(";
                    equation_panel.text = "Equation Incomplete";
                }
                else
                {
                    gameOver.text = "Game Over! You Lost :(";
                    equation_panel.text = "Equation: " + Collision.math_eq;
                }
            }
            
            threshold_panel.text = "Threshold: "+ Collision.threshold;
            score_panel.text = "Score: " + scoreCalc.score;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverPanel.SetActive(false);
        scoreCalc.score = 0;
    }
}
