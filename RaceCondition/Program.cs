namespace RaceCondition;

// Sync Problem

// 1. Application

//      1.1. Interlocked
//      1.2. Monitor
//      1.3. Lock
//      1.4. Semaphore Slim
//      1.5. Mutex


// 2. System

//      2.1. Mutex
//      2.2. Semaphore



class Program
{
    static void Main(string[] args)
    {
        Thread[] threads = new Thread[5];

        var sync = new object();

        for (int i = 0; i < 5; i++)
        {
            threads[i] = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {

                    // Critical Section Start
                    #region example 0

                    // Counter.Count++; // Shared Memory

                    #endregion example 0
                    // Critical Section End


                    #region example 1

                    // Interlocked.Increment(ref Counter.Count);
                    // 
                    // // After
                    // if (Counter.Count % 2 == 0)
                    //     Interlocked.Increment(ref Counter.Count2);

                    #endregion example 1






                    #region example 2
                    // | | |
                    //  Monitor.Enter(sync);
                    //  // | 
                    //  try
                    //  {
                    //      Counter.Count++;
                    //
                    //      if (Counter.Count % 2 == 0)
                    //          Counter.Count2++;
                    //  }
                    //  finally
                    //  {
                    //      Monitor.Exit(sync);
                    //      // |
                    //  }

                    #endregion example 2




                    #region example 3

                    // | | |  ( ready queue )
                    lock (sync)
                    {
                        Counter.Count++;

                        if (Counter.Count % 2 == 0)
                            Counter.Count2++;
                    }

                    #endregion example 3
                }
            });
        }



        for (int i = 0; i < 5; i++) threads[i].Start();
        for (int i = 0; i < 5; i++) threads[i].Join();


        Console.WriteLine($"Count 1: {Counter.Count}");
        Console.WriteLine($"Count 2: {Counter.Count2}");

    }
}

class Counter
{
    public static int Count = 0;
    public static int Count2 = 0;
}