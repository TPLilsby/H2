using System;

namespace DartMaster
{
    public class Dartboard
    {
        public int CalculateScore(string section, string multiplier)
        {
            int value;
            if (int.TryParse(section, out value))
            {
                switch (multiplier)
                {
                    case "S":
                        return value * 1;
                    case "D":
                        return value * 2;
                    case "T":
                        return value * 3;
                    default:
                        Console.WriteLine("Invalid multiplier!");
                        return 0;
                }
            }
            else if (section == "DB" || section == "OB")
            {
                return 1; // Double and Outer Bull are always single points
            }
            else
            {
                Console.WriteLine("Invalid section!");
                return 0;
            }
        }
    }
}
