using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ReadFromExel : MonoBehaviour
{
    [SerializeField] Text UiText;

    string filePath = "D:/downloadss/ReadFromExel/Data.csv";
    string rawExelSheetData;
    string[,] exelSheet = new string[50,50];

    private void Start()
    {
        DoesDataFileExists(filePath);
        InitMaster();

        print(exelSheet[0, 0]);
        print(exelSheet[1, 0]);
        print(exelSheet[2, 0]);
    }

    private void InitMaster()
    {
        if (ErrorFree())
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

    private bool ErrorFree()
    {
        if (System.IO.File.ReadAllText(filePath) != null)
        {
           
            return true;
        }
        else
        {
            UiText.text = "file not found";
            return false;
        }
        
    } // checks if filepath != null

    private void DoesDataFileExists(string FilePath)
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

            }
        }
        else
        {
            UiText.text = $"File Not Found! at {FilePath}";
        }
    }




}
