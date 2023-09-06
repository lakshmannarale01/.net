namespace leetcode1
{
    internal class Program
    {
        public class Solution
        {
           
            int even = 0;
            int odd = 0;
            public int FindNumbers(int[] nums)
            {
                
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        even++;
                        even = nums[i];
                        Console.WriteLine("even:-" + nums[i] );
                    }

                    else
                    {
                        odd++;
                        odd += nums[i];
                        Console.WriteLine("odd:-" + nums[i]);
                    }
                }
                Console.WriteLine("------------------------------");
                Console.WriteLine(even);
                Console.WriteLine(odd);
                return 1;
            }

            static void Main(string[] args)
            {
                int[] nums = new[] { 12, 345, 2, 6, 7896 };
                int even = 0;
                int odd = 0;

                Solution sol = new Solution();
                sol.FindNumbers(nums);


            }
        }
    }
}