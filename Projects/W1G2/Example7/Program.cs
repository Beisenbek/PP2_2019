using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];

            string[] nums = Console.ReadLine().Split(new char[] { ',',';','#', ' '});

            int sum = 0;
            for(int i = 0; i < nums.Length; ++i)
            {
                a[i] = int.Parse(nums[i]);
                sum += a[i];
            }

            Console.WriteLine(sum);
        }
    }
}
