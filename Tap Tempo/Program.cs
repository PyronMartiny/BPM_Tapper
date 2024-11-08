namespace Tap_Tempo
{
    internal class Tap_Tempo
    {
        public static double GetBPM(List<double> times)
        {
            // Fewer than 2 taps will return 0!
            if (times.Count < 2)
            {
                return 0;
            }
            // Init variable for total time of taps
            double totalTime = 0;
            // Loop through each time interval in the list and determine total time
            foreach (var time in times)
            {
                totalTime += time; // Add each time interval to total time variable
            }

            double avgTime = totalTime / times.Count; // Calculate avg time

            double bpm = 60 / avgTime; //Calculate beats per minute(60s)

            return bpm; //return beats per minute
        }

        public static double GetCurrentTimeInSeconds()
        {
            {
                return (DateTime.Now - DateTime.Today).TotalSeconds;
            }
        }
        // create method to gather taps from user input
        public static List<double> Taps(int numTaps)
        {
            List<double> times = new List<double>();
            double previousTime = GetCurrentTimeInSeconds(); //capture the initial time in seconds

            Console.WriteLine("Tap enter to start");

            for (int tap = 0; tap <numTaps; tap++)
            {
                if (tap > 0)
                {
                    Console.WriteLine($"Beat {tap}"); 
                }
                Console.ReadLine(); // Wait for tap

                double currentTime = GetCurrentTimeInSeconds();
                double elapsedTime = currentTime - previousTime; // get time between taps
                previousTime = currentTime; // update previous time

                if (tap > 0)
                {
                    times.Add(elapsedTime);
                }

                //calculate BPM based on captured times

                double currentBPM = GetBPM(times);
                if (currentBPM > 0)
                {
                    Console.WriteLine($"Current BPM: {Math.Round(currentBPM, 2)}");
                }
                else
                {
                    Console.WriteLine("...");
                }
            }

            return times;
        }

        public static void Main()
        {
            int numTaps = 32;
            var tapTimes = Taps(numTaps);

            double bpm = GetBPM(tapTimes);
            Console.WriteLine($"\nFinal BPM after {numTaps} taps: {Math.Round(bpm, 2)}");

            System.Threading.Thread.Sleep(1000);
        }
    }
}
