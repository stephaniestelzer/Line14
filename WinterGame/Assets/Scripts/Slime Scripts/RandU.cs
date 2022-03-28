using System;
public class RandU
{
    public static Random rnd = new Random();

    public static int Rand(int top)
    {
        return rnd.Next(top);
    }
    public static int RandOne(int top)
    {
        return (rnd.Next(top) + 1);
    }
}
