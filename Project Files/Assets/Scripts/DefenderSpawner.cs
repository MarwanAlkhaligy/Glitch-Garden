using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    const string DEFENDER_PARENT_NAME = "Defenders";
    [SerializeField] GameObject defenderParent;

    private void Start() {
        CreateDefenderParent();
    }
    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent) 
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }
    private void OnMouseDown() {
        if (!defender) return;
        AttendToPlace(GetSquareClicked());
    }
    

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Mathf.Round(Input.mousePosition.x), Mathf.Round(Input.mousePosition.y));
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid( worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawworld)
    {
        float newX = Mathf.RoundToInt(rawworld.x);
        float newY = Mathf.RoundToInt(rawworld.y);

        return new Vector2(newX, newY);

    }
    private void AttendToPlace(Vector2 grid)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        var defen = defender.GetStarCost();

        if(StarDisplay.HaveEnoughStars(defen))
        {
            SpawnDefender(grid);
            StarDisplay.SpendStars(defen);
        }
    }

    public void SetDefender(Defender defenderSpawn)
    {
        defender = defenderSpawn;
    }  
    
    private void SpawnDefender(Vector2 v)
    {
        Defender defenderObject = Instantiate(defender,v, Quaternion.identity ) as Defender;
        defenderObject.transform.parent = defenderParent.transform;
    }
}
