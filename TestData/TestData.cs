using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.TestData
{
    public class TestData
    {
        private static readonly Random random = new Random();
        public static string commercialSpacecraftName = "Cspacecraft-ES" + random.Next(1, 100);
        public static string militarySpacecraftName = "Mspacecraft-ES" + random.Next(1, 100);
        public static string researchSpacecraftName = "Rspacecraft-ES" + random.Next(1, 100);

        public static string spaceflightName = "Flight-ES" + random.Next(1, 100);
        public static string maintenanceName = "Maintenance" + random.Next(1, 100);

        public static string countryBG = "Bulgaria";
        public static string countryAU = "Australia";
        public static string countryUS = "United States";

        public static string spaceportSF = "Sofia";
        public static string spaceportNY = "New York"; 
        public static string spaceportSY = "Sydney";

        public static string researchFleet = "Research Fleet";
        public static string commercialFleet = "Commercial Fleet";
        public static string militaryFleet = "Military Fleet";

        public static string researchModel = "Research Model";
        public static string commercialModel = "Commercial Model";
        public static string militaryModel = "Military Model";

        public static string engineName = "Engine-ES" + random.Next(1, 100);

        public static string yearManufacture = random.Next(2000, 2020).ToString();

    }
}
 