using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject[] lifeSquares;
    public ShooterController shooterController;
    public Material red;
    private int health;
    private int score;

    void Start()
    {
        health = 0; // really damage taken
        score = 0;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), "Score: "+score.ToString());
    }

    public int getScore()
    {
        return score;
    }

    public int getCurrentHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return lifeSquares.Length;
    }

    public void changeColor()
    {
        lifeSquares[health].GetComponent<Renderer>().material = red;
        health += 1;
        if (health == lifeSquares.Length)
            shooterController.StopShooting();
    }

    public void incrementScore()
    {
        score++;
        shooterController.incrementScore();
    }
}
