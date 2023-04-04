using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private void Start()
    {
        Clear();
        SetActiveEnemy(0);
    }

    private void Clear()
    {
        foreach (Transform child in gameObject.transform)
        {
            //if (child.gameObject.activeSelf)
            child.gameObject.SetActive(false);
        }
    }
    public void SetActiveEnemy(int index)
    {
        int tempNum = 0;

        foreach (Transform child in gameObject.transform)
        {
            if (tempNum == index)
            {
                if (child.gameObject.TryGetComponent<Target>(out Target Target))
                {

                }
                else
                {
                    child.gameObject.AddComponent<Target>();
                }
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
            tempNum++;
        }
    }

    public int GetIndex()// CurrentActiveEnemy candidate
    {
        int tempNum = 0;
        int count = gameObject.transform.childCount;
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.activeSelf)
            {
                return tempNum;
            }
            tempNum++;
        }
        return 0;
    }

    public int GetNextIndex()// CurrentActiveEnemy candidate
    {
        int tempNum = 0;
        int count = gameObject.transform.childCount;
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.activeSelf)
            {
                if (tempNum + 1 < count)
                {
                    return tempNum + 1;
                }
                else if (tempNum + 1 == count)
                {
                    // Temporarily Handle the final victory case go to start!
                    return 0;
                }
            }
            tempNum++;
        }
        return 0; // Handle the a return
    }
}