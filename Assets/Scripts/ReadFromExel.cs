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
    bool ErrorFree;                                                    // has the path been found and has no errors?
    private void Start()
    {
        Init();


        if (ErrorFree)
        {
            GetLanguageData(2,1);
           
        }
        else
        {
            print("error");
        }
    }

    private List<string> GetLanguageData(int Collum,int FromRow)
    {
      var temp = new List<string>();

        for (int i = Collum; i < 100; i++)
        {
            if (  String.IsNullOrWhiteSpace(exelSheet[i, FromRow]))
            {
                print("inside if");
                return temp;
            }
            print(exelSheet[i, FromRow]);
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
