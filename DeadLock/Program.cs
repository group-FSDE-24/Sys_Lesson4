var object1 = new object(); // 0 -> -1 
var object2 = new object(); // 0 -> -1



void ObliviousFunction()
{
    lock (object1)
    {
        Console.WriteLine("critical 1_0");
        Thread.Sleep(500); // wait for the blind to lead

        lock (object2)
        {
            Console.WriteLine("critical 1");
        }
    }
}


void BlindFunction()
{
    lock (object2)
    {
        Console.WriteLine("critical 2_0");
        Thread.Sleep(500); // wait for oblivion

        lock (object1)
        {
            Console.WriteLine("critical 2");
        }
    }
}




new Thread(ObliviousFunction).Start();
new Thread(BlindFunction).Start();

