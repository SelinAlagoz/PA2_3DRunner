using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private InGameRanking ig;

    private List<RankingSystem> sortArray = new List<RankingSystem>();

    public static bool GameStarted;
    private bool canMove; // Yeni eklendi
    public PlayerMotor playerMotor;

    private void Awake()
    {
        instance = this;
        ig = FindObjectOfType<InGameRanking>();
    }

    void Start()
    {
        GameStarted = false;
        canMove = GameStarted;

        GameObject[] runnerParents = GameObject.FindGameObjectsWithTag("Runner");

        foreach (GameObject runnerParent in runnerParents)
        {
            RankingSystem rankingSystem = runnerParent.GetComponentInChildren<RankingSystem>();
            if (rankingSystem != null)
            {
                sortArray.Add(rankingSystem);
            }
        }
        playerMotor.SetCanMove(false);
    }

    void Update()
    {
        CalculateRanking();

        if (GameStarted)
        {
            canMove = true;
        }
    }

    void CalculateRanking()
    {
        sortArray = sortArray.OrderBy(x => x.distance).ToList();

        for (int i = 0; i < sortArray.Count; i++)
        {
            sortArray[i].rank = i + 1;
        }

        if (sortArray.Count > 2)
        {
            ig.a = sortArray[2].name;
            ig.b = sortArray[1].name;
            ig.c = sortArray[0].name;
        }
    }
    public void StartGame()
    {
        // Oyun başladığında karakterin hareket etmesini sağlayalım
        playerMotor.SetCanMove(true);
    }
}
