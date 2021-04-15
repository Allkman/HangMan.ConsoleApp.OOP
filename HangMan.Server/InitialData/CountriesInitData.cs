using HangMan.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.Server.InitialData
{
    public class CountriesInitData
    {
        public static Country[] DataSeed => new Country[]
        {
            new Country { CountryId = 1, TopicId =3, Text = "Kinija"},
            new Country { CountryId = 2, TopicId =3, Text = "Prancūzija"},
            new Country { CountryId = 3, TopicId =3, Text = "Estija"},
            new Country { CountryId = 4, TopicId =3, Text = "Norvegija"},
            new Country { CountryId = 5, TopicId =3, Text = "Taivanas"},
            new Country { CountryId = 6, TopicId =3, Text = "Indija"},
            new Country { CountryId = 7, TopicId =3, Text = "Meksika"},
            new Country { CountryId = 8, TopicId =3, Text = "Suomija"},
            new Country { CountryId = 9, TopicId =3, Text = "Argentina"},
            new Country { CountryId = 10, TopicId =3, Text = "Portugalija"},
        };
    }
}
