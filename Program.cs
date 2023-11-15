namespace HULK;

internal class Program

{ 
    private static void Main(string[] args)
    {
        Console.WriteLine("Type your code");   

        while(true) {
           
            Console.Write("> ");
         string text=Console.ReadLine()!;
         //string text="print(sin(2 * PI) ^ 2 + cos(3 * PI / log(4, 64)));";
           
            
            string result=Parser.Write(text);
            Console.WriteLine(result);
                    
        }
    }
}