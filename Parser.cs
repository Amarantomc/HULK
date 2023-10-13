namespace HULK;

public static class Parser{
    public static string text ;
    private static int pos=0;
    private static Token currentToken;
    private static char currentChar;
    public static List<Error> ErrorList=new List<Error>();
    public static Dictionary<char,double> id=new Dictionary<char, double>();
    
     

 
      private static bool Check(){
        if(text[text.Length-1]!=';'){
           return false;
        } return true;
    } 

 private static void Advanced(){
  pos++;
  if(pos>text.Length-2){
    currentChar='\0';
  } else currentChar=text[pos];
 } 

 private static double Integrer(){
  string result="";
  while(currentChar!='\0'&& (char.IsDigit(currentChar) || currentChar == ',')){
result+=currentChar;
Advanced();
  }  
  return double.Parse(result);
 }
   static void Show(){ 
         for(int i=0;i<ErrorList.Count;i++){
              ErrorList[i].ErrorShow(ErrorList[i]); }
    }
private static Token GetToken(){
   
    
    while(currentChar!='\0'){
   if(char.IsWhiteSpace(currentChar)){
    Advanced();
   }
      if(char.IsDigit(currentChar) || currentChar == ','){
       return new Token("Integrer",Integrer());
    } 
    if(currentChar=='+'){
        
       Advanced();
      return new Token("Plus",'+');
    }  
    if(currentChar=='-'){
      
      Advanced();
      return new Token("Min",'-');
    }
     if(currentChar=='*'){
      
      Advanced();
      return new Token("Mul",'*');
     }
      if(currentChar=='/'){
        
        Advanced();
        return new Token("Div",'/');
      } 
       if(currentChar=='('){
        
        Advanced();
        return new Token("LParen",'(');
       }
        if(currentChar==')'){
          
          Advanced();
          return new Token("RParen",')');
        } if(currentChar=='^'){
          
          Advanced();
          return new Token("Pow",'^');
        } if(currentChar=='>'){
          
          Advanced();
          return new Token("Mayor",'>');
        } 
        if(currentChar=='<'){
           
          Advanced();
          return new Token("Menor",'<');
        } 
        if(currentChar=='|'){
          
          Advanced();
          return new Token("O",'|');
        } 
         if(currentChar=='&'){
           
          Advanced();
          return new Token("And",'&');
        }  
        if(char.IsLetter(currentChar)){
          Advanced();
          if(Let.let(text)){
           string test=Let.letin(text);
           text=test;
           return new Token("let",text);
          } else {ErrorList.Add(new Error(Error.ErrorType.Syntax,pos,"Invalid Syntax")); break;}
        }
        
    } 
     
    return new Token("EOF",null);
    

} 
 
 
 
 
  

  
  

 private static void Gramatical(string Type){
  if(currentToken.Type==Type){
    currentToken= GetToken();
  } else ErrorList.Add(new Error(Error.ErrorType.Syntax,pos,"Invalid Token"));
 }  
 private static double Factor(){ // Factor:Integrer o Parentesis
  double result;
  
   Token token= new Token(currentToken.Type, currentToken.Value);
if(token.Type=="Integrer"){
    Gramatical(token.Type);
return (double)(token.Value);
  } else if(token.Type=="Id"){
    Gramatical(token.Type);
    return (double)(token.Value);
  }   else {
    Gramatical(token.Type);
     result=Result();
     if(currentToken.Type=="RParen"){
   Gramatical(currentToken.Type);
    } else ErrorList.Add(new Error(Error.ErrorType.Syntax,pos,"Parentesis are not completed")); 
        
  return result;
   
  }



 } 
 private static double Term(){  // DiV O MUL
  double result= Imp();
  while(currentToken.Type=="Div"||currentToken.Type=="Mul"){
    if(currentToken.Type=="Div"){
      Gramatical(currentToken.Type);
      result=result/Imp();
    } 
      else if(currentToken.Type=="Mul"){
      Gramatical(currentToken.Type);
      result=result*Imp();
    }
  } return result;
 }  
    private static double Imp(){ // Pow o Raise
      double result =Factor(); 
      while(currentToken.Type=="Pow"){
        Gramatical(currentToken.Type);
        result=Math.Pow(result,Factor());// Falla
      } return result;
    }
 private static double Result(){// PLUS MIN Hecho segun tabla de importancia
                        // la mas arriba de la tabla es la menos importante de presedencia
      double result=Term();
    while(currentToken.Type=="Plus"||currentToken.Type=="Min"){
        if(currentToken.Type=="Plus"){
          Gramatical(currentToken.Type);
          result=result+Term();
  } else if(currentToken.Type=="Min"){
    Gramatical(currentToken.Type);
    result=result-Term();
  }
 } return result; 

  
 } 

   private static bool Boolean(){ //Evaluo booleans
    var result= Result();
    bool boolean=true;
    if(currentToken.Type=="Mayor"){
        Gramatical(currentToken.Type);
        if(result>Result()){
         boolean=true;
       } else boolean=false;
    } if(currentToken.Type=="Menor"){
        Gramatical(currentToken.Type);
      if(result<Result()){
        boolean=true;
      } else boolean=false;
    } if(currentToken.Type=="O"){
        Gramatical(currentToken.Type);
      if(boolean||Boolean()){
         boolean=true;
      } else boolean=false;
    } 
    if(currentToken.Type=="And"){
        Gramatical(currentToken.Type);
      if(boolean && Boolean()){
         boolean=true;
      } else boolean=false;
    }
    return boolean;
   } 

  
  public static string Write(string test){
    text=test;
    pos=0;
    currentChar=text[pos];
    currentToken=GetToken();
    pos=0;
    currentChar=text[pos];
    currentToken=GetToken();
    if(!Check()){
    ErrorList.Add(new Error(Error.ErrorType.Expected,text.Length-1,"; is expected"));
    Show();
      return"";
    } else if(text.Contains('<')||text.Contains('>')||text.Contains('|')||text.Contains('&')){ //si hay booleans llamo si no no{
      var result =Boolean();
      return result.ToString();
     }  else { 
               if(!ErrorList.Any()){
                double result=Result();
            return result.ToString();
             } else{  Show(); return " ";
             
               
             }
             }
  }
  }
              
               
  
    
    
  
 
