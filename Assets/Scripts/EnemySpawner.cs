using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // private List<string> enemy;
    private void Start()
    {
        SetActiveEnemy(0);
    }

    public void SetActiveEnemy(int index)
    {
        int tempNum = 0;

        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }

        foreach (Transform child in gameObject.transform)
        {
            if (tempNum == index)
            {
                child.gameObject.SetActive(true);
            }
            tempNum++;
        }
    }
    /*
    public List<string> PopulateListFromParent(int index)
    {
        List<string> options = new List<string>();
        int tempNum = 0;

        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }

        foreach (Transform child in gameObject.transform)
        {
            if (tempNum == index)
            {
                child.gameObject.SetActive(true);
            }
            options.Add(child.name);
            tempNum++;
        }

        return options;
    }

    public void PopulateStatsFromParent(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.gameObject.activeSelf)
            {
                if (parent != gameObject) { continue; }
                // move GetStatsList(child) to class
                child.GetComponent<StatManager>().shouldUseModifiers = true;
                //GetStatsList(child);
            }
        }
    }
    */
}
