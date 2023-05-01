namespace SJF
{

    class Process
    {
        //Name of the process with getter and setter
        public string Name { get; set; }

        //Burst time with getter and setter
        public int BurstTime { get; set; }   

        public Process(string name, int burstTime)             //constructor to set name and burst time
        {
            Name = name;
            BurstTime = burstTime;
        }

        public void Run(int startTime)                   //run the "process" with the current time as arguement
        {
            Console.WriteLine("{0} started at time {1}", Name, startTime);

            Thread.Sleep(BurstTime * 1000);                        //turn the burst time into seconds and simulate doing a job

            Console.WriteLine("{0} finished at time {1}", Name, startTime + BurstTime);
        }
    }



    class SJF
    {
        public static void Main(string[] args)
        {
            // Create a list of processes and add 5 processes to it
            List<Process> processList = new List<Process>();
            processList.Add(new Process("P1", 10));
            processList.Add(new Process("P2", 5));
            processList.Add(new Process("P3", 8));
            processList.Add(new Process("P4", 12));
            processList.Add(new Process("P5", 3));

           
            RunScheduler(processList);                        //call the RunScheduler method
        }

        public static void RunScheduler(List<Process> processList)
        {
            int currentTime = 0;

            while (processList.Count > 0)    //as long as a process is left undone
            {
                //Get the next process with the shortest burst time
                Process currentProcess = processList[0];             
                

                //This foreach statement to see if there are any process in the processList that have a shorter burst time
                foreach (Process p in processList)
                {
                    if (p.BurstTime < currentProcess.BurstTime)
                    {
                        //if the condition is true then change the current process to the shortest time
                        currentProcess = p;
                    }
                }

               

                // Run the process
                currentProcess.Run(currentTime);


                // Remove the process from the list 
                processList.Remove(currentProcess);

                // Update the current time
                currentTime += currentProcess.BurstTime;

                Console.WriteLine("{0} completed at time {1}", currentProcess.Name, currentTime);

           
            }
            Console.WriteLine("Execution took {0} seconds", currentTime);
        }
    }

  
}