﻿using System;
public class DuplicateFinder
{
    static List<string> cards = new List<string>();
    static List<string> duplicards = new List<string>();
    static List<string> filteredcards = new List<string>();
    static List<string> cvvlist = new List<string>();
    static string InputCardsFP = "C:\\Duplicator\\InputCards.txt";
    static string DuplicateCardsFP = "C:\\Duplicator\\DuplicateCards.txt";
    static string UniqueCardsFP = "C:\\Duplicator\\UniqueCardsFP.txt";
    public static void Main()
    {
        bool isCreated = false;
        bool isFirstTime = false;

        DuplicateFinder finder = new DuplicateFinder();
        Console.WriteLine("Tignan muna natin kung may files na hehe");
        if (!File.Exists(InputCardsFP) && !File.Exists(DuplicateCardsFP) && !File.Exists(UniqueCardsFP))
        {
            Console.WriteLine("Wala pang file..gawa muna tayo");
            for (int i = 0; i <= 100; i++)
            {
                Console.Write($"{i} %" + "\r");
                Thread.Sleep(50);
            }
            FileCreate();
            isCreated = true;
            isFirstTime = true;
        }
        else
        {
            Console.WriteLine("Ok na meron na");
            isCreated = true;
        }

         if (isCreated && !isFirstTime)
        {
            string cardnum = string.Empty;
            string duplicard = string.Empty;

            using (StreamReader sr = new StreamReader(DuplicateCardsFP))
            {
                while ((duplicard = sr.ReadLine()) != null)
                {
                    duplicards.Add(duplicard);

                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(InputCardsFP))
            {
                int duplicatedCards = 0;
                Console.WriteLine("-----Input Cards-----");
                while ((cardnum = sr.ReadLine()) != null)
                {
                    if (!duplicards.Contains(cardnum.Split('|')[0] +"|"+ cardnum.Split('|')[1] + "|"+cardnum.Split('|')[2]))
                    {
                        Console.WriteLine(cardnum);
                        cvvlist.Add(cardnum.Split('|')[3]);
                        cards.Add(cardnum.Split('|')[0] + "|" + cardnum.Split('|')[1] + "|" + cardnum.Split('|')[2]);
                        
                    }
                    else
                    {
                        Console.WriteLine($"{cardnum} - Duplicated");
                        duplicatedCards++;
                    }

                }
                Console.WriteLine($"----------\nNumber of duplicated cards {duplicatedCards}");
                Console.WriteLine("----------\n DupliCheck © TEK Softwares 2022");
                Console.WriteLine("----------\nWait ilagay lang sa notepad saglit");
                sr.Close();
            }
            var uniqueInitial = cards.Distinct().ToList();
            using (StreamWriter sw = new StreamWriter(DuplicateCardsFP, true))
            {
                foreach (string uniques in uniqueInitial)
                {
                    if (!duplicards.Contains(uniques))
                    {
                        sw.WriteLine(uniques);
                        filteredcards.Add(uniques);
                    }
                }
                sw.Close();
            }
            using (StreamWriter sw = new StreamWriter(UniqueCardsFP, true))
            {

                for(int i=0; i<filteredcards.Count; i++)
                {
                    sw.WriteLine(filteredcards[i] + "|" + cvvlist[i]);
                }
                sw.Close();
            }
            Console.WriteLine("----------\nOks na");
            Console.WriteLine("Enter to exit");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Restart muna kakagawa lang ng file");
        }
        
    }

    public static void FileCreate()
    {
        string InputCardsFP = "C:\\Duplicator\\InputCards.txt";
        string DuplicateCardsFP = "C:\\Duplicator\\DuplicateCards.txt";
        string UniqueCardsFP = "C:\\Duplicator\\UniqueCardsFP.txt";
        File.Create(InputCardsFP);
        File.Create(DuplicateCardsFP);
        File.Create(UniqueCardsFP);
    }
}