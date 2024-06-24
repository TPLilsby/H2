using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Starwars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Planet> planets = LoadData();

            // 1. Get all planets that starts with M
            Console.WriteLine("1. Get all planets that starts with M");
            var planetsStartWithM = from planet in planets
                                    where planet.Name.StartsWith("M")
                                    select planet;

            foreach (var planet in planetsStartWithM)
            {
                Console.WriteLine(planet.Name);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 2. Get all planets that has a Y in the name
            Console.WriteLine("2. Get all planets that has a Y in the name");
            var planetsWithY = from planet in planets
                               where planet.Name.Contains("y") || planet.Name.Contains("Y")
                               select planet;

            foreach (var planet in planetsWithY)
            {
                Console.WriteLine(planet.Name);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 3. Get all planets that has more than 6 characters and less than 15 characters
            Console.WriteLine("3. Get all planets that has more than 6 characters and less than 15 characters");
            var planetsWithLength = from planet in planets
                                    where planet.Name.Length > 6 && planet.Name.Length < 15
                                    select planet;

            foreach (var planet in planetsWithLength)
            {
                Console.WriteLine(planet.Name);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 4. Get all planets that has a "a2" at the 2nd position and ends with "e"
            Console.WriteLine("4. Get all planets that has a 'a' at the 2nd position and ends with 'e'");
            var planetsWithA2AndEndsWithE = from planet in planets
                                            where planet.Name[1] == 'a' && planet.Name.EndsWith("e")
                                            select planet;

            foreach (var planet in planetsWithA2AndEndsWithE)
            {
                Console.WriteLine(planet.Name);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 5. get all planetss with a rotation period greater than 40 and sort them by rotation period
            Console.WriteLine("5. get all planets with a rotation period greater than 40 and sort them by rotation period");
            var planetsWithRotationPeriod = from planet in planets
                                            where planet.RotationPeriod > 40
                                            orderby planet.RotationPeriod
                                            select planet;

            foreach (var planet in planetsWithRotationPeriod)
            {
                Console.WriteLine(planet.Name + " - " + planet.RotationPeriod);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 6. Get all planets with a rotation period greater than 10 and less than 20 and sort them by name
            Console.WriteLine("6. Get all planets with a rotation period greater than 10 and less than 20 and sort them by name");
            var planetsWithRotationPeriodBetween = from planet in planets
                                                   where planet.RotationPeriod > 10 && planet.RotationPeriod < 20
                                                   orderby planet.Name
                                                   select planet;

            foreach (var planet in planetsWithRotationPeriodBetween)
            {
                Console.WriteLine(planet.Name + " - " + planet.RotationPeriod);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 7. Get all planets with a rotation period that is greater than 30 and sort by name and  rotation period
            Console.WriteLine("7. Get all planets with a rotation period that is greater than 30 and sort by name and  rotation period");
            var planetsWithRotationPeriodGreaterThan30 = from planet in planets
                                                         where planet.RotationPeriod > 30
                                                         orderby planet.Name, planet.RotationPeriod
                                                         select planet;

            foreach (var planet in planetsWithRotationPeriodGreaterThan30)
            {
                Console.WriteLine(planet.Name + " - " + planet.RotationPeriod);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 8. Get all plantes with a rotation period that is less than 30 or surfacewater greater than 50 and there is 'ba' in the name. sort them by name, surfacewater and rotation period
            Console.WriteLine("8. Get all plantes with a rotation period that is less than 30 or surfacewater greater than 50 og there is 'ba' in the name. sort them by name, surfacewater and rotation period");
            var planetsWithRotationPeriodLessThan30 = from planet in planets
                                                      where planet.RotationPeriod < 30 || planet.SurfaceWater > 50
                                                      where planet.Name.Contains("ba")
                                                      orderby planet.Name, planet.SurfaceWater, planet.RotationPeriod
                                                      select planet;

            foreach (var planet in planetsWithRotationPeriodLessThan30)
            {
                Console.WriteLine(planet.Name + " - " + planet.SurfaceWater + " - " + planet.RotationPeriod);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 9. Get all planetss with surfacewater greater than 0 an sort them in descending order by surfacewater
            Console.WriteLine("9. Get all planets with surfacewater greater than 0 an sort them in descending order by surfacewater");
            var planetsWithSurfaceWater = from planet in planets
                                          where planet.SurfaceWater > 0
                                          orderby planet.SurfaceWater descending
                                          select planet;

            foreach (var planet in planetsWithSurfaceWater)
            {
                Console.WriteLine(planet.Name + " - " + planet.SurfaceWater);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 10. Get all planets where you know the diameter and population and sort them by how many km2 avaivable for every person there is on the planet in ascending order.
            Console.WriteLine("10. Get all planets where you know the diameter and population and sort them by how many km2 avaivable for every person there is on the planet in ascending order.");
            var planetsWithDiameterAndPopulation = from planet in planets
                                                   where planet.Diameter > 0 && planet.Population > 0
                                                   orderby (planet.Diameter / planet.Population)
                                                   select planet;

            foreach (var planet in planetsWithDiameterAndPopulation)
            {
                Console.WriteLine(planet.Name + " - " + (planet.Diameter / planet.Population));
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 11. Create a query at removes all the elements from planets where the rotation period is greater than 0 by using Except.
            Console.WriteLine("11. Create a query at removes all the elements from planets where the rotation period is greater than 0 by using Except.");
            var planetsWithPositiveRotationPeriod = planets.Where(planet => planet.RotationPeriod > 0);

            var result = planets.Except(planetsWithPositiveRotationPeriod);

            foreach (var planet in result)
            {
                Console.WriteLine($"{planet.Name} with rotation period {planet.RotationPeriod}");
            }

            // 12. Pt 1. Crate a list with LINQ, with all the plantres that starts or ends with a 'a' and sort them by name.
            Console.WriteLine("12. Pt 1. Crate a list with LINQ, with all the plantres that starts or ends with a 'a' and sort them by name.");
            var planetsStartsOrEndsWithA = from planet in planets
                                           where planet.Name.StartsWith("a") || planet.Name.EndsWith("a")
                                           orderby planet.Name
                                           select planet;
            foreach (var planet in planetsStartsOrEndsWithA)
            {
                Console.WriteLine(planet.Name);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 12. Pt 2. Crate another list with LINQ, with all the plantes that has a terrain that contains 'rainforests'.
            Console.WriteLine("12. Pt 2. Crate another list with LINQ, with all the plantres that has a terrain that contains 'rainforests'.");
            var planetsWithRainforests = from planet in planets
                                         where planet.Terrain != null && planet.Terrain.Contains("rainforests")
                                         select planet;

            foreach (var planet in planetsWithRainforests)
            {
                Console.WriteLine(planet.Name);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");


            // 13. Get all planets where the terrain is 'dessert'.
            Console.WriteLine("13. Get all planets where the terrain is 'dessert'.");
            var planetsWithDessertTerrain = from planet in planets
                                            where planet.Terrain != null && planet.Terrain.Contains("dessert")
                                            select planet;

            foreach (var planet in planetsWithDessertTerrain)
            {
                Console.WriteLine(planet.Name);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 14. Get all planets where the terrain is 'swamps' and sort the list by rotation period.and name.
            Console.WriteLine("14. Get all planets where the terrain is 'swamps' and sort the list by rotation period.and name.");
            var planetsWithSwampsTerrain = from planet in planets
                                           where planet.Terrain != null && planet.Terrain.Contains("swamps")
                                           orderby planet.RotationPeriod, planet.Name
                                           select planet;

            foreach (var planet in planetsWithSwampsTerrain)
            {
                Console.WriteLine(planet.Name + " - " + planet.RotationPeriod);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 15. Find all elements where a double vowel is included in the name of the planet
            Console.WriteLine("15. Find all elements where a double vowel is included in the name of the planet");
            var planetsWithDoubleVowel = from planet in planets
                                         where Regex.IsMatch(planet.Name, @"[aeiou]{2}")
                                         select planet;

            foreach (var planet in planetsWithDoubleVowel)
            {
                Console.WriteLine(planet.Name);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

            // 16.Find all elements that include "kk", "ll", "rr" or "nn" in the name of the planet and sort the list by he name of the planet in descending order
            Console.WriteLine("16.Find all elements that include 'kk', 'll', 'rr' or 'nn' in the name of the planet and sort the list by he name of the planet in descending order");
            var planetsWithDoubleConsonants = from planet in planets
                                              where Regex.IsMatch(planet.Name, @"[klrn]{2}")
                                              orderby planet.Name descending
                                              select planet;

            foreach (var planet in planetsWithDoubleConsonants)
            {
                Console.WriteLine(planet.Name);
            }
            Console.ReadKey();
            Console.WriteLine("------------------------------------");

        }



        static List<Planet> LoadData()
        {
            List<Planet> planets = new List<Planet>()
            {
                new Planet { Name="Corellia", Terrain= new List<string>{ "plains", "urban", "hills", "forests" },RotationPeriod=25,SurfaceWater=70, Diameter=11000, Population=3000000000},
                new Planet { Name="Rodia", Terrain= new List<string>{ "jungles", "oceans", "urban", "swamps" },RotationPeriod=29,SurfaceWater=60, Diameter=7549, Population=1300000000},
                new Planet { Name="Nal Hutta", Terrain= new List<string>{ "urban", "oceans", "bogs", "swamps" },RotationPeriod=87, Diameter=12150, Population=7000000000},
                new Planet { Name="Dantooine",Terrain= new List<string>{ "savannas", "oceans", "mountains", "grasslands" },RotationPeriod=25, Diameter=9830,Population=1000},
                new Planet { Name="Bestine IV",Terrain= new List<string>{ "rocky islands", "oceans" },RotationPeriod=26,SurfaceWater=98, Diameter=6400,Population=62000000},
                new Planet { Name="Ord Mantell",Terrain= new List<string>{ "plains", "seas","mesas" },RotationPeriod=26,SurfaceWater=10, Diameter=14050, Population=4000000000},
                new Planet { Name="Trandosha",Terrain= new List<string>{ "mountains", "seas","grasslands" ,"deserts"},RotationPeriod=25, Diameter=0, Population=42000000},
                new Planet { Name="Socorro", Terrain= new List<string>{ "mountains", "deserts"},RotationPeriod=20, Population=300000000},
                new Planet { Name="Mon Cala",Terrain= new List<string>{ "oceans", "reefs","islands"},RotationPeriod=21,SurfaceWater=100,Diameter=11030,Population=27000000000},
                new Planet { Name="Chandrila", Terrain= new List<string>{ "plains", "forests"},RotationPeriod=20,SurfaceWater=40,Diameter=13500,Population=1200000000},
                new Planet { Name="Sullust", Terrain= new List<string>{ "mountains", "volcanoes","rocky deserts"},RotationPeriod=20,SurfaceWater=5, Diameter=12780, Population=18500000000},
                new Planet { Name="Toydaria", Terrain= new List<string>{ "swamps", "lakes"},RotationPeriod=21, Diameter=7900, Population=11000000},
                new Planet { Name="Malastare",Terrain= new List<string>{ "swamps", "deserts","jungles","mountains"},RotationPeriod=26, Diameter=18880, Population=2000000000},
                new Planet { Name="Dathomir",Terrain= new List<string>{ "forests", "deserts","savannas"},RotationPeriod=24, Diameter=10480, Population=5200},
                new Planet { Name="Ryloth",Terrain= new List<string>{ "mountains", "valleys","deserts","tundra"},RotationPeriod=30,SurfaceWater=5,Diameter=10600, Population=1500000000 },
                new Planet { Name="Aleen Minor"},
                new Planet { Name="Vulpter",Terrain= new List<string>{ "urban", "barren"} ,RotationPeriod=22, Diameter=14900, Population=421000000},
                new Planet { Name="Troiken",Terrain= new List<string>{ "desert", "tundra","rainforests","mountains"} },
                new Planet { Name="Tund",Terrain= new List<string>{ "barren", "ash"} ,RotationPeriod=48, Diameter=12190},
                new Planet { Name="Haruun Kal",Terrain= new List<string>{ "toxic cloudsea", "plateaus","volcanoes"},RotationPeriod=25,Diameter=10120,Population=705300},
                new Planet { Name="Cerea",Terrain= new List<string>{ "verdant"},RotationPeriod=27,SurfaceWater=20,Population=450000000},
                new Planet { Name="Glee Anselm",Terrain= new List<string>{ "islands","lakes","swamps", "seas"},RotationPeriod=33,SurfaceWater=80, Diameter=15600,Population=500000000},
                new Planet { Name="Iridonia",Terrain= new List<string>{ "rocky canyons","acid pools"},RotationPeriod=29},
                new Planet { Name="Tholoth"},
                new Planet { Name="Iktotch",Terrain= new List<string>{ "rocky"},RotationPeriod=22},
                new Planet { Name="Quermia",},
                new Planet { Name="Dorin",RotationPeriod=22, Diameter=13400},
                new Planet { Name="Champala",Terrain= new List<string>{ "oceans","rainforests","plateaus"},RotationPeriod=27, Population=3500000000},
                new Planet { Name="Mirial",Terrain= new List<string>{ "deserts"}},
                new Planet { Name="Serenno",Terrain= new List<string>{ "rivers","rainforests","mountains"}},
                new Planet { Name="Concord Dawn",Terrain= new List<string>{ "jungles","forests","deserts"}},
                new Planet { Name="Zolan" },
                new Planet { Name="Ojom",Terrain= new List<string>{ "oceans","glaciers"},SurfaceWater=100, Population=500000000},
                new Planet { Name="Skako", Terrain = new List<string>{ "urban","vines"},RotationPeriod=27, Population=500000000000},
                new Planet { Name="Muunilinst",Terrain= new List<string>{ "plains","forests","hills","mountains"} ,RotationPeriod=28,SurfaceWater=25, Diameter=13800, Population=5000000000},
                new Planet { Name="Shili",Terrain= new List<string>{ "cities","savannahs","seas","plains"}},
                new Planet { Name="Kalee",Terrain= new List<string>{ "rainforests","cliffs","seas","canyons"},RotationPeriod=23, Diameter=13850, Population=4000000000},
                new Planet { Name="Umbara"},
                new Planet { Name="Tatooine",Terrain= new List<string>{ "deserts"},RotationPeriod=23,SurfaceWater=1, Diameter=10465, Population=200000 },
                new Planet { Name="Jakku",Terrain= new List<string>{ "deserts"}},
                new Planet { Name="Alderaan",Terrain= new List<string>{ "grasslands","mountains"},RotationPeriod=24,SurfaceWater=40, Diameter=12500, Population= 2000000000},
                new Planet { Name="Yavin IV", Terrain= new List<string>{ "rainforests","jungle"},RotationPeriod=24,SurfaceWater=8,Diameter=10200,Population=     1000},
                new Planet { Name="Hoth", Terrain= new List<string>{ "tundra","ice caves","mountain ranges"},RotationPeriod=23,SurfaceWater=100},
                new Planet { Name="Dagobah",Terrain= new List<string>{ "swamp","jungles"},RotationPeriod=23,SurfaceWater=8},
                new Planet { Name="Bespin",Terrain= new List<string>{ "gas giant"},RotationPeriod=12, Diameter=118000,Population=  6000000},
                new Planet { Name="Endor",Terrain= new List<string>{ "forests","mountains","lakes"},RotationPeriod=18,SurfaceWater=8, Diameter=4900, Population= 30000000},
                new Planet { Name="Naboo",Terrain= new List<string>{ "grassy hills","swamps","forests","mountains"},RotationPeriod=26,SurfaceWater=12, Diameter=12120, Population=  4500000000},
                new Planet { Name="Coruscant",Terrain= new List<string>{ "cityscape","mountains"},RotationPeriod=24,Diameter=12240,Population=1000000000000},
                new Planet { Name="Kamino",Terrain= new List<string>{ "ocean"},RotationPeriod=27,SurfaceWater=100,Diameter=19720, Population=1000000000},
                new Planet { Name="Geonosis",Terrain= new List<string>{ "rock","desert","mountain","barren"},RotationPeriod=30,SurfaceWater=5,Diameter=11370, Population=100000000000},
                new Planet { Name="Utapau",Terrain= new List<string>{ "scrublands","savanna","canyons","sinkholes"},RotationPeriod=27,SurfaceWater=0.9f,Diameter=12900,Population=  95000000},
                new Planet { Name="Mustafar",Terrain= new List<string>{ "volcanoes","lava rivers","mountains","caves"},RotationPeriod=36,  Diameter=4200, Population=20000},
                new Planet { Name="Kashyyyk",Terrain= new List<string>{ "jungle","forests","lakes","rivers"},RotationPeriod=26 ,SurfaceWater=60,Diameter=12765, Population=45000000},
                new Planet { Name="Polis Massa",Terrain= new List<string>{ "airless","asteroid"},RotationPeriod=24, Diameter=0, Population=1000000},
                new Planet { Name="Mygeeto",Terrain= new List<string>{ "glaciers","mountains","ice canyons"},RotationPeriod=12, Diameter=10088, Population=  19000000},
                new Planet { Name="Felucia",Terrain= new List<string>{ "fungus","forests"},RotationPeriod=34, Diameter=9100,Population=8500000},
                new Planet { Name="Cato Neimoidia",Terrain= new List<string>{ "mountains","fields","forests","rock arches"},RotationPeriod=25, Population=10000000},
                new Planet { Name="Saleucami",Terrain= new List<string>{ "caves", "deserts","mountains","volcanoes"},RotationPeriod=26, Population=1400000000, Diameter=14920},
                new Planet { Name="Stewjon",Terrain= new List<string>{ "grass"}},
                new Planet { Name="Eriadu",Terrain= new List<string>{ "cityscape"},RotationPeriod=24, Diameter=13490  , Population= 22000000000},
             };
          return planets;
        }
    }
}
