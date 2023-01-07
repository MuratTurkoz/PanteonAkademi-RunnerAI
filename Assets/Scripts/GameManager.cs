using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int buildSceneIndex;
    public static GameManager instance;
    InGameRanking ig;
    GameObject[] runners;
    List<RankingSystem> rankingSystems = new List<RankingSystem>();
    [SerializeField] public bool isGameOver = false;
    private void Awake()
    {
        instance = this;
        runners = GameObject.FindGameObjectsWithTag("Runner");
        ig = FindObjectOfType<InGameRanking>();


    }
    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < runners.Length; i++)
        {
            rankingSystems.Add(runners[i].GetComponent<RankingSystem>());
        }
    }
    void CalculateRank()
    {
        rankingSystems = rankingSystems.OrderBy(x => x.distance).ToList();
        for (int i = 0; i < runners.Length; i++)
        {
            rankingSystems[i].rank = i + 1;

        }

        ig.a = rankingSystems[0].name;
        ig.b = rankingSystems[1].name;
        ig.c = rankingSystems[2].name;
        ig.d = rankingSystems[3].name;
        ig.e = rankingSystems[4].name;
        ig.f = rankingSystems[5].name;



    }
    private void Update()
    {
        CalculateRank();
    }
    void GameSceneBuildIndex()
    {
        buildSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void ReLoad()
    {
        GameSceneBuildIndex();
        SceneManager.LoadScene(buildSceneIndex);
    }
    public void NextLevel()
    {
        buildSceneIndex++;
        SceneManager.LoadScene(buildSceneIndex);
    }
}
