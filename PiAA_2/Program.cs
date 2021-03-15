using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiAA_2
{
    class Program
    {
        static int binSearch(int val, int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            int middle = (right + left) / 2;
            while (left <= right)
            {
                if (val == nums[middle])
                    return middle;
                if (nums[middle] > val)
                {
                    right = middle - 1;
                }

                if (nums[middle] < val)
                {
                    left = middle + 1;
                }

                middle = (right + left) / 2;
            }

            return -1;
        }
        static void Main(string[] args)
        {
            string inFile = args[0];
            string outFile = args[1];
            FileStream FileReadStream = new FileStream("./"+ inFile, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(FileReadStream);
            FileStream FileWriteFileStream = new FileStream("./"+outFile, FileMode.Open, FileAccess.Write);
            FileWriteFileStream.SetLength(0);
            StreamWriter writer = new StreamWriter(FileWriteFileStream);

            int N = int.Parse(reader.ReadLine());
            string str = reader.ReadLine();
            string[] numsString = str.Split(' ');
            int[] numsInt = new int[numsString.Length];
            for(int i = 0;i<numsString.Length;i++)
                numsInt[i] = int.Parse(numsString[i]);
            int K = int.Parse(reader.ReadLine());
            int num, index;
            for (int i = 0; i < K; i++)
            {
                num = int.Parse(reader.ReadLine());
                index = binSearch(num, numsInt);
                writer.Write(index+"\n");
                
            }
            Console.Write("DONE");
            writer.Close();
            reader.Close();
            
        }
    }
}
