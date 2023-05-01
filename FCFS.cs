namespace FCFS
{
    class Program
    {
        static void Main(string[] args)
        {
            int numProcesses = 5;
            float avgWaitingTime = 0, totalWaitingTime = 0;

            int[] arrivalTime = { 1, 2, 5, 8, 10 }; // Arrival Time
            int[] burstTime = { 3, 8, 4, 7, 6 }; // Burst Time 
            int[] waitingTime = new int[numProcesses];

            waitingTime[0] = 0;    //first proccess so no waiting time

            for (int i = 1; i < numProcesses; i++)      
            {
                waitingTime[i] = waitingTime[i - 1] + burstTime[i - 1] + arrivalTime[i - 1] - arrivalTime[i];   //waiting time is the waiting time of the previous process + its burstt time + the arrival time of the past process + t he arrival time of the current proccess
                totalWaitingTime += waitingTime[i];
            }

            avgWaitingTime = totalWaitingTime / numProcesses;

            Console.WriteLine("\nProcess\tArrival Time\tBurst Time\tWaiting Time");
            for (int i = 0; i < numProcesses; i++)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}", i + 1, arrivalTime[i], burstTime[i], waitingTime[i]);
            }
            Console.WriteLine("\nAverage Waiting Time: " + avgWaitingTime);
            Console.ReadKey();
        }
    }
}

