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

        /* 
         IntializeData();
         OrganizeData();
         foreach (var item in heb)
         {
           //  print(item);
         }*/

        BigString = System.IO.File.ReadAllText(filePath);
        lines = BigString.Split("\n"[0]);

        for (int i = 0; i < lines.Length; i++)
        {
            colums =   lines[i].Split(',');

            for (int x = 0; x < colums.Length; x++)
            {
                
                Master[i,x] = colums[x];

            }
        }

        print(Master[0,0]);
        print(Master[1, 0]);
        print(Master[2, 0]);
    }

    /* private void OrganizeData()
     {
         if (exelData != null)
         {

             foreach (var word in exelData[1,])
             {
                 heb.Add(word);
             }
         }
         else
         {
             print("exel data is null");
         }
     }*/

    /* private void IntializeData()
      {
          lines = filePath.Split("\n"[0]);

          exelData = new string[50][];
          int i = 0, j = 0;

          foreach (var item in lines)
          {
              string[] col = item.Split(',');
              foreach (var word in col)
              {
                  exelData[j][i] = word;
                  j++;
              }
              i++;
          }
          print("word added");
      }*/

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
