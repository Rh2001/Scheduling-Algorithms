namespace Priority_Scheduling
{

   internal class Program
    {
        static void Main(string[] args)
        {
          
            int[] priority = { 3, 1, 2 , 0, 4}; // Priority of processes
            int[] burstTime = { 1, 3, 4 ,2 , 3 }; // Burst time of processes 
            int[] waitingTime = new int[priority.Length];
            float avgWaitingTime = 0;

            // Sort the array based on priority
            Array.Sort(priority, burstTime);

            
            waitingTime[0] = 0;
            for (int i = 1; i < priority.Length; i++)
            {
                waitingTime[i] = waitingTime[i - 1] + burstTime[i - 1];
                avgWaitingTime += waitingTime[i];
            }
            avgWaitingTime /= priority.Length;

            // Display process details and waiting time
            Console.WriteLine("Process\tPriority\tBurst Time\tWaiting Time");
            for (int i = 0; i < priority.Length; i++)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}", i + 1, priority[i], burstTime[i], waitingTime[i]);
            }
            Console.WriteLine("\nAverage Waiting Time: " + avgWaitingTime);
            Console.ReadKey();
        }
    }
}