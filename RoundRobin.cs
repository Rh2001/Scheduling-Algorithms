namespace RR
{
    public class Process
    {
        public string Name { get; set; }
        public int BurstTime { get; set; }
        public int RemainingTime { get; set; }

        public Process(string name, int burstTime)
        {
            Name = name;
            BurstTime = burstTime;
            RemainingTime = burstTime;
        }
    }

    public class RoundRobin
    {
        public static void Main()
        {
            List<Process> processes = new List<Process>();

            // Add processes to the list
            processes.Add(new Process("P1", 8));
            processes.Add(new Process("P2", 4));
            processes.Add(new Process("P3", 9));
            processes.Add(new Process("P4", 2));
            processes.Add(new Process("P5", 10));

            int quantum = 4; // Set the time quantum to 2

            RunRoundRobin(processes, quantum);
        }

        public static void RunRoundRobin(List<Process> processes, int quantum)
        {
            Queue<Process> readyQueue = new Queue<Process>();
            int totalTime = 0;
            int numProcesses = processes.Count;

            // Add all processes to the ready queue
            foreach (Process p in processes)
            {
                readyQueue.Enqueue(p);
            }

            while (readyQueue.Count > 0)
            {
                Process currentProcess = readyQueue.Dequeue();   //Returns the first item in our roundrobin queue
                Console.WriteLine("Running {0}...", currentProcess.Name);   //Signify which thread is running

                if (currentProcess.RemainingTime <= quantum)        //The remainig burst time is less than our timequantom so the process will finish in time
                {

                    totalTime += currentProcess.RemainingTime;
                    Console.WriteLine("{0} completed in {1}ms.", currentProcess.Name, currentProcess.RemainingTime);   //We can add thread.sleep to turn it into seconds
                    currentProcess.RemainingTime = 0;
                }
                else
                {
                    // Process will not finish within our time quantom
                    totalTime += quantum;
                    currentProcess.RemainingTime -= quantum;
                    Console.WriteLine("{0} did not complete. {1}ms remaining.", currentProcess.Name, currentProcess.RemainingTime);
                    readyQueue.Enqueue(currentProcess); // Add process back to the queue
                }
            }

            Console.WriteLine("All processes completed in {0}ms.", totalTime);
            Console.WriteLine("Average turnaround time: {0}ms", (float)totalTime / numProcesses);
        }
    }
}
