using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreReader : MonoBehaviour
{
    public TMP_Text globalScore;
    public RootsManager rootsManager;

    void Awake()
    {

    }

    void Update()
    {
        globalScore.text = rootsManager.score.ToString();
    }
}
