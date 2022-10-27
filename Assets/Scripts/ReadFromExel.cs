using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ReadFromExel : MonoBehaviour
{
    [SerializeField] Text UiText;
    [SerializeField] int collum;
    [SerializeField] int Line;

    string filePath = "D:/downloadss/ReadFromExel/Data.csv";
    string BigString;
    string[] lines = new string[50];
    string[] colums = new string[50];
    string[,] Master = new string[50,50];
    string[,] exelData;
    List<string> heb;
    List<string> eng = new List<string>();
    List<string> arab = new List<string>();


    private void Start()
    {
        DoesDataFileExists(filePath);
        InitMaster();

        print(Master[0, 0]);
        print(Master[1, 0]);
        print(Master[2, 0]);
    }

    private void InitMaster()
    {
        BigString = System.IO.File.ReadAllText(filePath);
        lines = BigString.Split("\n"[0]);

        for (int i = 0; i < lines.Length; i++)
        {
            colums = lines[i].Split(',');

            for (int x = 0; x < colums.Length; x++)
            {

                Master[i, x] = colums[x];

            }
        }
    }

    private void DoesDataFileExists(string FilePath)
    {
        if (System.IO.File.Exists(FilePath))
        {

            try
            {
                BigString = System.IO.File.ReadAllText(FilePath);
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
