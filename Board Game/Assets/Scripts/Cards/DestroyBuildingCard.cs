using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuildingCard : MonoBehaviour, ICard
{
    private GameManager gameManager;
    [SerializeField] private string description;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void Use()
    {
        gameManager.ChangeState(GameManagerState.PlayerChooseBuildingToDestroy);
    }

    public string GetDescription()
    {
        return description;
    }
}
