using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingSO")]
public class SettingSO : ScriptableObject
{
    public int Score = 0;

    public void UpdateScore(TextMeshProUGUI textMeshProUGUI)
    {
        textMeshProUGUI.text = "SCORE :" + Score;
    }
    
   
}
