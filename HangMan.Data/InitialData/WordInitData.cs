using HangMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.Data.InitialData
{
    public class WordsInitData
    {
        public static Word[] DataSeed => new Word[]
        {
            new Word { WordId = 1, TopicId =1, Text = "Gediminas"},
            new Word { WordId = 2, TopicId =1, Text = "Mindaugas"},
            new Word { WordId = 3, TopicId =1, Text = "Vytautas"},
            new Word { WordId = 4, TopicId =1, Text = "Kęstutis"},
            new Word { WordId = 5, TopicId =1, Text = "Algirdas"},
            new Word { WordId = 6, TopicId =1, Text = "Žygimantas"},
            new Word { WordId = 7, TopicId =1, Text = "Birutė"},
            new Word { WordId = 8, TopicId =1, Text = "Barbora"},
            new Word { WordId = 9, TopicId =1, Text = "Augustas"},
            new Word { WordId = 10, TopicId =1, Text = "Morta"},
            new Word { WordId = 11, TopicId =2, Text = "Klaipėda"},
            new Word { WordId = 12, TopicId =2,Text = "Kaunas"},
            new Word { WordId = 13, TopicId =2, Text = "Vilnius"},
            new Word { WordId = 14, TopicId =2, Text = "Ukmergė"},
            new Word { WordId = 15, TopicId =2, Text = "Tauragė"},
            new Word { WordId = 16, TopicId =2, Text = "Palanga"},
            new Word { WordId = 17, TopicId =2, Text = "Utena"},
            new Word { WordId = 18, TopicId =2, Text = "Raseiniai"},
            new Word { WordId = 19, TopicId =2, Text = "Varėna"},
            new Word { WordId = 20, TopicId =2, Text = "Alytus"},
            new Word { WordId = 21, TopicId =3, Text = "Kinija"},
                        new Word { WordId = 22, TopicId =3, Text = "Prancūzija"},
                        new Word { WordId = 23, TopicId =3,Text = "Estija"},
                        new Word { WordId = 24, TopicId =3, Text = "Norvegija"},
                        new Word { WordId = 25, TopicId =3, Text = "Taivanas"},
                        new Word { WordId = 26, TopicId =3, Text = "Indija"},
                        new Word { WordId = 27, TopicId =3, Text = "Meksika"},
                        new Word { WordId = 28, TopicId =3, Text = "Suomija"},
                        new Word { WordId = 29, TopicId =3, Text = "Argentina"},
                        new Word { WordId = 30, TopicId =3, Text = "Portugalija"},
            new Word { WordId = 31, TopicId =4, Text = "Stalas"},
                        new Word { WordId = 32, TopicId =4,Text = "Kėdė"},
                        new Word {WordId = 33, TopicId =4, Text = "Spinta"},
                        new Word {WordId = 34, TopicId =4, Text = "Lova"},
                        new Word { WordId = 35, TopicId =4,Text = "Suolas"},
                        new Word {WordId = 36, TopicId =4, Text = "Sofa"},
                        new Word { WordId = 37, TopicId =4,Text = "Lempa"},
                        new Word { WordId = 38, TopicId =4,Text = "Durys"},
                        new Word { WordId = 39, TopicId =4,Text = "Kilimas"},
                        new Word { WordId = 40, TopicId =4,Text = "Veidrodis"},
        };
    }
}
