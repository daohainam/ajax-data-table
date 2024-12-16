namespace ajax_data_table_demo.Models
{
    public class World
    {
        public static readonly City[] Cities = [
            new City { ID = 1, Name = "Kabul", CountryCode = "AFG", District = "Kabol", Population = 1780000 },
            new City { ID = 2, Name = "Qandahar", CountryCode = "AFG", District = "Qandahar", Population = 237500 },
            new City { ID = 3, Name = "Herat", CountryCode = "AFG", District = "Herat", Population = 186800 },
            new City { ID = 4, Name = "Mazar-e-Sharif", CountryCode = "AFG", District = "Balkh", Population = 127800 },
            new City { ID = 5, Name = "Amsterdam", CountryCode = "NLD", District = "Noord-Holland", Population = 731200 },
            new City { ID = 6, Name = "Rotterdam", CountryCode = "NLD", District = "Zuid-Holland", Population = 593321 },
            new City { ID = 7, Name = "Haag", CountryCode = "NLD", District = "Zuid-Holland", Population = 440900 },
            new City { ID = 8, Name = "Utrecht", CountryCode = "NLD", District = "Utrecht", Population = 234323 },
            new City { ID = 9, Name = "Eindhoven", CountryCode = "NLD", District = "Noord-Brabant", Population = 201843 },
            new City { ID = 10, Name = "Tilburg", CountryCode = "NLD", District = "Noord-Brabant", Population = 193238 },
            new City { ID = 11, Name = "Groningen", CountryCode = "NLD", District = "Groningen", Population = 172701 },
            new City { ID = 12, Name = "Breda", CountryCode = "NLD", District = "Noord-Brabant", Population = 160398 },
            new City { ID = 13, Name = "Apeldoorn", CountryCode = "NLD", District = "Gelderland", Population = 153491 },
            new City { ID = 14, Name = "Nijmegen", CountryCode = "NLD", District = "Gelderland", Population = 152463 },
            new City { ID = 15, Name = "Enschede", CountryCode = "NLD", District = "Overijssel", Population = 149544 },
            new City { ID = 16, Name = "Haarlem", CountryCode = "NLD", District = "Noord-Holland", Population = 148772 },
            new City { ID = 17, Name = "Almere", CountryCode = "NLD", District = "Flevoland", Population = 142465 },
            new City { ID = 18, Name = "Arnhem", CountryCode = "NLD", District = "Gelderland", Population = 138020 },
            new City { ID = 19, Name = "Zaanstad", CountryCode = "NLD", District = "Noord-Holland", Population = 135621 },
            new City { ID = 20, Name = "´s-Hertogenbosch", CountryCode = "NLD", District = "Noord-Brabant", Population = 129170 },
            new City { ID = 21, Name = "Amersfoort", CountryCode = "NLD", District = "Utrecht", Population = 126270 },
            new City { ID = 22, Name = "Maastricht", CountryCode = "NLD", District = "Limburg", Population = 122087 },
            new City { ID = 23, Name = "Dordrecht", CountryCode = "NLD", District = "Zuid-Holland", Population = 119811 },
            new City { ID = 24, Name = "Leiden", CountryCode = "NLD", District = "Zuid-Holland", Population = 117196 },
            new City { ID = 25, Name = "Haarlemmermeer", CountryCode = "NLD", District = "Noord-Holland", Population = 110722 },
            new City { ID = 26, Name = "Zoetermeer", CountryCode = "NLD", District = "Zuid-Holland", Population = 110214 },
            new City { ID = 27, Name = "Emmen", CountryCode = "NLD", District = "Drenthe", Population = 105853 },
            new City { ID = 28, Name = "Zwolle", CountryCode = "NLD", District = "Overijssel", Population = 105819 },
            new City { ID = 29, Name = "Ede", CountryCode = "NLD", District = "Gelderland", Population = 101574 },
            new City { ID = 30, Name = "Delft", CountryCode = "NLD", District = "Zuid-Holland", Population = 95268 },
            new City { ID = 31, Name = "Heerlen", CountryCode = "NLD", District = "Limburg", Population = 95052 },
            new City { ID = 32, Name = "Alkmaar", CountryCode = "NLD", District = "Noord-Holland", Population = 92713 },
            new City { ID = 33, Name = "Willemstad", CountryCode = "ANT", District = "Curaçao", Population = 2345 },
            new City { ID = 34, Name = "Tirana", CountryCode = "ALB", District = "Tirana", Population = 270000 },
            new City { ID = 35, Name = "Alger", CountryCode = "DZA", District = "Alger", Population = 2168000 },
            new City { ID = 36, Name = "Oran", CountryCode = "DZA", District = "Oran", Population = 609823 },
            new City { ID = 37, Name = "Constantine", CountryCode = "DZA", District = "Constantine", Population = 443727 },
            new City { ID = 38, Name = "Annaba", CountryCode = "DZA", District = "Annaba", Population = 222518 },
            new City { ID = 39, Name = "Batna", CountryCode = "DZA", District = "Batna", Population = 183377 },
            new City { ID = 40, Name = "Sétif", CountryCode = "DZA", District = "Sétif", Population = 179055 },
            new City { ID = 41, Name = "Sidi Bel Abbès", CountryCode = "DZA", District = "Sidi Bel Abbès", Population = 153106 },
            new City { ID = 42, Name = "Skikda", CountryCode = "DZA", District = "Skikda", Population = 128747 },
            new City { ID = 43, Name = "Biskra", CountryCode = "DZA", District = "Biskra", Population = 128281 },
            new City { ID = 44, Name = "Blida (el-Boulaida)", CountryCode = "DZA", District = "Blida", Population = 127284 },
            new City { ID = 45, Name = "Béjaïa", CountryCode = "DZA", District = "Béjaïa", Population = 117162 },
            new City { ID = 46, Name = "Mostaganem", CountryCode = "DZA", District = "Mostaganem", Population = 115212 },
            new City { ID = 47, Name = "Tébessa", CountryCode = "DZA", District = "Tébessa", Population = 112007 },
            new City { ID = 48, Name = "Tlemcen (Tilimsen)", CountryCode = "DZA", District = "Tlemcen", Population = 110242 },
            new City { ID = 49, Name = "Béchar", CountryCode = "DZA", District = "Béchar", Population = 107311 },
            new City { ID = 50, Name = "Tiaret", CountryCode = "DZA", District = "Tiaret", Population = 100118 },
            ];

        public class City
        {
            public int ID { get; set; }
            public required string Name { get; set; }
            public required string CountryCode { get; set; }
            public required string District { get; set; } 
            public int Population { get; set; }
        }
    }
}
