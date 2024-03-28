using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SaveEngine : MonoBehaviour
{
    const string NAME_LEVEL_CURRENT = "Level Current";
    const string NAME_LEVEL_RECORD = "Level Record";
    const string NAME_FINISH_DISTANCE = "Finish Distance";
    const string NAME_SECTIONS_ARRAY = "Sections Array";
    const int MAX_SECTION = 18;

    public static int GetLevelCurrent()
    => PlayerPrefs.GetInt(NAME_LEVEL_CURRENT, 1);

    public static void SetLevelDesing(int level)
    {
        int temp = GetLevelCurrent();
        if (level == temp || temp < 6) return;

        float distance = 130 + ((level - 5) * 10);
        PlayerPrefs.SetFloat(NAME_FINISH_DISTANCE, distance);

        GameObject[] sections = GetNewSections(230);




    }

    static string path = "Sections/Section_";
    public static GameObject[] GetNewSections(float distance)
    {
        List<int> listSections = GetListNumbers(MAX_SECTION);
        List<GameObject> listSectionsObj = new List<GameObject>();

        while (distance < 0)
        {
            int tempCount = listSections.Count;
            if (tempCount == 0)
            {
                listSections = GetListNumbers(MAX_SECTION);
                continue;
            }

            int tempNumber = listSections[UnityEngine.Random.Range(0, listSections.Count)];
            listSections.Remove(tempNumber);
            GameObject tempObj = Load(path + tempNumber);
            distance -= tempObj.GetComponent<Section>().Distance;
            if (distance < 0) break;
            listSectionsObj.Add(tempObj);

        }

        return listSectionsObj.ToArray();
    }

    static List<int> GetListNumbers(int max)
    {
        List<int> temp = new List<int>();
        while (max > 0)
        {
            temp.Add(max);
            max--;
        }
        return temp;
    }

    public static void SaveSectionsArray(GameObject[] sections)
    {
        string temp = JsonUtility.ToJson(sections);
        PlayerPrefs.SetString(NAME_SECTIONS_ARRAY, temp);
    }
    public static GameObject[] LoadSectionsArray()
    =>JsonUtility.FromJson<GameObject[]>(PlayerPrefs.GetString(NAME_SECTIONS_ARRAY));

    static GameObject Load(string path) => Resources.Load<GameObject>(path);
}
