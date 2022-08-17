using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject[] buildingsPlayer1;
    [SerializeField] private GameObject[] buildingsPlayer2;

    private Board board;

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.FindObjectOfType<Board>();

        if (board.CheckIfFieldIsFree(1, 2))
        {
            board.PlaceBuilding(buildingsPlayer1[0], 1, 2);
        }

        
        //board.DestroyBuilding(1, 2);
        //board.PlaceBuilding(buildingsPlayer2[1], 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
