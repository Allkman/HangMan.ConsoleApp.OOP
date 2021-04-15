using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.Server.InitialData
{
    public class FurnitureInitData
    {
        public static Furniture[] DataSeed => new Furniture[]
        {
            new Furniture { FurnitureId = 1, TopicId =4, Text = "Stalas"},
            new Furniture { FurnitureId = 2, TopicId =4, Text = "Kėdė"},
            new Furniture { FurnitureId = 3, TopicId =4, Text = "Spinta"},
            new Furniture { FurnitureId = 4, TopicId =4, Text = "Lova"},
            new Furniture { FurnitureId = 5, TopicId =4, Text = "Suolas"},
            new Furniture { FurnitureId = 6, TopicId =4, Text = "Sofa"},
            new Furniture { FurnitureId = 7, TopicId =4, Text = "Lempa"},
            new Furniture { FurnitureId = 8, TopicId =4, Text = "Durys"},
            new Furniture { FurnitureId = 9, TopicId =4, Text = "Kilimas"},
            new Furniture { FurnitureId = 10, TopicId =4, Text = "Veidrodis"},
        };
    }
}