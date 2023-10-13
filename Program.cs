namespace HULK;

internal class Program

{ 
    private static void Main(string[] args)
    {
        Console.WriteLine("Type your code");

        while(true) {
           
            Console.Write("> ");
          string text=Console.ReadLine()!;

            
            
            string result=Parser.Write(text);
            Console.WriteLine(result);
        
        }
    }
}