using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private bool isObstacle;
    private int player;
    private int level;

    [SerializeField] private GameObject obstacleModel;
    [SerializeField] private GameObject[] buildingsPlayer1Models;
    [SerializeField] private GameObject[] buildingsPlayer2Models;

    private GameObject currentModel;

    public void Make(bool isObstacle, int player, int level)
    {
        this.isObstacle = isObstacle;
        this.player = player;
        this.level = level;

        if (isObstacle)
        {
            currentModel = Instantiate(obstacleModel, transform);
        }
        else
        {
            if(player == 1)
            {
                currentModel = Instantiate(buildingsPlayer1Models[level], transform);
            }
            else if(player == 2)
            {
                currentModel = Instantiate(buildingsPlayer2Models[level], transform);
            }
        }
    }

    public int GetLevel()
    {
        return level;
    }

    public void ChangeLevel(int level)
    {
        Destroy(currentModel);
        this.level = level;
        if (player == 1)
        {
            currentModel = Instantiate(buildingsPlayer1Models[level], transform);
        }
        else if (player == 2)
        {
            currentModel = Instantiate(buildingsPlayer2Models[level], transform);
        }
    }

    public void LevelUp()
    {
        ChangeLevel(level + 1);
    }

    public int GetPlayer()
    {
        return player;
    }

    public bool IsObstacle()
    {
        return isObstacle;
    }
}
