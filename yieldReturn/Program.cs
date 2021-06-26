using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace yieldReturn
{
    public class Sequences
    {
       public static IEnumerable<ulong> Fibonacci
        {
            get { return new FibonacciSequences(); }
        }
    }
    public class FibonacciSequences : IEnumerable<ulong>
    {
        public IEnumerator<ulong> GetEnumerator()
        {
            ulong oneNum = 1;
            ulong twoNum = 1;
            yield return oneNum;
            yield return twoNum;
            while (true)
            {
                ulong res = oneNum + twoNum;
                oneNum = twoNum;
                twoNum = res;
                yield return res;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Sequences.Fibonacci)
            {
                Console.WriteLine(item);
                Thread.Sleep(100);
            }
        }
    }
}
