using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private int x;
    [SerializeField] private int y;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
    }

    private void OnMouseDown()
    {
        inputManager.FieldPressed(x, y);
    }
}
