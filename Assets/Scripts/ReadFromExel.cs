using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ReadFromExel : MonoBehaviour
{
    [SerializeField] Text UiText;

    string filePath = "D:/downloadss/ReadFromExel/Data.csv";            // path to exel sheet
    string rawExelSheetData;                                           // raw data in a long string
    string[,] exelSheet = new string[100, 100];                          //init empty ExelSheet
    bool ErrorFree;                                                    // has the path been found no errors have occurred??

    private void Start()
    {
        Init();


        if (ErrorFree)
        {

            foreach (var item in GiveMeQuestion(GetLanguageData(1, 1))) // prints out a random hebrew qustion , answer first
            {
                print(item);
            }
            foreach (var item in GiveMeQuestion(GetLanguageData(1, 2))) // prints out a random eng qustion , answer first
            {
                print(item);
            }
            foreach (var item in GiveMeQuestion(GetLanguageData(1, 3))) // prints out a random arab qustion , answer first
            {
                print(item);
            }
        }
        else
        {
            print("error");
        }
    }

    private List<string> GiveMeQuestion(List<string> LanguageData) //returns a random list of qustions and the relevent answer
    {
        System.Random random = new System.Random();
        int chosen = random.Next(1, (int)LanguageData.Count / 5);
        print("random qustion number chosen is " + chosen);
        return new List<string> { LanguageData[(chosen - 1) * 5], LanguageData[(chosen - 1) * 5 + 1], LanguageData[(chosen - 1) * 5 + 2], LanguageData[(chosen - 1) * 5 + 3], LanguageData[(chosen - 1) * 5 + 4] };
    }

    private List<string> GetLanguageData(int Collum, int FromRow)
    {
        var temp = new List<string>();

        for (int i = Collum; i < 100; i++)
        {
            if (String.IsNullOrWhiteSpace(exelSheet[i, FromRow]))
            {
                return temp;
            }
            //print(exelSheet[i, FromRow]);
            temp.Add(exelSheet[i, FromRow]);

        }
        return temp;
    }

    private void Init()
    {
        if (DoesDataFileExists(filePath))
        {
            rawExelSheetData = System.IO.File.ReadAllText(filePath);
            string[] lines = rawExelSheetData.Split("\n"[0]);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] colums = lines[i].Split(',');

                for (int x = 0; x < colums.Length; x++)
                {
                    exelSheet[i, x] = colums[x];
                }
            }
        }

    }

    private bool DoesDataFileExists(string FilePath)
    {
        if (System.IO.File.Exists(FilePath))
        {
            try
            {
                rawExelSheetData = System.IO.File.ReadAllText(FilePath);
            }
            catch (Exception)
            {
                UiText.text = $"Please Close File!! at {FilePath}";
                print($"Please Close File!! at {FilePath}");
                ErrorFree = false;
                return false;
            }
        }
        else
        {
            UiText.text = $"File Not Found! at {FilePath}";
            print($"File Not Found! at {FilePath}");
            ErrorFree = false;
            return false;
        }
        ErrorFree = true;
        return true;
    }


}
