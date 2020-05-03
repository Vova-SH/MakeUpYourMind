using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Settings : MonoBehaviour
{
    public Dropdown qulityGame;

    void Start()
    {
        qulityGame.ClearOptions();
        qulityGame.AddOptions(QualitySettings.names.ToList());
        qulityGame.value = QualitySettings.GetQualityLevel();
    }

    void Update()
    {
        
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(qulityGame.value);
    }
}
