using Models;
using System;

namespace data_seeder
{
    public class CarFactory
    {
        private string GenerateLicensePlate()
        {
            Random random = new();
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";

            string plate = "";

            for (int i = 0; i < 3; i++)
                plate += letters[random.Next(letters.Length)];

            for (int i = 0; i < 4; i++)
                plate += numbers[random.Next(numbers.Length)];

            return plate;
        }

        private string GenerateName()
        {
            return new List<string>
                {
                    "SambaSprint",
                    "AmazoniaAdventurer",
                    "CarnavalCruiser",
                    "BossaNovaBolt",
                    "CopacabanaCruiser",
                    "RioRacer",
                    "IpanemaInterceptor",
                    "CapoeiraCruiser",
                    "SertãoSpeedster",
                    "PantanalPioneer",
                    "CariocaChallenger",
                    "BahiaBlast",
                    "PampasPacer",
                    "ParatyProwler",
                    "PantanalProwess",
                    "RecifeRapid",
                    "FortalezaFlyer",
                    "BrasíliaBolt",
                    "MaracanãMach",
                    "SerraSprinter",
                    "CachoeiraCruiser",
                    "TropicanaThunder",
                    "CaipirinhaCruiser",
                    "GuaranaGlide",
                    "IlhaBelEagle",
                    "AracajuAce",
                    "ManausMaverick",
                    "AçaiAdventurer",
                    "CarnaúbaCruiser",
                    "PãoDeAçúcarPilot"
                }.OrderBy(_ => Guid.NewGuid()).First();
        }

        private string GenerateModelYear()
        {
            return new Random().Next(1980, DateTime.Now.Year).ToString();
        }

        private string GenerateManufactureYear()
        {
            return new Random().Next(1980, DateTime.Now.Year).ToString();
        }

        private string GenerateColor()
        {
            return new List<string>
                {
                    "Vermelho",
                    "Azul",
                    "Verde",
                    "Amarelo",
                    "Laranja",
                    "Roxo",
                    "Marrom",
                    "Preto",
                    "Branco",
                    "Cinza",
                    "Rosa",
                    "Violeta",
                    "Turquesa",
                    "Bege",
                    "Dourado",
                    "Prata",
                    "Magenta",
                    "Ciano",
                    "Coral",
                    "Lavanda",
                    "Salmão",
                    "Caqui",
                    "Azeitona",
                    "Marfim",
                    "Mostarda",
                    "Bordô",
                    "Pêssego",
                    "Champanhe",
                    "Fúcsia",
                    "Jade"
                }.OrderBy(_ => Guid.NewGuid()).First();
        }

        public Car Make() => new Car()
        {
            LicensePlate = GenerateLicensePlate(),
            Name = GenerateName(),
            ModelYear = GenerateModelYear(),
            ManufactureYear = GenerateManufactureYear(),
            Color = GenerateColor()
        };
    }
}
