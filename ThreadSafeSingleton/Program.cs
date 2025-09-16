#nullable disable



// President p0 = new(); // inaccessible


President p1 = President.GetInstance();
President p2 = President.GetInstance();


Console.WriteLine(p1.GetHashCode());
Console.WriteLine(p2.GetHashCode());


class President
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Height { get; set; }

    private President() { }

    private static President _instance;
    private static object _lock = new object();


    public static President GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new President { Name = "XXX", Surname = "XXX", Height = 195 };
                }
            }
        }

        return _instance;
    }
}