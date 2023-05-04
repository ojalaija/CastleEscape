using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsAndGoal : MonoBehaviour
{
    [SerializeField] private GameObject goalDoor;
    [SerializeField] private GameObject keyPlatform;
    [SerializeField] private ShowGuidance showGuidance;
    [SerializeField] private GameObject platform;

    private bool platformPuzzle;
    public void LoadData(GameData data)
    {
        platformPuzzle = data.platformPuzzle;
    }

    public void SaveData(GameData data)
    {
        data.platformPuzzle = platformPuzzle;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (platformPuzzle)
        {
            goalDoor.tag = "goal";
            keyPlatform.SetActive(true);
        }
        if (platformPuzzle == false)
        {
            Invoke("ShowFirstHint", 360f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (keyPlatform.gameObject.activeSelf && goalDoor.tag != "goal")
        {
            platformPuzzle = true;
            goalDoor.tag = "goal";
            Invoke("ShowSecondHint", 360f);
        }

    }

    private void ShowFirstHint()
    {
        if (platform.activeSelf == false)
        {
            showGuidance.SetUpGuidance("Some of the switches toggle one platform, some toggle two.");
            Invoke("CloseGuidance", 7);
        }
    }

    private void ShowSecondHint()
    {
        showGuidance.SetUpGuidance("Remember to find the key, if you didn't already!");
        Invoke("CloseGuidance", 7);
    }

    private void CloseGuidance()
    {
        showGuidance.CloseGuidance();
    }
}
