using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateEvolution
{
  class Program
  {

    //I am a very traditional delegate - as you can see I have been declared much like you would declare any other object,
    //the only thing different is the delegate keyword
    public delegate string GetString();

    //Here is a delgate using generics introduced in 2.0 - Not that much different than our previous delegate, still use the delegate keyword 
    //however we can not say that we want to return something and that we have to take something without specifiying what that something is 
    //until later. 
    public delegate Tres GetLen<T, Tres>(T arg);

    static void Main(string[] args)
    {
      
      //Lets see how we can make use of the GetString delegate
      GetString getString = new GetString(DoGettingString);
      //So we created a new variable, again not much different than saying "Person dude = new Person()"; only in this case the 
      //constructor took a method that returned a string - that is because we specified our delegate returns a string. 
      // - Lets see what happens when we use this delegate - 
      Console.WriteLine(getString());
      //Look how it gets called! Just like any other method. 
      Console.ReadKey();
      //
      //OK - that is a wrap on the introduction to delegate as they existed in the days of C# 1 / 1.1
      /////////////////////////////////////////////////////////////////////////////////////////////////

      GetLen<string, int> getLength;
      //2.0 also introduced us to some predefined delegates
      //Action - when you are returning void
      //Func - when you want to return a value
      //Predicate - when you want to return a bool 
      // (Notice you see the word predicate all over linq statements, a lot of times the extension methods will take a predicate) 
      //Here is another example of how we could have declared getLength - For fun, uncomment this then comment out lines 18 and 34.  
      //Func<string, int> getLength;
      //As you can see - we still initialize the delegate by passing a method that matches the in and out parameters. 
      getLength = new GetLen<string, int>(LenghtOfTheString);

      //C# introduced us to inline delegates. This isn't a lamda expression and it isn't something you se very often today
      //it was quickly eclipsed by lambdas. 
      getLength = delegate(string word) { return word.Length; };

      // There is the world as we understood it in C# 2.0
      //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

      // C# 3.0 introduced lambdas
      //Turn the delegate into a lambda expresion
      // In the case below we are telling the compiler what the input type is (string) but normally we don't need to do this
      // it just makes it a little easier to see what is happening. 
      getLength = (string x) => { return x.Length; };
      //Use implicitly typed parameters
      getLength = (x) => { return x.Length; };
      //now get rid of the return statement cause the body of the lamba is a 
      //single expression so it knows that we must want to return whatever the result
      //is - notice the {} are dropped out... 
      getLength = (x) => x.Length;
      //finally drop out the parentheses
      getLength = x => x.Length;
      //It gets more confusing when you start calling methods you have created.
      //the following statement would look like this as a delegate...
      //    getLength = delegate(string x) { return retunRandomNumber(); };
      //In this case we supply the string as an arg however it doesn't get used for anything
      // - of course we still have to supply it cause that is how the delegate is defined. 
      getLength = x => retunRandomNumber();

      Console.WriteLine(getLength("Hi there..."));



      Console.ReadKey();
      //SEE http://msdn.microsoft.com/en-us/library/bb397687.aspx
    }

    static int retunRandomNumber()
    {
      Random ranNum = new Random();
      return ranNum.Next();
    }

    static int LenghtOfTheString(string inString)
    {
      return inString.Length;
    }

    static string DoGettingString()
    {
      return "Hi there person who uses delegates!";
    }
  }
}
