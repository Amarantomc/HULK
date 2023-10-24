namespace HULK;

public static class Parser{
    public static string text ;
    public static int pos=0;
    public static Token currentToken;
    public static char currentChar;
    public static List<Error> ErrorList=new List<Error>();
     
    
     

 
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
public static Token GetToken(){
   
    
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
           
          while(char.IsLetter(currentChar)){
         
           if(Let.let(text)){
           string test=Let.letin(text);
           text=test;
           Advanced();
            
           
          } else if(Print.printChek(text)) {
             string test =Print.print(text);
             text=test;
             Advanced();
              
             
          } else if(currentChar=='s' ){
             if(Sin.sinCheck(text)){
            string test= Sin.sin(text);
            text=test; 
            Advanced();
            }    
            
           
             
          }  else if( currentChar=='c' ){
           if(Cos.cosCheck(text)){
           string test= Cos.cos(text);
            text=test;
            Advanced();
           } 
             
             
          }  else if( currentChar=='l'){
           if(Log.logCheck(text)){
           string test= Log.log(text);
            text=test;
            Advanced();
           } 
             
             
          }   
           else if(PI.PICheck(text)){
            string test =PI.pi(text);
            text=test;
            Advanced();
            
           }
           else{ 
            if(!text.Contains("'")){
              ErrorList.Add(new Error(Error.ErrorType.Syntax,pos,"Invalid Token"));
              text=";"; break;
            } else break;
            
            
            
            
            } Advanced();
          }
          return new Token("functions",text);
           
        
        }  
        if(currentChar==';'){
          return new Token("end",null);
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
  }   else if(token.Type=="LParen") {
     if(!Print.Parentesis(text)){
     ErrorList.Add(new Error(Error.ErrorType.Syntax,text.Length-1,"Parentesis are not completed"));
     }
    Gramatical(token.Type);
     result=Result();
     Gramatical(token.Type);
    return result;
   
  } else{
    Token tokens =new Token("Integrer",text);
    currentToken=tokens;
    return double.Parse(text.Substring(0,text.Length-1));
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
        result=Math.Pow(result,Factor()); 
      } return result;
    }
 public static double Result(){// PLUS MIN Hecho segun tabla de importancia
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
    if(string.IsNullOrEmpty(test)){
      return "Empty field";
    } 
    ErrorList.Clear();
    text=test;
    pos=0;
    currentChar=text[pos];

     if(!Check()){
    ErrorList.Add(new Error(Error.ErrorType.Expected,text.Length+1,"; is expected"));
    }
    currentToken=GetToken();
    pos=0;
    currentChar=text[pos];
    if(!text.Contains("'")){
     currentToken=GetToken();
     } 
    
      if(currentToken.Type=="EOF"||currentToken.Type=="end"){
       if(ErrorList.Any()){
        Show(); return " ";
       }
    } 
   
    if(!ErrorList.Any()){ 
       if(text.Contains('<')||text.Contains('>')||text.Contains('|')||text.Contains('&')) {
       var result =Boolean(); 
      return result.ToString();
       }
       if(text.Contains("'")){
           return text.Substring(1,text.Length-2);
      } else{
                double result=Result();
                return result.ToString();
        }   

      } else{
        Show(); return " ";
      }
  }
  }
              
               
  
    
    
  
 
