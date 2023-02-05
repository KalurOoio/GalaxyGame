using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamGroup : BaseGroup
{
    public RamShip ship1;
    public RamShip ship2;

    private List<RamShip> ships = new List<RamShip>();

    void Start()
    {
        ships.Add(ship1);
        ships.Add(ship1);
    }

    void Update()
    {
        ships.RemoveAll(item => item == null);
        if(ships.Count == 0)
        {
            isAlive = false;
            return;
        }
    }
}
