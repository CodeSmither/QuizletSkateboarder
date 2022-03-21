using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace DictonaryConverter
{
    public class DictonaryStorage
    {
        StreamReader DictonaryReader;
        string DictonaryFile;
        public string[,] ValuesArray = new string[2, 30];

        public DictonaryStorage(string DictonaryFile)
        {
            this.DictonaryFile = DictonaryFile;
        }

        void LoadFile()
        {
            DictonaryReader = new StreamReader(DictonaryFile);
        }
        public void OrginizeDictionary()
        {
            LoadFile();
            List<string> Words;
            List<string> Questions;
            Words = new List<string>();
            Questions = new List<string>();
            using (DictonaryReader)
            {
                int x = 0;
                while (!DictonaryReader.EndOfStream)
                {
                    var line = DictonaryReader.ReadLine().Split(',');
                    if (x < 31)
                    {
                        Words.Add(line[0]);
                        Questions.Add(line[1]);
                    }
                    x++;
                }
                string[] WordsArray = Words.ToArray();
                string[] QuestionsArray = Questions.ToArray();
                ConversionArray2D(WordsArray, QuestionsArray);

            }
        }

        public void ConversionArray2D(string[] Words, string[] Questions)
        {
            int x = 0;
            int y = 0;
            //Debug.Log(string.Join(",", Words));
            //Debug.Log(string.Join(",", Questions));
            //Debug.Log(Words.Length);
            //Debug.Log(Questions.Length);
            foreach (string word in Words)
            {
                if (x < Words.Length - 1)
                {
                    ValuesArray[0, x] = word;
                    x++;
                }

            }
            foreach (string question in Questions)
            {
                if (y < Questions.Length - 1)
                {
                    ValuesArray[1, y] = question;
                    y++;
                }
            }



        }
    
    }
    public static class WordOrginization
    {
        public static char[] ScrambleWord(string WordUnorgonized)
        {
            char[] WordUnorgonizedList = WordUnorgonized.ToCharArray();
            for( int x = 0; x < WordUnorgonized.Length; x++)
            {
                int r = Random.Range(x, WordUnorgonized.Length);
                char tmp = WordUnorgonizedList[x];
                WordUnorgonizedList[x] = WordUnorgonizedList[r];
                WordUnorgonizedList[r] = tmp;

                
            }
            string ReorgonizedList = string.Join("", WordUnorgonizedList);
            char[] charReorgonizedList = ReorgonizedList.ToCharArray();
            return charReorgonizedList;
        }
    }

}



