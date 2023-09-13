namespace shortestAndLongestString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the String");
            string word = Console.ReadLine();
            string[] words = word.Split(',');
            if(words.Length > 0 )
            {
                string shortstring = words[0].Trim();
                string longstring = words[0].Trim();
                
                foreach(string i in words)
                {
                    string sepWord = i.Trim();
                    if(sepWord.Length < shortstring.Length )
                    {
                        shortstring = sepWord;
                    
                    }
                     if(sepWord.Length > longstring.Length )
                    {
                        longstring = sepWord;
                    }
                  
                }
                Console.WriteLine($"Longest String is {longstring}");
                Console.WriteLine($"shortest String is {shortstring}");
              

            }
            else
            {
                Console.WriteLine("No string Is found");
            }
        }
    }
}