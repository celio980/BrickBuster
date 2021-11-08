using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Paddle Paddle;
    public Ball Ball;
    public Readouts Readouts;
    public static Game Instance;
    private int ballsRemaining;
    private int score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        Reset();
    }
    public void LoseBall()
    {
        Paddle.gameObject.SetActive(false);
        Ball.gameObject.SetActive(false);
        UpdateNumberOfBalls(ballsRemaining - 1);
        CheckForGameOver();
    }

    private void CheckForGameOver()
    {
        if (ballsRemaining == 0)
            LoseGame();
        else
            ResetAfterBallLoss();
    }

    private void LoseGame()
    {

    }

    private void Reset()
    {
        UpdateNumberOfBalls(3);
        score = 0;
        Readouts.Reset(ballsRemaining);
    }


    private void ResetAfterBallLoss()
    {
        Paddle.Reset();
        Ball.Reset();
    }

    private void UpdateNumberOfBalls(int numberofBalls)
    {
        ballsRemaining = numberofBalls;
        Readouts.ShowBallsRemaining(ballsRemaining);
    }

    private void UpdateScore(int newScore)
    {
        score = newScore;
        Readouts.ShowScore(score);
    }
}
