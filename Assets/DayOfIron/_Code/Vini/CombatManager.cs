using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private Fighter[] fighters;
    private int fighterIndex;

    private void Start()
    {
        LogPanel.Write("Battle initiated.");

        this.fighterIndex = 0;
    }
    
    
}