using HULK;
using System.Text.RegularExpressions;
static class Print{
    
     public static bool Parentesis(string expresion) { 
    int count = 0; 
    foreach (char c in expresion) { 
        if (c == '(') { 
            count++; 
        } 
        else if (c == ')') { 
            count--; 
        } 
          if (count < 0) 
        { 
            return false; 
        } 
    } 

    return count == 0; 
}

 
    
    
    
    public static bool printChek(string text){
    string s = Regex.Replace(text, "[^_ÑñA-Za-z0-9]", " ");
    s = " " + s + " ";
    return s.IndexOf(" print ") != -1;
  }
    public static string print (string text){
       int a=text.IndexOf("(");
       int b=text.LastIndexOf(")");
          if(a==-1||b==-1){
           if(a==-1){
             Parser.ErrorList.Add(new Error(Error.ErrorType.Expected,6,"Missing parentesis"));
               return " ";
           } else  Parser.ErrorList.Add(new Error(Error.ErrorType.Expected,text.Length-2,"Missing parentesis"));
              return " ";
            }
        if(text.Contains("'")){
        int c=text.IndexOf("'"); 
        int d=text.LastIndexOf("'");
         if(c==d){
            Parser.ErrorList.Add(new Error(Error.ErrorType.Expected,text.Length-3,"Missing comillas"));
            return " ";
        } else{
            string test=text.Substring(c,d-c); 
            test=test+";";
            return test;
        }
        
       
        } else{ 
            
         
           string test= text.Substring(a+1,b-a-1);
           test=test+";";
           return test;
        }
    }

}