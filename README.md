# Clean Code Notes In C# (.NET 6.0) (in progress)

This repository is originaly based on [Juan Carlos Ruiz
Clean Code Note](https://github.com/JuanCrg90/Clean-Code-Notes) repository

## Table of contents

- [Chapter 1 - Clean Code](#chapter1)
- [Chapter 2 - Meaningful Names](#chapter2)
- [Chapter 3 - Functions](#chapter3)
- [Chapter 4 - Comments](#chapter4)
- [Chapter 5 - Formatting](#chapter5)
- [Chapter 6 - Objects and Data Structures](#chapter6)
- [Chapter 7 - Error Handling](#chapter7)
- [Chapter 8 - Boundaries](#chapter8)
- [Chapter 9 - Unit Tests](#chapter9)
- [Chapter 10 - Classes](#chapter10)
- [Chapter 11 - Systems](#chapter11)
- [Chapter 12 - Emergence](#chapter12)
- [Chapter 13 - Concurrency](#chapter13)
- [Chapter 14 - Successive Refinement](#chapter14)
- [Chapter 15 - JUnit Internals](#chapter15)
- [Chapter 16 - Refactoring SerialDate](#chapter15)
- [Chapter 17 - Smells and Heuristics](#chapter17)

<a name="chapter1">
<h1>Chapter 1 -  Clean Code</h1>
</a>
This Book is about good programming. It's about how to write good code, and how to transform bad code into good code.

The code represents the detail of the requirements and the details cannot be ignored or abstracted. We may create languages that are closer to the requirements. We can create tools that help us parse and assemble those requirements into formal structures. But we will never eliminate necessary precision.

### Why write bad code?

- Are you in a rush?
- Do you try to go "fast"?
- Do not you have time to do a good job?
- Are you tired of work in the same program/module?
- Does your Boss push you to finish soon?

The previous arguments could create a swamp of senseless code.

If you say "I will back to fix it later" you could fall in the [LeBlanc's law](https://en.wikipedia.org/wiki/Talk%3AList_of_eponymous_laws#Proposal_to_add_LeBlanc.27s_law) "Later equals never"

You are a professional and the code is your responsibility. Let's analyze the following anecdote:

> What if you were a doctor and had a patient who demanded that you stop all the silly hand-washing in preparation for surgery because it was taking too much time? Clearly the patient is the boss; and yet the doctor should absolutely refuse to comply. Why? Because the doctor knows more than the patient about the risks of disease and infection. It would be unprofessional (never mind criminal) for the doctor to comply with the patient.

So too it is unprofessional for programmers to bend to the will of managers who don???t understand the risks of making messes.

Maybe sometime you think in go fast to make the deadline. The only way to go fast is to keep the code as clean as possible at all times.

### What is Clean Code?

Each experimented programmer has his/her own definition of clean code, but something is clear, a clean code is a code that you can read easily. The clean code is code that has been taken care of.

In his book Uncle Bob says the next:

> Consider this book a description of the Object Mentor School of Clean Code. The techniques and teachings within are the way that we practice our art. We are willing to claim that if you follow these teachings, you will enjoy the benefits that we have enjoyed, and you will learn to write code that is clean and professional. But don???t make the mistake of thinking that we are somehow ???right??? in any absolute sense. There are other schools and other masters that have just as much claim to professionalism as we. It would behoove you to learn from them as well.

### The boy Scout Rule

It???s not enough to write the code well. The code has to be kept clean over time. We have all seen code rot and degrade as time passes. So we must take an active role in preventing this degradation.

It's a good practice apply the [Boy Scout Rule](http://programmer.97things.oreilly.com/wiki/index.php/The_Boy_Scout_Rule)

> Always leave the campground cleaner than you found it.

<a name="chapter2">
<h1>Chapter 2 -  Meaningful Names</h1>
</a>

Names are everywhere in software. Files, directories, variables functions, etc. Because we do so much of it. We have better do it well.

### Use Intention-Revealing Names

It is easy to say that names reveal intent. Choosing good names takes time, but saves more than it takes. So take care with your names and change them when you find better ones.

The name of a variable, function or class, should answer all the big questions. It should tell you why it exists, what it does, and how is used. **If a name requires a comment, then the name does not reveals its intent**.

| Does not reveals intention       | Reveals intention       |
| -------------------------------- | ----------------------- |
| `int d; // elapsed time in days` | `int elapsedTimeInDays` |

Choosing names that reveal intent can make much easier to understand and change code. Example:

```csharp
//Bad:
public List<int[]> getThem(List<int[]> theList)
{
    List<int[]> list1 = new List<int[]>();
    foreach (var item in theList)
        if (item[0] == 4)
            list1.Add(item);
    return list1;
}
```

This code is simple, but create many questions:

1. What is the content of `theList`?
2. What is the significance of the item `x[0]` in the list?.
3. Why we compare `x[0]` vs `4`?
4. How would i use the returned list?

The answers to these questions are not present in the code sample, but they could have been. Say that we???re working in a mine sweeper game. We can refactor the previous code as follows:

```csharp
//Good:
const int STATUS_VALUE = 0;
const int FLAGGED = 4;
public List<int[]> getFlaggedCells(List<int[]> gameBoard)
{
    List<int[]> flaggedCells = new List<int[]>();
    foreach (int[] cell in gameBoard)
        if (cell[STATUS_VALUE] == FLAGGED)
            flaggedCells.Add(cell);
    return flaggedCells;
}
```

Now we know the next information:

1. `theList` represents the `gameBoard`
2. `x[0]` represents a cell in the board and `4` represents a flagged cell
3. The returned list represents the `flaggedCells`

Notice that the simplicity of the code has not changed. It still has exactly the same number of operators and constants, with exactly the same number of nesting levels. But the code has become much more explicit.

We can improve the code writing a simple class for cells instead of using an array of `ints`. It can include an **intention-revealing function** (called it `isFlagged`) to hide the magic numbers. It results in a new function of the function.

```csharp
//Better:
public List<Cell> getFlaggedCells(List<Cell> gameBoard)
{
    List<Cell> flaggedCells = new List<Cell>();
    foreach (Cell cell in gameBoard)
        if (cell.isFlagged())
            flaggedCells.Add(cell);
    return flaggedCells;
}
```

### Avoid Disinformation

Programmers must avoid leaving false clues that obscure the meaning of code. We should avoid words whose entrenched meaning vary from our intended meaning.

Do not refer to a grouping of accounts as an `accountList` unless it's actually a `List`. The word `List` means something specific to programmers. If the container holding the accounts is not actually a List, it may lead to false conclusions. So `accountGroup` or `bunchOfAccounts` or just plain `accounts` would be better.

```csharp
//Bad:
var accountList = new List<Account>();
//Good:
var accounts = new List<Account>();
```

Beware of using names which vary in small ways. How long does it take to spot the subtle difference between a `XYZControllerForEfficientHandlingOfStrings` in one module and, somewhere a little more distant, `XYZControllerForEfficientStorageOfStrings`? The words have frightfully similar shapes

```csharp
//Bad:
public class Controllers
{
    public async Task XYZControllerForEfficientHandlingOfStrings()
    {
    }

    public async Task XYZControllerForEfficientStorageOfStrings()
    {
    }
}
//Good:
public class XYZControllerForEfficient
{
    public async Task HandlingOfStrings()
    {
    }

    public async Task StorageOfStrings()
    {
    }
}
```

### Make Meaningful Distinctions

Programmers create problems for themselves when they write code solely to satisfy a compiler or interpreter. For example because you can't use the same name to refer two different things in the same scope, you might be tempted to change one name in an arbitrary way. Sometimes this is done by misspelling one, leading to the surprising situation where correcting spelling errors leads to an inability to compile. Example, you create the variable `klass`because the name `class` was used for something else.
.
In the next function, the arguments are noninformative, `a1` and `a2` doesn't provide clues to the author intention.

```csharp
public static void copyChars(char[] a1, char[] a2)
{
    for (var i = 0; i < a1.Length; i++) a2[i] = a1[i];
}
```

We can improve the code selecting more explicit argument names:

```csharp
public static void copyChars(char[] source, char[] destination)
{
    for (var i = 0; i < source.Length; i++) destination[i] = source[i];
}
```

Noise words are another meaningless distinction. Imagine that you have a Product class. If you have another called `ProductInfo` or `ProductData`, you have made the names different without making them mean anything different. Info and Data are indistinct noise words like a, an, and the.

```csharp
//Bad:
public class ProductInfo{

}
public class ProductData{

}
//Good:
public class Product{

}
```

Noise words are redundant. The word variable should never appear in a variable name. The word table should never appear in a table name.

### Use Pronounceable Names

Imagine you have the variable `genymdhms` (Generation date, year, month, day, hour, minute and second) and imagine a conversation where you need talk about this variable calling it "gen why emm dee aich emm ess". You can consider convert a class like this:

```csharp
private class DtaRcrd102
{
    private const string pszqint = "102";
    private DateTime genymdhms;
    private DateTime modymdhms;
    /* ... */
}
```

To

```csharp
private class Customer
{
    private const string recordId = "102";
    private DateTime generationTimestamp;
    private DateTime modificationTimestamp;
    /* ... */
}
```

### Use Searchable Names

Single-letter names and numeric constants have a particular problem in that they are not easy to locate across a body of text.

```csharp
//Bad:
public double FooFuction(int[] t)
{
    double s = 0;
    for (var j = 0; j < 34; j++) s += t[j] * 4 / 5;
    return s;
}
//Good:
public double FooFuction(int[] taskEstimate)
{
    const int NUMBER_OF_TASKS = 34;
    var realDaysPerIdealDay = 4;
    const int WORK_DAYS_PER_WEEK = 5;
    double sum = 0;
    for (var j = 0; j < NUMBER_OF_TASKS; j++)
    {
        var realTaskDays = taskEstimate[j] * realDaysPerIdealDay;
        var realTaskWeeks = realTaskDays / WORK_DAYS_PER_WEEK;
        sum += realTaskWeeks;
    }
    return sum;
}
```

### Avoid Encoding

We have enough encodings to deal with without adding more to our burden. Encoding type or scope information into names simply adds an extra burden of deciphering. Encoded names are seldom pronounceable and are easy to mis-type. An example of this, is the use of the [Hungarian Notation](https://en.wikipedia.org/wiki/Hungarian_notation) or the use of member prefixes.

```csharp
//Bad:
public class Bad
{
    private int[] arri8NumberList = new int[8];
    private long lAccountNum;
    private string strName;
    public string m_description { get; set; }
}
//Good:
public class Good
{
    private long account;
    private string name;
    private int[] numbers = new int[8];
    public string Description { get; set; }
}
```

#### Interfaces and Implementations

These are sometimes a special case for encodings. For example, say you are building an ABSTRACT FACTORY for the creation of shapes. This factory will be an interface and will be implemented by a concrete class. What should you name them? `IShapeFactory` and `ShapeFactory`? Is preferable to leave interfaces unadorned.I don???t want my users knowing that I???m handing them an interface. I just want them to know that it???s a `ShapeFactory`. So if I must encode either the interface or the implementation, I choose the implementation. Calling it `ShapeFactoryImp`, or even the hideous `CShapeFactory`, is preferable to encoding the interface.

```csharp
//Good:
public interface IGood
{
}

public class GoodImp : IGood
{
}

public class CGood : IGood
{
}
```

### Avoid Mental Mapping

Readers shouldn't have to mentally translate your names into other names they already know.

One difference between a smart programmer and a professional programmer is that the professional understands that **clarity is king**. Professionals use their powers for good and write code that others can understand.

```csharp
public class Product
{
    public int Id { get; set; }
    public int FooProperty { get; set; }
}
//Bad:
public class Bad
{
    public int CalculateProductSomeData(List<Product> products)
    {
        var result = 0;
        foreach (var p in products)
        {
            // lots of code here

            var evaluatedFooProperty = p.FooProperty;

            result += evaluatedFooProperty;

            // lots of code here
        }

        return result;
    }
}
//Good:
public class Good
{
    public int CalculateProductSomeData(List<Product> products)
    {
        var result = 0;
        foreach (var product in products)
        {
            // lots of code here

            var evaluatedFooProperty = product.FooProperty;

            result += evaluatedFooProperty;

            // lots of code here
        }

        return result;
    }
}
```

### Class Names

Classes and objects should have noun or noun phrase names like `Customer`, `WikiPage`, `Account`, and `AddressParser`. Avoid words like `Manager`,`Processor`, `Data`, or `Info` in the name of a class. A class name should not be a verb.

```csharp
//Bad:
public class CustomerManager{}
public class PaymentProcessor{}
public class ProductData{}
public class BookInfo{}
public class ManageStock{}
//Good:
public class Customer{}
public class Payment{}
public class Product{}
public class Book{}
public class StockManager{}
```

### Method Names

Methods should have verb or verb phrase names like `postPayment`, `deletePage` or `save`. Accessors, mutators, and predicates should be named for their value and prefixed with get, set, and is according to the javabean standard.

When constructors are overloaded, use static factory methods with names that describe the arguments. For example:

```csharp
//Bad:
public class Complex
{
    private double doublePartOfComplex;
    public Complex(double d)
    {
        doublePartOfComplex = d;
    }
}

public class Employee
{
    private string name;
    public string NameGetter()
    {
        return name;
    }
}

public class Customer
{
    private string name;
    public void NameSettr(string s)
    {
        name = s;
    }
}

public class PayCheck
{
    private PayCheckState state;
    public int ReturnPayCheckState()
    {
        return (int)state;
    }
    private enum PayCheckState
    {
        Calcelated,
        Posted
    }
}

var complex = new Complex(23.0);
var employee = new Employee();
var employeeName = employee.NameGetter();
var customer = new Customer();
customer.NameSettr("Mike");
var payCheck = new PayCheck();
if (payCheck.ReturnPayCheckState() == 1)
{
    //do somethings
}
//Good:
public class Complex
{
    private double doublePartOfComplex;
    private Complex(double doublePartOfComplex)
    {
        this.doublePartOfComplex = doublePartOfComplex;
    }
    public static Complex FromDoubleNumber(double d)
    {
        return new Complex(d);
    }
}

public class Employee
{
    private string name;
    public string GetName()
    {
        return name;
    }
}

public class Customer
{
    private string name;
    public void SetName(string s)
    {
        name = s;
    }
}

public class PayCheck
{
    private PayCheckState state;
    public bool IsPosted()
    {
        return state == PayCheckState.Posted;
    }
    private enum PayCheckState
    {
        Calcelated,
        Posted
    }
}

var complex = Complex.FromDoubleNumber(23.0);
var employee = new Employee();
var employeeName = employee.GetName();
var customer = new Customer();
customer.SetName("Mike");
var payCheck = new PayCheck();
if (payCheck.IsPosted())
{
    //do somethings
}
```

Consider enforcing their use by making the corresponding constructors private.

### Don't Be Cute

| Cute name         | Clean name    |
| ----------------- | ------------- |
| `holyHandGranade` | `deleteItems` |
| `whack`           | `kill`        |
| `eatMyShorts`     | `abort`       |

### Pick one word per concept

Pick one word for one abstract concept and stick with it. For instance, it???s confusing to have fetch, retrieve, and get as equivalent methods of different classes.

```csharp
//Bad:
var devices = device.FetchDevices();
var products = product.GetProducts();
var customers = customer.RetriveCustomers();
//Good:
var devices = device.GetDevices();
var products = product.GetProducts();
var customers = customer.GetCustomers();
```

### Don???t Pun

Avoid using the same word for two purposes. Using the same term for two different ideas is essentially a pun.

Example: in a class use `add` for create a new value by adding or concatenating two existing values and in another class use `add` for put a simple parameter in a collection, it's a better options use a name like `insert` or `append` instead.

```csharp
//Bad:
public class Customer
{
    public int Add(string Name)
    {
        // Add a new customer to DB
        throw new NotImplementedException();
    }
}
public class CustomString
{
    public int Add(string stringToAppend)
    {
        // Append input string to exist string
        throw new NotImplementedException();
    }
}
public class CustomLogger
{
    public int Add(string logData)
    {
        // insert log on media
        throw new NotImplementedException();
    }
}
//Good:
public class Customer
{
    public int Add(string Name)
    {
        // Add a new customer to DB
        throw new NotImplementedException();
    }
}
public class CustomString
{
    public int Append(string stringToAppend)
    {
        // Append input string to exist string
        throw new NotImplementedException();
    }
}
public class CustomLogger
{
    public int Insert(string logData)
    {
        // insert log on media
        throw new NotImplementedException();
    }
}
```

### Use Solution Domain Names

Remember that the people who read your code will be programmers. So go ahead and use computer science (CS) terms, algorithm names, pattern names, math terms, and so forth.

### Use Problem Domain Names

When there is no ???programmer-eese??? for what you???re doing, use the name from the problem domain. At least the programmer who maintains your code can ask a domain expert what it means.

```csharp
public class AccountVisitor{}
public class StockDBContext{}
public class JobQueue{}
public class AuthorizationFilterAttribute{}
```

### Add Meaningful context

There are a few names which are meaningful in and of themselves???most are not. Instead, you need to place names in context for your reader by enclosing them in well-named classes, functions, or namespaces. When all else fails, then prefixing the name may be necessary as a last resort

Variables like: `firstName`, `lastName`, `street`, `city`, `state`. Taken together it's pretty clear that they form an address, but, what if you saw the variable state being used alone in a method?, you could add context using prefixes like: `addrState` at least readers will understand that the variable is part of a large structure. Of course, a better solution is to create a class named `Address` then even the compiler knows that the variables belong to a bigger concept

```csharp
//First example
//Bad:
var state = "Tehran";
//Some code here
var firstName = "Ali";
//Some code here
var lastName = "Ahmadi";
//Some code here
var street = "Avenue";
//-----------------------------------
//Good:
var companyState = "Tehran";
//Some code here
var userFirstName = "Ali";
//Some code here
var customerLastName = "Ahmadi";
//Some code here
var addressStreet = "Avenue";
```

```csharp
//Second example - Original book example
//Bad:
private void printGuessStatistics(char candidate, int count)
{
    string number;
    string verb;
    string pluralModifier;
    if (count == 0)
    {
        number = "no";
        verb = "are";
        pluralModifier = "s";
    }
    else if (count == 1)
    {
        number = "1";
        verb = "is";
        pluralModifier = "";
    }
    else
    {
        number = Convert.ToString(count);
        verb = "are";
        pluralModifier = "s";
    }

    var guessMessage = string.Format(
        "There {0} {1} {2}{3}", verb, number, candidate, pluralModifier
    );
    Console.WriteLine(guessMessage);
}
//Good:
public class GuessStatisticsMessage
{
    private string number;
    private string pluralModifier;
    private string verb;

    public string make(char candidate, int count)
    {
        createPluralDependentMessageParts(count);
        return string.Format(
            "There {0} {1} {2}{3}",
            verb, number, candidate, pluralModifier);
    }

    private void createPluralDependentMessageParts(int count)
    {
        if (count == 0)
            thereAreNoLetters();
        else if (count == 1)
            thereIsOneLetter();
        else
            thereAreManyLetters(count);
    }

    private void thereAreManyLetters(int count)
    {
        number = Convert.ToString(count);
        verb = "are";
        pluralModifier = "s";
    }

    private void thereIsOneLetter()
    {
        number = "1";
        verb = "is";
        pluralModifier = "";
    }

    private void thereAreNoLetters()
    {
        number = "no";
        verb = "are";
        pluralModifier = "s";
    }
}
```

### Don???t Add Gratuitous Context

In an imaginary application called ???Gas Station Deluxe,??? it is a bad idea to prefix every class with GSD. Example: `GSDAccountAddress`

Shorter names are generally better than longer ones, so long as they are clear. Add no more context to a name than is necessary.

```csharp
//Bad:
public class GSDStock{}
public class GSDUserController{}
public class GSDAccountAddress{}
public class GSDMailingAddress{}
//Good:
public class Stock{}
public class UserController{}
public class Account{}
public class Mailing{}
```

<a name="chapter3">
<h1>Chapter 3 -  Functions</h1>
</a>

Functions are the first line of organization in any topic.

### Small!!

The first rule of functions is that they should be **small**. The second rule of functions is that they should be **smaller** than that.
Here is an example form [Caio Cesar](https://dev.to/caiocesar/clean-code-in-c-part-2-methods-58mb) [dev.to](https://dev.to)

```csharp
//Bad:
public class Bad
{
    public void Main()
    {
        int[] array = { 10, 5, 1, 7, 2 };

        Console.WriteLine("Array:");
        foreach (var p in array)
            Console.WriteLine(p + " ");

        Console.WriteLine("Sorted Array:");
        foreach (var p in BubbleSort(array))
            Console.WriteLine(p + " ");

        Console.Read();
    }

    private int[] BubbleSort(int[] arr)
    {
        int temp;
        for (var j = 0; j < arr.Length - 1; j++)
            for (var i = 0; i < arr.Length - 1; i++)
                if (arr[i] > arr[i + 1])
                {
                    temp = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = temp;
                }

        return arr;
    }
}
//Good:
public class Good
{
    public void Main()
    {
        int[] array = { 10, 5, 1, 7, 2 };
        PrintArray(array, "Array:");
        PrintArray(BubbleSort(array), "Sorted Array:");
        Console.Read();
    }

    private int[] BubbleSort(int[] arr)
    {
        for (var j = 0; j < arr.Length - 1; j++)
            for (var i = 0; i < arr.Length - 1; i++)
                if (arr[i] > arr[i + 1])
                    arr = SwapArrayIndex(arr, i, i + 1);

        return arr;
    }

    private void PrintArray(int[] array, string title)
    {
        Console.WriteLine($"{title}");
        foreach (var p in array)
            Console.WriteLine($"{p} ");
    }

    private int[] SwapArrayIndex(int[] arr, int beginIndex, int endIndex)
    {
        (arr[endIndex], arr[beginIndex]) = (arr[beginIndex], arr[endIndex]);
        return arr;
    }
}
```

#### Blocks and Indenting

This implies that the blocks within `if` statements, `else` statements, `while` statements, and so on should be one line long. Probably that line should be a function call. Not only does this keep the enclosing function small, but also adds documentary value because the function called within the block can have a nicely descriptive name.

This also implies that functions should not be large enough to hold nested structures. Therefore, the indent level of a function should not be greater than one or two. This, of course, makes the functions easy to read and understand.

```csharp
//Bad:
public Student Find(List<Student> list, int id)
{
Student r = null;foreach (var i in list)
{
if (i.Id == id)
    r = i;          }          return r;
}
//Good:
public Student Find(List<Student> Students, int id)
{
    Student result = null;
    foreach (var student in Students)
        if (student.Id == id)
            result = student;
    return result;
}
```

### Do One Thing

**FUNCTIONS SHOULD DO ONE THING. THEY SHOULD DO IT WELL. THEY SHOULD DO IT ONLY.**

Here is an example form [Daniel Metcalfe Github.io](https://moderatemisbehaviour.github.io/clean-code-smells-and-heuristics/general/g30-functions-should-do-one-thing.html) in java which converted to C#.

```csharp
//Bad:
public void pay(List<Employee> employees)
{
    foreach (var employee in employees)
        if (employee.isPayDay())
        {
            var pay = employee.calculatePay();
            employee.deliverPay(pay);
        }
}
//Good:
public void pay(List<Employee> employees)
{
    foreach (var employee in employees) payIfNecessary(employee);
}
private void payIfNecessary(Employee e)
{
    if (e.isPayDay())
        calculateAndDeliverPay(e);
}
private void calculateAndDeliverPay(Employee employee)
{
    var pay = employee.calculatePay();
    employee.deliverPay(pay);
}
```

#### Sections within Functions

If you have a function divided in sections like _declarations_, _initialization_ etc, it's a obvious symptom of the function is doing more than one thing. Functions that do one thing cannot be reasonably divided into sections.

### One Level of Abstraction per Function

In order to make sure our functions are doing "one thing", we need to make sure that the statements within our function are all at the same level of abstraction.

#### Reading Code from Top to Bottom: _The Stepdown Rule_

We want the code to read like a top-down narrative. We want every function to be followed by those at the next level of abstraction so that we can read the program, descending one level of abstraction at a time as we read down the list of functions.

To say this differently, we want to be able to read the program as though it were a set
of TO paragraphs, each of which is describing the current level of abstraction and referencing subsequent TO paragraphs at the next level down.

```
- To include the setups and teardowns, we include setups, then we include the test page content, and then we include the teardowns.
- To include the setups, we include the suite setup if this is a suite, then we include the regular setup.
- To include the suite setup, we search the parent hierarchy for the ???SuiteSetUp??? page and add an include statement with the path of that page.
- To search the parent...
```

It turns out to be very difficult for programmers to learn to follow this rule and write functions that stay at a single level of abstraction. But learning this trick is also very important. It is the key to keeping functions short and making sure they do ???one thing.??? Making the code read like a top-down set of TO paragraphs is an effective technique for keeping the abstraction level consistent.

First example is form [Nilanjan Dutta C# Corner](https://www.c-sharpcorner.com/article/clean-code-single-level-of-abstraction/)

```csharp
//Bad:
public List<WeatherDataDto> GetWeatherReport()
{
    var weatherDtoList = new List<WeatherDataDto>();
    var weatherReport = JsonConvert.DeserializeObject<WeatherDataModel[]>(File.ReadAllText("weather.json"));
    if (weatherReport != null && weatherReport.Length > 0)
        foreach (var report in weatherReport)
        {
            var weatherDto = new WeatherDataDto
            {
                City = report.city,
                Temparature = report.temp,
                ReportedBy = report.reportedBy
            };
            weatherDtoList.Add(weatherDto);
        }
    return weatherDtoList;
}
//Good:
public List<WeatherDataDto> GetWeatherReport()
{
    var weatherDtoList = new List<WeatherDataDto>();
    var weatherReport = ReadWeatherReport();
    if (IsValidWeatherReport(weatherReport)) MapToReportDto(weatherDtoList, weatherReport);
    return weatherDtoList;
}

private static WeatherDataModel[] ReadWeatherReport()
{
    return JsonConvert.DeserializeObject<WeatherDataModel[]>(File.ReadAllText("weather.json"));
}

private static bool IsValidWeatherReport(WeatherDataModel[] weatherReport)
{
    return weatherReport != null && weatherReport.Length > 0;
}

private static void MapToReportDto(List<WeatherDataDto> weatherDtoList, WeatherDataModel[] weatherReport)
{
    foreach (var report in weatherReport)
    {
        var weatherDto = new WeatherDataDto
        {
            City = report.city,
            Temparature = report.temp,
            ReportedBy = report.reportedBy
        };
        weatherDtoList.Add(weatherDto);
    }
}
```

Second example is form [principles-wiki](http://principles-wiki.net/principles:single_level_of_abstraction)

```csharp
//Bad:
public List<ResultDto> buildResult(List<ResultEntity> resultSet)
{
    var result = new List<ResultDto>();
    foreach (var entity in resultSet)
    {
        var dto = new ResultDto();
        dto.setShoeSize(entity.getShoeSize());
        dto.setNumberOfEarthWorms(entity.getNumberOfEarthWorms());
        dto.setAge(_dateHelper.computeAge(entity.getBirthday()));
        result.Add(dto);
    }
    return result;
}
//Good:
public List<ResultDto> buildResult(List<ResultEntity> resultSet)
{
    return resultSet.Select(toDto).ToList();
}

private ResultDto toDto(ResultEntity entity)
{
    var dto = new ResultDto();
    dto.setShoeSize(entity.getShoeSize());
    dto.setNumberOfEarthWorms(entity.getNumberOfEarthWorms());
    dto.setAge(_dateHelper.computeAge(entity.getBirthday()));
    return dto;
}
```

### Switch Statements

It???s hard to make a small switch statement. Even a switch statement with only two cases is larger than I???d like a single block or function to be. It???s also hard to make a switch statement that does one thing. By their nature, switch statements always do N things. Unfortunately we can???t always avoid switch statements, but we can make sure that each switch statement is buried in a low-level class and is never repeated. We do this, of course, with polymorphism.

Here is an example from [stackoverflow](https://stackoverflow.com/questions/61568293/refactoring-to-factory-method) that convert a switch statement to Factory method.

```csharp
//Bad:
public static IService CreateService(string path, ILogger log, IConfig mappingConfig)
{
    switch (path)
    {
        case ServicePath.service1:
            return new service1(log, mappingConfig);
        case ServicePath.service2:
            return new service2(log, mappingConfig);
        case ServicePath.service3:
            return new service3(log, mappingConfig);
        case ServicePath.service4:
            return new service4(log, mappingConfig);
    }

    return new notImpelmented(log, mappingConfig);
}
//Good:
private readonly Dictionary<string, Func<ILogger, IConfig, IService>> _map;

public GoodServiceFactory()
{
    _map = new Dictionary<string, Func<ILogger, IConfig, IService>>();
    _map.Add(ServicePath.service1, (log, mappingConfig) => new service1(log, mappingConfig));
    _map.Add(ServicePath.service2, (log, mappingConfig) => new service2(log, mappingConfig));
    _map.Add(ServicePath.service3, (log, mappingConfig) => new service3(log, mappingConfig));
    _map.Add(ServicePath.service4, (log, mappingConfig) => new service4(log, mappingConfig));
}

public IService CreateService(string path, ILogger log, IConfig mappingConfig)
{
    return _map.ContainsKey(path)
        ? _map[path](log, mappingConfig)
        : new notImpelmented(log, mappingConfig);
}
```

### Use Descriptive Names

> You know you are working on clean code when each routine turns out to be pretty much what you expected

Half the battle to achieving that principle is choosing good names for small functions that do one thing. The smaller and more focused a function is, the easier it is to choose a descriptive name.

Don???t be afraid to make a name long. A long descriptive name is better than a short enigmatic name. A long descriptive name is better than a long descriptive comment. Use a naming convention that allows multiple words to be easily read in the function names, and then make use of those multiple words to give the function a name that says what it does.

Choosing descriptive names will clarify the design of the module in your mind and help you to improve it. It is not at all uncommon that hunting for a good name results in a favorable restructuring of the code.

Here is some descriptive function name from past codes.

```csharp
GetWeatherReport()
ReadWeatherReport()
IsValidWeatherReport(WeatherDataModel[] weatherReport)
MapToReportDto(List<WeatherDataDto> weatherDtoList, WeatherDataModel[] weatherReport)
```

### Function arguments

The ideal number of arguments for a function is zero (niladic). Next comes one (monadic), followed closely by two (dyadic). Three arguments (triadic) should be avoided where possible. More than three (polyadic) requires very special justification???and then shouldn???t be used anyway.

Arguments are even harder from a testing point of view. Imagine the difficulty of writing all the test cases to ensure that all the various combinations of arguments work properly. If there are no arguments, this is trivial. If there???s one argument, it???s not too hard. With two arguments the problem gets a bit more challenging. With more than two arguments, testing every combination of appropriate values can be daunting.

Output arguments are harder to understand than input arguments. When we read a function, we are used to the idea of information going in to the function through arguments and out through the return value. We don???t usually expect information to be going out through the arguments. So output arguments often cause us to do a double-take.

#### Common Monadic Forms

There are two very common reasons to pass a single argument into a function. You may be asking a question about that argument, as in `boolean fileExists(???MyFile???)` . Or you may be operating on that argument, transforming it into something else and returning it. For example, `InputStream fileOpen(???MyFile???)` transforms a file name `String` into an `InputStream` return value. These two uses are what readers expect when they see a function. You should choose names that make the distinction clear, and always use the two forms in a consistent context.

#### Flag Arguments

Flag arguments are ugly. Passing a boolean into a function is a truly terrible practice. It immediately complicates the signature of the method, loudly proclaiming that this function does more than one thing. It does one thing if the flag is `true` and another if the flag is `false`!

```csharp
//Bad:
public Booking Book(Customer aCustomer, bool isPremium)
{
    if (isPremium)
        doforPremium();
    // logic for premium book
    else
        doforNotPremium();
    // logic for regular booking
    throw new NotImplementedException();
}
//Good:
public Booking regularBook(Customer aCustomer)
{
    doforNotPremium();
    // logic for regular booking
    throw new NotImplementedException();
}

public Booking premiumBook(Customer aCustomer)
{
    doforPremium();
    // logic for premium book
    throw new NotImplementedException();
}
```

#### Dyadic Functions

> A function with two arguments is harder to understand than a monadic function.

For example, `writeField(name)` is easier to understand than `writeField(output-Stream, name)`

There are times, of course, where two arguments are appropriate. For example, `Point p = new Point(0,0);` is perfectly reasonable. Cartesian points naturally take two arguments.

Even obvious dyadic functions like assertEquals(expected, actual) are problematic. How many times have you put the actual where the expected should be? The two arguments have no natural ordering. The expected, actual ordering is a convention that requires practice to learn.

Dyads aren???t evil, and you will certainly have to write them. However, you should be aware that they come at a cost and should take advantage of what mechanims may be available to you to convert them into monads. For example, you might make the writeField method a member of outputStream so that you can say outputStream. writeField(name) . Or you might make the outputStream a member variable of the current class so that you don???t have to pass it. Or you might extract a new class like FieldWriter that takes the outputStream in its constructor and has a write method.

#### Triads

Functions that take three arguments are significantly harder to understand than dyads. The issues of ordering, pausing, and ignoring are more than doubled.

> I suggest you think very carefully before creating a triad.

Here is an example from [Clean Code concepts adapted for .NET/.NET Core](https://github.com/thangchung/clean-code-dotnet)

```csharp
//Bad:
public void CreateMenu(string title, string body, string buttonText, bool cancellable)
{
    // ...
}
//Good:
public class MenuConfig
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string ButtonText { get; set; }
    public bool Cancellable { get; set; }
}
public void CreateMenu(MenuConfig config)
{
    // ...
}
```

#### Argument Objects

```csharp
//Bad:
Circle makeCircle(double x, double y, double radius);
//Good:
Circle makeCircle(Point center, double radius);
```

#### Verbs and Keywords

Choosing good names for a function can go a long way toward explaining the intent of the function and the order and intent of the arguments. In the case of a monad, the function and argument should form a very nice verb/noun pair. For example, `write(name)` is very evocative. Whatever this ???name??? thing is, it is being ???written.??? An even better name might be `writeField(name)` , which tells us that the "name" thing is a "field".

This last is an example of the keyword form of a function name. Using this form we encode the names of the arguments into the function name. For example, `assertEquals` might be better written as `assertExpectedEqualsActual(expected, actual)`. This strongly mitigates the problem of having to remember the ordering of the arguments.

### Have No Side Effects

Side effects are lies. Your function promises to do one thing, but it also does other hidden things. Sometimes it will make unexpected changes to the variables of its own class. Sometimes it will make them to the parameters passed into the function or to system globals. In either case they are devious and damaging mistruths that often result in strange temporal couplings and order dependencies.

```csharp
//Bad:
public bool CheckUser(string userName, string password)
{
    var user = _userService.FindByName(userName);
    if (user != null)
    {
        var codedPharase = user.GetPhraseEncodedByPassword();
        var pharase = _cryptographer.Decrypt(codedPharase, password);
        if (pharase == "Valid")
        {
            _session.Initialize();
            return true;
        }
    }
    return false;
}
//Good:
public ActionResult Login(RequestLogin requestLogin)
{
    if (CheckUser(requestLogin.UserName, requestLogin.Password))
    {
        _session.Initialize();
        return new ActionResult("Success", 0);
    }
    return new ActionResult("Fail", 1);
}

private bool CheckUser(string userName, string password)
{
    var user = _userService.FindByName(userName);
    if (user != null)
    {
        var codedPharase = user.GetPhraseEncodedByPassword();
        var pharase = _cryptographer.Decrypt(codedPharase, password);
        if (pharase == "Valid")
            _session.Initialize();
    }
    return false;
}
```

### Output Arguments

In general output arguments should be avoided. If your function must change the state of something, have it change the state of its owning object.

```csharp
//Bad:
public void appendFooter(StringBuilder report)
//Good:
public void appendFooter(this StringBuilder report)
report.appendFooter();
```

### Command Query Separation

Functions should either do something or answer something, but not both. Either your function should change the state of an object, or it should return some information about that object. Doing both often leads to confusion.

Here is my first example from [EricBackhage.NET](https://ericbackhage.net/c/cleaner-code-with-command-query-separation/)

```csharp
//Bad:
private readonly object _lock = new();
private int _x;
public int IncrementAndGetValue()
{
    lock (_lock)
    {
        _x++;
        return _x;
    }
}
//Good:
private int _x;
public void Increment()
{
    _x++;
}
public int GetValue()
{
    return _x;
}
```

And here is my second example from [Mihai Sandu on Level Up Coding](https://levelup.gitconnected.com/how-to-improve-your-code-readability-with-cqs-b54b43ca9fa5)

```csharp
//Bad:
public class BadIceCream
{
    private int currentTemperature; //Celsius degrees
    private readonly List<int> temperatureReadings = new();

    public int SetTemperature(int temperature)
    {
        if (temperature > 10) temperature = 10;
        temperatureReadings.Add(currentTemperature);
        currentTemperature = temperature;
        return currentTemperature;
    }

    public List<int> GetTemperatureReadings()
    {
        temperatureReadings.Add(currentTemperature);
        if (currentTemperature > 10) Alert(currentTemperature);

        return temperatureReadings;
    }

    public void Alert(int temperature)
    {
        Console.WriteLine($"Ice Cream Machine too warm. Temperature: {temperature}");
    }
}
//Good:
public class GoodIceCream
{
    private int currentTemperature; //Celsius degrees
    private readonly List<int> temperatureReadings = new();

    public void SetTemperature(int temperature) // commands should return void
    {
        if (temperature > 10) temperature = 10;
        temperatureReadings.Add(currentTemperature);
        currentTemperature = temperature;
    }

    public int GetCurrentTemperature() //add a new method to return the current temperature
    {
        return currentTemperature;
    }

    public void StartMonitor()
    {
        //start an async job that will monitor the current temperature and send an alert
        if (currentTemperature > 10) Alert(currentTemperature);
    }

    public List<int> GetTemperatureReadings() //removed call to alert
    {
        temperatureReadings.Add(currentTemperature);
        return temperatureReadings;
    }

    public void Alert(int temperature)
    {
        Console.WriteLine($"Ice Cream Machine too warm. Temperature: {temperature}");
    }
}
```

### Prefer Exceptions to Returning Error Codes

Returning error codes from command functions is a subtle violation of command query separation.

Here is an example from [refactoring.guru](https://refactoring.guru/replace-error-code-with-exception)

```csharp
//Bad:
public int Withdraw(int amount)
{
    if (amount > _balance)
    {
        return -1;
    }

    _balance -= amount;
    return 0;
}
//Good:
public void Withdraw(int amount)
{
    if (amount > _balance) throw new BalanceException();
    _balance -= amount;
}
```

### Extract Try/Catch Blocks

`Try/catch` blocks are ugly in their own right. They confuse the structure of the code and mix error processing with normal processing. So it is better to extract the bodies of the `try` and `catch` blocks out into functions of their own.

And Exmple, Here is the book example in our C#/

```csharp
//Bad:
public void BadDeleteFunction(Page page)
{
    try
    {
        deletePage(page);
        _registery.DeleteReference(page.name);
        _congigService.DeleteKey(page.name.MakeKey());
    }
    catch (Exception e)
    {
        _logger.Log(e.Message);
    }
}
//Good:
public void GoodDeleteFunction(Page page)
{
    try
    {
        deletePageAndAllReferences(page);
    }
    catch (Exception e)
    {
        logError(e);
    }
}

private void deletePageAndAllReferences(Page page)
{
    deletePage(page);
    _registery.DeleteReference(page.name);
    _congigService.DeleteKey(page.name.MakeKey());
}

private void logError(Exception e)
{
    _logger.Log(e.Message);
}

```

### Error Handling Is One Thing

Functions should do one thing.

> Error handing is one thing.

Thus, a function that handles errors should do nothing else.

### Don't Repeat Yourself

Duplication may be the root of all evil in software. Many principles and practices have been created for the purpose of controlling or eliminating it.

### Structured Programming

Some programmers follow Edsger Dijkstra???s rules of structured programming. Dijkstra said that every function, and every block within a function, should have one entry and one exit. Following these rules means that there should only be one return statement in a function, no `break` or `continue` statements in a loop, and never, _ever_, any `goto` statements.

While we are sympathetic to the goals and disciplines of structured programming, those rules serve little benefit when functions are very small. It is only in larger functions that such rules provide significant benefit.

So if you keep your functions small, then the occasional multiple `return` , `break` , or `continue` statement does no harm and can sometimes even be more expressive than the single-entry, single-exit rule. On the other hand, `goto` only makes sense in large functions, so it should be avoided

<a name="chapter4">
<h1>Chapter 4 -  Comments</h1>
</a>

Nothing can be quite so helpful as a well-placed comment. Nothing can clutter up a module more than frivolous dogmatic comments. Nothing can be quite so damaging as an old comment that propagates lies and misinformation.

If our programming languages were expressive enough, or if we had the talent to subtly wield those languages to express our intent, we would not need comments very much???perhaps not at all.

### Comments Do Not Make Up for Bad Code

Clear and expressive code with few comments is far superior to cluttered and complex code with lots of comments. Rather than spend your time writing the comments that explain the mess you???ve made, spend it cleaning that mess.

### Explain Yourself in Code

```csharp
//Bad:
// Check to see if the employee is eligible for full benefits
if ((employee.flags & HOURLY_FLAG) && (employee.age > 65))
//Good:
if (employee.isEligibleForFullBenefits())
```

### Good Comments

Some comments are necessary or beneficial. However the only truly good comment is the comment you found a way not to write.

#### Legal Comments

Sometimes our corporate coding standards force us to write certain comments for legal reasons. For example, copyright and authorship statements are necessary and reasonable things to put into a comment at the start of each source file.

```csharp
//Good:
// Copyright (C) 2003,2004,2005 by Object Mentor, Inc. All rights reserved.
// Released under the terms of the GNU General Public License version 2 or later.
```

#### Informative Comments

It is sometimes useful to provide basic information with a comment. For example, consider this comment that explains the return value of an abstract method:

```csharp
//Bad:
// Returns an instance of the Responder being tested.
protected abstract Responder responderInstance();
//Good:
protected abstract Responder responderBeingTested();
```

A comment like this can sometimes be useful, but it is better to use the name of the function to convey the information where possible. For example, in this case the comment could be made redundant by renaming the function: `responderBeingTested`.

#### Explanation of Intent

Sometimes a comment goes beyond just useful information about the implementation and provides the intent behind a decision. Example:

```csharp
public int compareTo(object o)
{
    if (o.GetType() == typeof(WikiPagePath))
    {
        var p = (WikiPagePath)o;
        var compressedName = string.Join("", names);
        var compressedArgumentName = string.Join("", p.names);
        return compressedName.CompareTo(compressedArgumentName);
    }

    return 1; // we are greater because we are the right type.
}
```

#### Clarification

Sometimes it is just helpful to translate the meaning of some obscure argument or return value into something that's readable. In general it is better to find a way to make that argument or return value clear in its own right; but when its part of the standard library, or in code that you cannot alter, then a helpful clarifying comment can be useful.

```csharp
//Good:
public void testCompareTo()
{
    var a = PathParser.Parse("PageA");
    var ab = PathParser.Parse("PageA.PageB");
    var b = PathParser.Parse("PageB");
    var aa = PathParser.Parse("PageA.PageA");
    var bb = PathParser.Parse("PageB.PageB");
    var ba = PathParser.Parse("PageB.PageA");
    assertTrue(a.compareTo(a) == 0); // a == a
    assertTrue(a.compareTo(b) != 0); // a != b
    assertTrue(ab.compareTo(ab) == 0); // ab == ab
    assertTrue(a.compareTo(b) == -1); // a < b
    assertTrue(aa.compareTo(ab) == -1); // aa < ab
    assertTrue(ba.compareTo(bb) == -1); // ba < bb
    assertTrue(b.compareTo(a) == 1); // b > a
    assertTrue(ab.compareTo(aa) == 1); // ab > aa
    assertTrue(bb.compareTo(ba) == 1); // bb > ba
}
```

#### Warning of concequences

Sometimes it is useful to warn other programmers about certain consequences.

```csharp
//Good:
// Don't run unless you
// have some time to kill.
public void _testWithReallyBigFile()
{
    writeLinesToFile(10000000);
    string responseString = output.toString();
    assertSubString("Content-Length: 1000000000", responseString);
    assertTrue(bytesSent > 1000000000);
}
```

#### TODO Comments

It is sometimes reasonable to leave ???To do??? notes in the form of //TODO comments. In the
following case, the TODO comment explains why the function has a degenerate implementation and what that function's future should be.

```csharp
//Good:
//TODO-MdM these are not needed
// We expect this to go away when we do the checkout model
protected  VersionInfo makeVersion()
{
    return null;
}
```

TODOs are jobs that the programmer thinks should be done, but for some reason can???t do at the moment. It might be a reminder to delete a deprecated feature or a plea for someone else to look at a problem. It might be a request for someone else to think of a better name or a reminder to make a change that is dependent on a planned event. Whatever else a TODO might be, it is not an excuse to leave bad code in the system.

#### Amplification

A comment may be used to amplify the importance of something that may otherwise seem inconsequential.

```csharp
//Good:
string[] ExtractNameList(string s)
{
    // the trim is real important. It removes the starting
    // spaces that could cause the item to be recognized
    // as another name.
    return s.Trim().Split(' ');
}

```

#### Javadocs in Public APIs

There is nothing quite so helpful and satisfying as a well-described public API. The javadocs for the standard Java library are a case in point. It would be difficult, at best, to write Java programs without them.

### Bad Comments

Most comments fall into this category. Usually they are crutches or excuses for poor code or justifications for insufficient decisions, amounting to little more than the programmer talking to himself.

#### Mumbling

Plopping in a comment just because you feel you should or because the process requires it, is a hack. If you decide to write a comment, then spend the time necessary to make sure it is the best comment you can write. Example:

```csharp
//Bad:
public void loadProperties() {

  try {
    string propertiesPath = propertiesLocation + "/" + PROPERTIES_FILE;
    FileInputStream propertiesStream = new FileInputStream(propertiesPath);
    loadedProperties.load(propertiesStream);
  }
  catch(IOException e) {
    // No properties files means all defaults are loaded
  }
}
```

What does that comment in the catch block mean? Clearly meant something to the author, but the meaning not come though all that well. Apparently, if we get an `IOException`, it means that there was no properties file; and in that case all the defaults are loaded. But who loads all the defaults?

#### Redundant Comments

```csharp
//Bad:
private bool closed;
// Utility method that returns when this.closed is true. Throws an exception
// if the timeout is reached.
public void waitForClose(int timeoutMillis)
{
    if (!closed)
    {
        wait(timeoutMillis);
        if (!closed)
            throw new Exception("MockResponseSender could not be closed");
    }
}
private void wait(int timeoutMillis)
{
    Task.Delay(timeoutMillis);
}
```

What purpose does this comment serve? It???s certainly not more informative than the code. It does not justify the code, or provide intent or rationale. It is not easier to read than the code. Indeed, it is less precise than the code and entices the reader to accept that lack of precision in lieu of true understanding.

#### Misleading comments

Sometimes, with all the best intentions, a programmer makes a statement in his comments that isn't precise enough to be accurate. Consider for another moment the example of the previous section. The method does not return when `this.closed` becomes `true`. It returns if `this.closed` is `true`; otherwise, it waits for a blind time-out and then throws an exception if `this.closed` is still not true.

#### Mandated Comments

It is just plain silly to have a rule that says that every function must have a javadoc, or every variable must have a comment. Comments like this just clutter up the code, propagate lies, and lend to general confusion and disorganization.

```csharp
//Bad:
/// <summary>
///     Adding a new cd to cd list
/// </summary>
/// <param name="title">The title of the CD</param>
/// <param name="author">The author of the CD</param>
/// <param name="tracks">The number of tracks on the CD</param>
/// <param name="durationInMinutes">The duration of the CD in minutes</param>
public void addCD(string title, string author, int tracks, int durationInMinutes)
{
    var cd = new CD();
    cd.Title = title;
    cd.Author = author;
    cd.Tracks = tracks;
    cd.Duration = durationInMinutes;
    CDs.Add(cd);
}
```

#### Journal Comments

Sometimes people add a comment to the start of a module every time they edit it. Example:

```csharp
//Bad:
/* Changes (from 11-Oct-2001)
* --------------------------
* 11-Oct-2001 : Re-organised the class and moved it to new package com.jrefinery.date (DG);
* 05-Nov-2001 : Added a getDescription() method, and eliminated NotableDate class (DG);
* 12-Nov-2001 : IBD requires setDescription() method, now that NotableDate class is gone (DG); Changed getPreviousDayOfWeek(),
getFollowingDayOfWeek() and getNearestDayOfWeek() to correct bugs (DG);
* 05-Dec-2001 : Fixed bug in SpreadsheetDate class (DG);
*/
```

Today we have source code control systems, we don't need this type of logs.

#### Noise Comments

The comments in the follow examples doesn't provides new information.

```csharp
//Bad:
/**
* Default constructor.
*/
protected AnnualDateRule() {
}
```

```csharp
//Bad:
/** The day of the month. */
private int dayOfMonth;
```

Javadocs comments could enter in this category. Many times they are just redundant noisy comments written out of some misplaced desire to provide documentation.

#### Don???t Use a Comment When You Can Use a Function or a Variable

Example:

```java
//Bad:
// does the module from the global list <mod> depend on the
// subsystem we are part of?
if (smodule.getDependSubsystems().contains(subSysMod.getSubSystem()))
//Good:
ArrayList moduleDependees = smodule.getDependSubsystems();
String ourSubSystem = subSysMod.getSubSystem();
if (moduleDependees.contains(ourSubSystem))
```

#### Position Markers

This type of comments are noising

```csharp
//Bad:
// Actions //////////////////////////////////
```

#### Closing Brace Comments

Example:

```csharp
//Bad:
public static void main(string[] args)
{
    using var textReader = new StreamReader(path: "c:\\a.txt");
    string line;
    var lineCount = 0;
    var charCount = 0;
    var wordCount = 0;
    try
    {
        while ((line = textReader.ReadLine()) != null)
        {
            lineCount++;
            charCount += line.Length;
            var words = line.Split(" ");
            wordCount += words.Length;
        } //while

        Console.WriteLine("wordCount = " + wordCount);
        Console.WriteLine("lineCount = " + lineCount);
        Console.WriteLine("charCount = " + charCount);
    } // try
    catch (IOException e)
    {
        Console.WriteLine("Error:" + e.Message);
    } //catch
} //main
```

You could break the code in small functions instead to use this type of comments.

#### Attributions and Bylines

Example:

`/* Added by Rick */`

The VCS can manage this information instead.

#### Commented-Out Code

```csharp
//Bad:
InputStreamResponse response = new InputStreamResponse();
response.setBody(formatter.getResultStream(), formatter.getByteCount());
// InputStream resultsStream = formatter.getResultStream();
// StreamReader reader = new StreamReader(resultsStream);
// response.setContent(reader.read(formatter.getByteCount()));
```

If you don't need anymore, please delete it, you can back later with your VCS if you need it again.

#### HTML Comments

HTML in source code comments is an abomination, as you can tell by reading the code below.

```csharp
//Bad:
/**
* Task to run fit tests.
* This task runs fitnesse tests and publishes the results.
* <p/>
* <pre>
* Usage:
* &lt;taskdef name=&quot;execute-fitnesse-tests&quot;
* classname=&quot;fitnesse.ant.ExecuteFitnesseTestsTask&quot;
* classpathref=&quot;classpath&quot; /&gt;
* OR
* &lt;taskdef classpathref=&quot;classpath&quot;
* resource=&quot;tasks.properties&quot; /&gt;
* <p/>
* &lt;execute-fitnesse-tests
* suitepage=&quot;FitNesse.SuiteAcceptanceTests&quot;
* fitnesseport=&quot;8082&quot;
* resultsdir=&quot;${results.dir}&quot;
* resultshtmlpage=&quot;fit-results.html&quot;
* classpathref=&quot;classpath&quot; /&gt;
* </pre>
*/
```

#### Nonlocal Information

If you must write a comment, then make sure it describes the code it appears near. Don't offer systemwide information in the context of a local comment.

#### Too Much Information

Don't put interesting historical discussions or irrelevant descriptions of details into your comments.

```csharp
//Bad:
/*
 RFC 2045 - Multipurpose Internet Mail Extensions (MIME)
 Part One: Format of Internet Message Bodies
 section 6.8.  Base64 Content-Transfer-Encoding
 The encoding process represents 24-bit groups of input bits as output
 strings of 4 encoded characters. Proceeding from left to right, a
 24-bit input group is formed by concatenating 3 8-bit input groups.
 These 24 bits are then treated as 4 concatenated 6-bit groups, each
 of which is translated into a single digit in the base64 alphabet.
 When encoding a bit stream via the base64 encoding, the bit stream
 must be presumed to be ordered with the most-significant-bit first.
 That is, the first bit in the stream will be the high-order bit in
 the first 8-bit byte, and the eighth bit will be the low-order bit in
 the first 8-bit byte, and so on.
 */
```

#### Inobvious Connection

The connection between a comment and the code it describes should be obvious. If you are going to the trouble to write a comment, then at least you'd like the reader to be able to look at the comment and the code and understand what the comment is talking about.

```csharp
//Bad:
/*
* start with an array that is big enough to hold all the pixels
* (plus filter bytes), and an extra 200 bytes for header info
*/
this.pngBytes = new byte[((this.width + 1) * this.height * 3) + 200];
```

#### Function Headers

Short functions don???t need much description. A well-chosen name for a small function that does one thing is usually better than a comment header.

#### Javadocs in Nonpublic Code

Javadocs are for public APIs, in nonpublic code could be a distraction more than a help.

<a name="chapter5">
<h1>Chapter 5 -  Formatting</h1>
</a>

Code formatting is important. It is too important to ignore and it is too important to treat religiously. Code formatting is about communication, and communication is the professional developer???s first order of business.

### Vertical Formatting

#### Vertical Openness Between Concepts

This concept consist in how to you separate concepts in your code, In the next example we can appreciate it.

```csharp
//Bad:
public static class AutofacConfigurationExtensions
{
    public static void AddServices(this ContainerBuilder containerBuilder)
    {
        var applicationAssembly = typeof(LoginUserQuery).Assembly;
        var dataAssembly = typeof(UserRepos).Assembly;
        var modelAssembly = typeof(User).Assembly;
        containerBuilder.RegisterAssemblyTypes(dataAssembly, applicationAssembly, modelAssembly)
            .AssignableTo<IScopedDependency>().AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
        containerBuilder.RegisterAssemblyTypes(dataAssembly, applicationAssembly, modelAssembly)
            .AssignableTo<ITransientDependency>().AsImplementedInterfaces().AsSelf().InstancePerDependency();
        containerBuilder.RegisterAssemblyTypes(dataAssembly, applicationAssembly, modelAssembly)
            .AssignableTo<ISingletonDependency>().AsImplementedInterfaces().AsSelf().SingleInstance();
    }
    public static void AddMediator(this ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
        containerBuilder.Register<ServiceFactory>(context =>
        {
            var c = context.Resolve<IComponentContext>();
            return t => c.Resolve(t);
        });
        containerBuilder.RegisterAssemblyTypes(typeof(LoginUserQuery).GetTypeInfo().Assembly).AsImplementedInterfaces();
    }
}
//Good:
public static class AutofacConfigurationExtensions
{
    public static void AddServices(this ContainerBuilder containerBuilder)
    {
        var applicationAssembly = typeof(LoginUserQuery).Assembly;
        var dataAssembly = typeof(UserRepos).Assembly;
        var modelAssembly = typeof(User).Assembly;

        containerBuilder.RegisterAssemblyTypes(dataAssembly, applicationAssembly, modelAssembly)
            .AssignableTo<IScopedDependency>()
            .AsImplementedInterfaces()
            .AsSelf()
            .InstancePerLifetimeScope();

        containerBuilder.RegisterAssemblyTypes(dataAssembly, applicationAssembly, modelAssembly)
            .AssignableTo<ITransientDependency>()
            .AsImplementedInterfaces()
            .AsSelf()
            .InstancePerDependency();

        containerBuilder.RegisterAssemblyTypes(dataAssembly, applicationAssembly, modelAssembly)
            .AssignableTo<ISingletonDependency>()
            .AsImplementedInterfaces()
            .AsSelf()
            .SingleInstance();
    }

    public static void AddMediator(this ContainerBuilder containerBuilder)
    {
        containerBuilder
            .RegisterType<Mediator>()
            .As<IMediator>()
            .InstancePerLifetimeScope();

        containerBuilder.Register<ServiceFactory>(context =>
        {
            var c = context.Resolve<IComponentContext>();
            return t => c.Resolve(t);
        });

        containerBuilder
            .RegisterAssemblyTypes(typeof(LoginUserQuery).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();
    }
}
```

As you can see, the readability of the second example is greater than that of the second.

#### Vertical Density

The vertical density implies close association. So lines of code that are tightly related should appear vertically dense. Check the follow example:

```csharp
//Bad:
public class BadReporterConfig
{
    /**
     * The properties of the reporter listener
     */
    private readonly List<Property> m_properties = new();

    /**
     * The class name of the reporter listener
     */
    private string m_className;

    public void addProperty(Property property)
    {
        m_properties.Add(property);
    }
}
//Good:
public class GoodReporterConfig
{
    private string m_className;
    private readonly List<Property> m_properties = new();

    public void addProperty(Property property)
    {
        m_properties.Add(property);
    }
}
```

The second code it's much easier to read. It fits in an "eye-full".

#### Vertical Distance

**Variable Declarations**. Variables should be declared as close to their usage as possible. Because our functions are very short, local variables should appear at the top of each function.

```csharp
//Good:
public override async Task<CommandResult> Handle(AddScoreCommand request, CancellationToken cancellationToken)
{
    var entity = await _contentRepos.GetByIdAsync(cancellationToken, request.ContentId);
    if (entity == null)
    {
        AddMessage("Your request is invalid");
        return Result(ApiResultStatusCode.NotFound);
    }

    entity.AddScore(request.Score, request.UserClientId);

    var updateres = await _contentRepos.UpdateAsync(entity, cancellationToken);

    return Result(updateres ? ApiResultStatusCode.Success : ApiResultStatusCode.ErrorInDataUpdate);
}
```

Control variables for loops should usually be declared within the loop statement, as in this cute little function from the same source.

```csharp
//Good:
private void AddNodeToTree(List<ResourceAccessDTO> menu, ResourceAccessDTO menuitem)
{
    if (menuitem.ParentId == null)
    {
        menu.Add(menuitem);
        return;
    }
    foreach (var item in menu)
    {
        if (menuitem.ParentId == item.value)
        {
            item.children.Add(menuitem);
            item.collapsed = true;
            return;
        }
        else if (item.children.Any())
        {
            AddNodeToTree(item.children, menuitem);
        }
    }
}
```

**Instance variables**, on the other hand, should be declared at the top of the class. This should not increase the vertical distance of these variables, because in a well-designed class, they are used by many, if not all, of the methods of the class.

There have been many debates over where instance variables should go. In C++ we commonly practiced the so-called scissors rule, which put all the instance variables at the bottom. The common convention in Java, however, is to put them all at the top of the class. I see no reason to follow any other convention. The important thing is for the instance variables to be declared in one well-known place. Everybody should know where to go to see the declarations.

**Dependent Functions**. If one function calls another, they should be vertically close, and the caller should be above the callee, if at all possible. This gives the program a natural flow. If the convention is followed reliably, readers will be able to trust that function definitions will follow shortly after their use.

```csharp
public class AppDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly IMediator _mediator;

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor, IMediator mediator) :
        base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        _mediator = mediator;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        handleAuditables();

        handleTrackDelete();

        await dispachEvents();

        return await base.SaveChangesAsync(true, cancellationToken);
    }

    private void handleAuditables()
    {
        foreach (var auditableEntity in ChangeTracker.Entries<IAuditable>())
        {
            if (auditableEntity.State == EntityState.Added || auditableEntity.State == EntityState.Modified)
            {
                auditableEntity.Property("UpdateTime").CurrentValue = DateTime.Now;

                if (auditableEntity.State == EntityState.Added)
                    auditableEntity.Property("InsertTime").CurrentValue = DateTime.Now;
            }

            if (auditableEntity.State == EntityState.Deleted)
            {
                auditableEntity.State = EntityState.Modified;
                auditableEntity.Property("IsRemoved").CurrentValue = true;
                auditableEntity.Property("DeleteTime").CurrentValue = DateTime.Now;
            }

            auditableEntity.Property("applicatorId").CurrentValue = GetUserId();
        }
    }

    private Guid GetUserId()
    {
        var userId = Guid.Empty;
        Guid.TryParse(_httpContextAccessor.HttpContext?.Items["UserId"]?.ToString(), out userId);
        return userId;
    }

    private void handleTrackDelete()
    {
        foreach (var trackingdelete in ChangeTracker
                     .Entries<ITrackDelete>()
                     .Where(e => e.State == EntityState.Deleted))
            trackingdelete.Entity.CallDeleteEvent();
    }

    private async Task dispachEvents()
    {
        if (_mediator == null) return;

        var changedAggregates =
            ChangeTracker.Entries<IHasEvent>()
                .Select(c => c.Entity)
                .Where(c => c.GetEvents().Any())
                .ToList();

        if (!changedAggregates.Any()) return;

        foreach (var aggregate in changedAggregates)
        {
            var events = aggregate.GetEvents();
            foreach (var @event in events.Where(e => !e.IsPublish()))
            {
                await _mediator.Publish(new OutboxMessageCreated(@event));
                @event.SetAsPublished();
            }

            aggregate.RemovePublishedEvents();
        }
    }
}
```

**Conceptual Affinity**. Certain bits of code want to be near other bits. They have a certain conceptual affinity. The stronger that affinity, the less vertical distance there should be between them.

```csharp
public class ApiResult
{
    private readonly bool _isSuccess;
    private string _message;

    public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, string message = null)
    {
        _isSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message ?? statusCode.ToDisplay();
    }

    public bool IsSuccess => _isSuccess && StatusCode == ApiResultStatusCode.Success;

    public ApiResultStatusCode StatusCode { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }

    #region Implicit Operators

    public static implicit operator ApiResult(OkResult result)
    {
        return new ApiResult(true, ApiResultStatusCode.Success);
    }

    public static implicit operator ApiResult(BadRequestResult result)
    {
        return new ApiResult(false, ApiResultStatusCode.BadRequest);
    }

    public static implicit operator ApiResult(BadRequestObjectResult result)
    {
        var message = result.Value.ToString();
        if (result.Value is SerializableError errors)
        {
            var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
            message = string.Join(" | ", errorMessages);
        }

        return new ApiResult(false, ApiResultStatusCode.BadRequest, message);
    }

    public static implicit operator ApiResult(ContentResult result)
    {
        return new ApiResult(true, ApiResultStatusCode.Success, result.Content);
    }

    public static implicit operator ApiResult(NotFoundResult result)
    {
        return new ApiResult(false, ApiResultStatusCode.NotFound);
    }

    public static implicit operator ApiResult(UnauthorizedResult result)
    {
        return new ApiResult(false, ApiResultStatusCode.UnAuthorized);
    }

    public static implicit operator ApiResult(CommandResult result)
    {
        return new ApiResult(result.IsSuccess, result.Status, result.GetMessage());
    }

    #endregion
}
```

#### Vertical Ordering

In general we want function call dependencies to point in the downward direction. That is, a function that is called should be below a function that does the calling. This creates a nice flow down the source code module from high level to low level. _(This is the exact opposite of languages like Pascal, C, and C++ that enforce functions to be defined, or at least declared, before they are used)_

### Horizontal Formatting

#### Horizontal Openness and Density

We use horizontal white space to associate things that are strongly related and disassociate things that are more weakly related. Example:

```csharp
private void measureLine(String line) {
  lineCount++;
  int lineSize = line.length();
  totalChars += lineSize;
  lineWidthHistogram.addLine(lineSize, lineCount);
  recordWidestLine(lineSize);
}
```

Assignment statements have two distinct and major elements: the left side and the right side. The spaces make that separation obvious.

#### Horizontal Alignment

```csharp
public class Example implements Base
{
  private   Socket      socket;
  private   inputStream input;
  protected long        requestProgress;

  public Expediter(Socket      s,
                   inputStream input) {
    this.socket =     s;
    this.input  =     input;
  }
}
```

In modern languages this type of alignment is not useful. The alignment seems to emphasize the wrong things and leads my eye away from the true intent.

```csharp
public class Example implements Base
{
  private Socket socket;
  private inputStream input;
  protected longrequestProgress;

  public Expediter(Socket s, inputStream input) {

    this.socket = s;
    this.input = input;
  }
}
```

This is a better approach.

### Indentation

The indentation it's important because help us to have a visible hierarchy and well defined blocks.

### Team Rules

Every programmer has his own favorite formatting rules, but if he works in a team, then the team rules.

A team of developers should agree upon a single formatting style, and then every member of that team should use that style. We want the software to have a consistent style. We don't want it to appear to have been written by a bunch of disagreeing individuals.

<a name="chapter6">
<h1>Chapter 6 -  Objects and Data Structures</h1>
</a>

### Data Abstraction

Hiding implementation is not just a matter of putting a layer of functions between the variables. Hiding implementation is about abstractions! A class does not simply push its variables out through getters and setters. Rather it exposes abstract interfaces that allow its users to manipulate the essence of the data, without having to know its implementation.

### Data/Object Anti-Symmetry

These two examples show the difference between objects and data structures. Objects hide their data behind abstractions and expose functions that operate on that data. Data structure expose their data and have no meaningful functions.

**Procedural Shape**

```csharp
public class Square
{
    public double side;
    public Point topLeft;
}

public class Rectangle
{
    public double height;
    public Point topLeft;
    public double width;
}

public class Circle
{
    public Point center;
    public double radius;
}

public class Geometry
{
    public const double PI = 3.141592653589793;

    public double area(object shape)
    {
        if (shape is Square square) return square.side * square.side;

        if (shape is Rectangle rectangle) return rectangle.height * rectangle.width;

        if (shape is Circle circle) return PI * circle.radius * circle.radius;

        throw new NoSuchShapeException();
    }
}

public class NoSuchShapeException : Exception
{
}
```

**Polymorphic Shape**

```csharp
public class Shape
{
}

public class Square : Shape
{
    private double side;
    private Point topLeft;

    public double area()
    {
        return side * side;
    }
}

public class Rectangle : Shape
{
    private double height;
    private Point topLeft;
    private double width;

    public double area()
    {
        return height * width;
    }
}

public class Circle : Shape
{
    public const double PI = 3.141592653589793;
    private Point center;
    private double radius;

    public double area()
    {
        return PI * radius * radius;
    }
}
```

Again, we see the complimentary nature of these two definitions; they are virtual opposites! This exposes the fundamental dichotomy between objects and data structures:

> Procedural code (code using data structures) makes it easy to add new functions without changing the existing data structures. OO code, on the other hand, makes it easy to add new classes without changing existing functions.

The complement is also true:

> Procedural code makes it hard to add new data structures because all the functions must change. OO code makes it hard to add new functions because all the classes must change.

Mature programmers know that the idea that everything is an object is a myth. Sometimes you really do want simple data structures with procedures operating on them.

### The Law of [Demeter](https://en.wikipedia.org/wiki/Law_of_Demeter)

There is a well-known heuristic called the Law of Demeter that says a module should not know about the innards of the objects it manipulates.

More precisely, the Law of Demeter says that a method `f` of a class `C` should only call the methods of these:

- `C`
- An object created by `f`
- An object passed as an argument to `f`
- An object held in an instance variable of `C`

The method should not invoke methods on objects that are returned by any of the allowed functions. In other words, talk to friends, not to strangers.

Here is an example from [CODING JOURNEYMAN](https://codingjourneyman.com/2015/03/30/the-law-of-demeter/)

```csharp
//Bad:
public class Wallet
{
    public float Value { get; set; }

    public void AddMoney(float amount)
    {
        Value += amount;
    }

    public void SubMoney(float amount)
    {
        Value -= amount;
    }
}

public class Customer
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Wallet Wallet { get; set; }
}

public class Paperboy
{
    public void SellPaper(Customer customer)
    {
        var payment = 2.0f;
        //Here we break Demeter's Law
        var wallet = customer.Wallet;
        if (wallet.Value >= payment) wallet.SubMoney(payment);
    }
}
//Good:
public class Wallet
{
    public Wallet(float initialAmount)
    {
        Value = initialAmount;
    }

    public float Value { get; private set; }

    public void AddMoney(float amount)
    {
        Value += amount;
    }

    public void SubMoney(float amount)
    {
        Value -= amount;
    }
}

public class Customer
{
    private readonly Wallet _wallet;

    public Customer()
    {
        FirstName = "John";
        LastName = "Doe";
        _wallet = new Wallet(20.0f); // amount set to 20 for example
    }

    public string FirstName { get; }

    public string LastName { get; }

    public float PayAmount(float amountToPay)
    {
        if (_wallet.Value >= amountToPay)
        {
            _wallet.SubMoney(amountToPay);
            return amountToPay;
        }

        return 0;
    }
}

public class Paperboy
{
    public void SellPaper(Customer customer)
    {
        var payment = 2.0f;
        var amountPaid = customer.PayAmount(payment);
        if (amountPaid != payment)
        {
            // come back later
        }
    }
}
```

### Data Transfer Objects

The quintessential form of a data structure is a class with public variables and no functions. This is sometimes called a data transfer object, or DTO. DTOs are very useful structures, especially when communicating with databases or parsing messages from sockets, and so on. They often become the first in a series of translation stages that convert raw data in a database into objects in the application code.

<a name="chapter7">
<h1>Chapter 7 -  Error Handling</h1>
</a>

Many code bases are completely dominated by error handling. When I say dominated, I don't mean that error handling is all that they do. I mean that it is nearly impossible to see what the code does because of all of the scattered error handling. Error handling is important, but if it obscures logic, it's wrong.

### Use Exceptions Rather Than Return Codes

Back in the distant past there were many languages that didn't have exceptions. In those languages the techniques for handling and reporting errors were limited. You either set an error flag or returned an error code that the caller could check.

```csharp
//Bad:
public int Withdraw(int amount)
{
    if (amount > _balance)
    {
        return -1;
    }

    _balance -= amount;
    return 0;
}
//Good:
public void Withdraw(int amount)
{
    if (amount > _balance) throw new BalanceException();
    _balance -= amount;
}
```

### Write Your Try-Catch-Finally Statement First

In a way, try blocks are like transactions. Your catch has to leave your program in a consistent state, no matter what happens in the try. For this reason it is good practice to start with a try-catch-finally statement when you are writing code that could throw exceptions. This helps you define what the user of that code should expect, no matter what goes wrong with the code that is executed in the try.

```csharp
//Good:
public class UnitTest1
{
    [Fact]
    public void retrieveSectionShouldThrowOnInvalidFileName()
    {
        Action act = () => retrieveSection("invalid - file");
        var exception = Assert.Throws<StorageException>(act);
        Assert.Equal("retrieval error", exception.Message);
    }

    public List<RecordedGrip> retrieveSection(string sectionName)
    {
        try
        {
            StreamReader stream = new(sectionName);
            stream.Close();
        }
        catch (FileNotFoundException e)
        {
            throw new StorageException("retrieval error");
        }

        return new List<RecordedGrip>();
    }
}

public class StorageException : Exception
{
    public StorageException(string s) : base(s)
    {
    }
}
```

### Provide Context with Exceptions

Each exception that you throw should provide enough context to determine the source and location of an error.

Create informative error messages and pass them along with your exceptions. Mention the operation that failed and the type of failure. If you are logging in your application, pass along enough information to be able to log the error in your catch.

```csharp
//Bad:
public class Bad
{
    public double Divide(double numerator, double denominator)
    {
        if (denominator == 0)
            throw new Exception("divide by zero");

        return numerator / denominator;
    }
}
//Good:
public class Good
{
    public double Divide(double numerator, double denominator)
    {
        if (denominator == 0) ThrowInformativeException(numerator, denominator);

        return numerator / denominator;
    }

    private static void ThrowInformativeException(double numerator, double denominator)
    {
        throw new Exception(JsonConvert.SerializeObject(new
        {
            Message = "divide by zero",
            Method = "Divide",
            Class = "Good",
            numerator,
            denominator
        }));
    }
}
```

### De???ne Exception Classes in Terms of a Caller???s Needs

There are many ways to classify errors. We can classify them by their source: Did they come from one component or another? Or their type: Are they device failures, network failures, or programming errors? However, when we de???ne exception classes in an application, our most important concern should be how
they are caught.

```csharp
//Bad:
var port = new ACMEPort(12);
try
{
    port.open();
}
catch (DeviceResponseException e)
{
    reportPortError(e);
    _logger.Log("Device response exception", e);
}
catch (ATM1212UnlockedException e)
{
    reportPortError(e);
    _logger.Log("Unlock exception", e);
}
catch (GMXError e)
{
    reportPortError(e);
    _logger.Log("Device response exception");
}
finally
{
    _logger.Log("finally section");
}
//Good:
var port = new LocalPort(12);
try
{
    port.open();
}
catch (PortDeviceFailure e)
{
    reportError(e);
    _logger.Log(e.getMessage(), e);
}
finally
{
    _logger.Log("finally section");
}

public class LocalPort
{
    private readonly ACMEPort innerPort;

    public LocalPort(int portNumber)
    {
        innerPort = new ACMEPort(portNumber);
    }

    public void open()
    {
        try
        {
            innerPort.open();
        }
        catch (DeviceResponseException e)
        {
            throw new PortDeviceFailure(e);
        }
        catch (ATM1212UnlockedException e)
        {
            throw new PortDeviceFailure(e);
        }
        catch (GMXError e)
        {
            throw new PortDeviceFailure(e);
        }
    }
}
```

### Don't Return Null

If you are tempted to return null from a method, consider throwing an exception or returning a SPECIAL CASE object instead. If you are calling a null-returning method from a third-party API, consider wrapping that method with a method that either throws an exception or returns a special case object.

```csharp
//Bad:
public class Bad
{
    private decimal totalPay;

    public void run()
    {
        var employees = getEmployees();
        if (employees != null)
            foreach (var e in employees)
                totalPay += e.getPay();
    }

    private List<Employee> getEmployees()
    {
        if (DateTime.Now.Second % 2 == 0)
            return new List<Employee>
            {
                new(),
                new()
            };
        return null;
    }
}
//Good:
public class Good
{
    private decimal totalPay;

    public void run()
    {
        totalPay = getEmployees().Sum(e => e.getPay());
    }

    private List<Employee> getEmployees()
    {
        if (DateTime.Now.Second % 2 == 0)
            return new List<Employee>
            {
                new(),
                new()
            };
        return new List<Employee>();
    }
}
```

### Don't Pass Null

Returning null from methods is bad, but passing null into methods is worse. Unless you are working with an API which expects you to pass null, you should avoid passing null in your code whenever possible.

<a name="chapter8">
<h1>Chapter 8 -  Boundaries</h1>
</a>

We seldom control all the software in our systems. Sometimes we buy third-party pack- ages or use open source. Other times we depend on teams in our own company to produce components or subsystems for us. Somehow we must cleanly integrate this foreign code with our own.

### Using Third-Party Code

There is a natural tension between the provider of an interface and the user of an interface. Providers of third-party packages and frameworks strive for broad applicability so they can work in many environments and appeal to a wide audience. Users, on the other hand, want an interface that is focused on their particular needs. This tension can cause problems at the boundaries of our systems. Example:

```csharp
//Bad:
Map sensors = new HashMap();
Sensor s = (Sensor)sensors.get(sensorId);
//Good:
public class Sensors {
  private Map sensors = new HashMap();

  public Sensor getById(String id) {
    return (Sensor) sensors.get(id);
  }
}
```

The first code exposes the casting in the Map, while the second is able to evolve with very little impact on the rest of the application. The casting and type management is handled inside the Sensors class.

The interface is also tailored and constrained to meet the needs of the application. It results in code that is easier to understand and harder to misuse. The Sensors class can enforce design and business rules.

### Exploring and Learning Boundaries

Third-party code helps us get more functionality delivered in less time. Where do we start when we want to utilize some third-party package? It???s not our job to test the third-party code, but it may be in our best interest to write tests for the third-party code we use.

It's a good idea write some test for learn and understand how to use a third-party code. Newkirk calls such tests learning tests.

### Learning Tests Are Better Than Free

The learning tests end up costing nothing. We had to learn the API anyway, and writing those tests was an easy and isolated way to get that knowledge. The learning tests were precise experiments that helped increase our understanding.

Not only are learning tests free, they have a positive return on investment. When there are new releases of the third-party package, we run the learning tests to see whether there are behavioral differences.

### Using Code That Does Not Yet Exist

Some times it's necessary work in a module that will be connected to another module under develop, and we have no idea about how to send the information, because the API had not been designed yet. In this cases it's recommendable create an interface for encapsulate the communication with the pending module. In this way we maintain the control over our module and we can test although the second module isn't available yet.

### Clean Boundaries

Interesting things happen at boundaries. Change is one of those things. Good software designs accommodate change without huge investments and rework. When we use code that is out of our control, special care must be taken to protect our investment and make sure future change is not too costly.

<a name="chapter9">
<h1>Chapter 9 -  Unit Tests</h1>
</a>

**T**est
**D**riven
**D**evelopment

### The Three Laws of TDD

- **First Law** You may not write production code until you have written a failing unit test.
- **Second Law** You may not write more of a unit tests than is sufficient to fail, and not comipling is failing.
- **Third Law** You may not write more production code than is sufficient to pass the currently failing tests.

### Clean Tests

If you don't keep your tests clean, you will lose them.

The readability it's very important to keep clean your tests.

### One Assert per test

It's recomendable maintain only one asserts per tests, because this helps to maintain each tests easy to understand.

### Single concept per Test

This rule will help you to keep short functions.

- **Write one test per each concept that you need to verify**

### F.I.R.S.T

- **Fast** Test should be fast.
- **Independient** Test should not depend on each other.
- **Repeatable** Test Should be repeatable in any environment.
- **Self-Validating** Test should have a boolean output. either they pass or fail.
- **Timely** Unit tests should be written just before the production code that makes them pass. If you write tests after the production code, then you may find the production code to be hard to test.

<a name="chapter10">
<h1>Chapter 10 -  Classes</h1>
</a>

## Class Organization

### Encapsulation

We like to keep our variables and utility functions small, but we're not fanatic about it. Sometimes we need to make a variable or utility function protected so that it can be accessed by a test.

## Classes Should be Small

- First Rule: Classes should be small
- Second Rule: **Classes should be smaller than the first rule**

### The Single Responsibility Principle

**Classes should have one responsibility - one reason to change**

SRP is one of the more important concept in OO design. It's also one of the simple concepts to understand and adhere to.

### Cohesion

Classes Should have a small number of instance variables. Each of the methods of a class should manipulate one or more of those variables. In general the more variables a method manipulates the more cohesive that method is to its class. A class in which each variable is used by each method is maximally cohesive.

### Maintaining Cohesion Results in Many Small Classes

Just the act of breaking large functions into smaller functions causes a proliferation of classes.

## Organizing for change

For most systems, change is continual. Every change subjects us to the risk that the remainder of the system no longer works as intended. In a clean system we organize our classes so as to reduce the risk of change.

### Isolating from Change

Needs will change, therefore code will change. We learned in OO 101 that there are concrete classes, which contain implementation details (code), and abstract classes, which represent concepts only. A client class depending upon concrete details is at risk when those details change. We can introduce intefaces and abstract classes to help isolate the impact of those details.

<a name="chapter11">
<h1>Chapter 11 -  Systems</h1>
</a>

## Separe Constructing a System from using It

_Software Systems should separate the startuo process, when the application objects are constructed and the dependencies are "wired" thogether, from the runtime logic that takes over after startup_

### Separation from main

One way to separate construction from use is simply to move all aspects of construction to `main`, or modules called by `main`, and to design the rest of the system assuming that all objects have been created constructed and wired up appropriately.

The Abstract Factory Pattern is an option for this kind of approach.

### Dependency Injection

A powerful mechanism for separating construction from use is Dependency Injection (DI), the application of Inversion of control (IoC) to dependency management. Inversion of control moves secondary responsibilities from an object to other objects that are dedicated to the purpose, thereby supporting the Single Responsibility Principle. In context of dependency management, an object should not take responsibility for instantiating dependencies itself. Instead, it, should pass this responsibility to another "authoritative" mechanism, thereby inverting the control. Because setup is a global concern, this authoritative mechanism will usually be either the "main"
routine or a special-purpose _container_.

<a name="chapter12">
<h1>Chapter 12 -  Emergence</h1>
</a>

According to Kent Beck, a design is "simple" if it follows these rules

- Run all tests
- Contains no duplication
- Expresses the intent of programmers
- Minimizes the number of classes and methods

<a name="chapter13">
<h1>Chapter 13 -  Concurrency</h1>
</a>

Concurrence is a decoupling strategy. It helps us decouple what gets fone from when it gets done. In single-threaded applications what and when are so strongly coupled that the state of the entire application can often be determined by looking at the stack backtrace. A programmer who debugs such a system can set a breakpoint, or a sequence of breakpoints, and know the state of the system by which breakpoints are hit.

Decoupling what from when can dramatically improve both the throughput and structures of an application. From a structural point of view the application looks like many lit- tle collaborating computers rather than one big main loop. This can make the system easier to understand and offers some powerful ways to separate concerns.

## Miths and Misconceptions

- Concurrency always improves performance.
  Concurrency can sometimes improve performance, but only when there is a lot of wait time that can be shared between multiple threads or multiple processors. Neither situ- ation is trivial.
- Design does not change when writing concurrent programs.
  In fact, the design of a concurrent algorithm can be remarkably different from the design of a single-threaded system. The decoupling of what from when usually has a huge effect on the structure of the system.
- Understanding concurrency issues is not important when working with a container such as a Web or EJB container.
  In fact, you???d better know just what your container is doing and how to guard against the issues of concurrent update and deadlock described later in this chapter.
  Here are a few more balanced sound bites regarding writing concurrent software:
- Concurrency incurs some overhead, both in performance as well as writing additional code.
- Correct concurrency is complex, even for simple problems.
- Concurrency bugs aren???t usually repeatable, so they are often ignored as one-offs instead of the true defects they are.
- Concurrency often requires a fundamental change in design strategy.

#

<a name="chapter14">
<h1>Chapter 14 -  Successive Refinement</h1>
</a>
This chapter is a study case. It's recommendable to completely read it to understand more.

<a name="chapter15">
<h1>Chapter 15 -  JUnit Internals</h1>
</a>
This chapter analize the JUnit tool. It's recommendable to completely read it to understand more.

<a name="chapter16">
<h1>Chapter 16 -  Refactoring SerialDate</h1>
</a>
This chapter is a study case. It's recommendable to completely read it to understand more.

<a name="chapter17">
<h1>Chapter 17 -  Smells and Heuristics</h1>
</a>

A reference of code smells from Martin Fowler's _Refactoring_ and Robert C Martin's _Clean Code_.

While clean code comes from discipline and not a list or value system, here is a starting point.

## Comments

#### C1: Inappropriate Information

Reserve comments for technical notes referring to code and design.

#### C2: Obsolete Comment

Update or delete obsolete comments.

#### C3: Redundant Comment

A redundant comment describes something able to sufficiently describe itself.

#### C4: Poorly Written Comment

Comments should be brief, concise, correctly spelled.

#### C5: Commented-Out Code

Ghost code. Delete it.

## Environment

#### E1: Build Requires More Than One Step

Builds should require one command to check out and one command to run.

#### E2: Tests Require More Than One Step

Tests should be run with one button click through an IDE, or else with one command.

## Functions

#### F1: Too Many Arguments

Functions should have no arguments, then one, then two, then three. No more than three.

#### F2: Output Arguments

Arguments are inputs, not outputs. If somethings state must be changed, let it be the state of the called object.

#### F3: Flag Arguments

Eliminate boolean arguments.

#### F4: Dead Function

Discard uncalled methods. This is dead code.

## General

#### G1: Multiple Languages in One Source File

Minimize the number of languages in a source file. Ideally, only one.

#### G2: Obvious Behavior is Unimplemented

The result of a function or class should not be a surprise.

#### G3: Incorrect Behavior at the Boundaries

Write tests for every boundary condition.

#### G4: Overridden Safeties

Overriding safeties and exerting manual control leads to code melt down.

#### G5: Duplication

Practice abstraction on duplicate code. Replace repetitive functions with polymorphism.

#### G6: Code at Wrong Level of Abstraction

Make sure abstracted code is separated into different containers.

#### G7: Base Classes Depending on Their Derivatives

Practice modularity.

#### G8: Too Much Information

Do a lot with a little. Limit the amount of _things_ going on in a class or functions.

#### G9: Dead Code

Delete unexecuted code.

#### G10: Vertical Separation

Define variables and functions close to where they are called.

#### G11: Inconsistency

Choose a convention, and follow it. Remember no surprises.

#### G12: Clutter

Dead code.

#### G13: Artificial Coupling

Favor code that is clear, rather than convenient. Do not group code that favors mental mapping over clearness.

#### G14: Feature Envy

Methods of one class should not be interested with the methods of another class.

#### G15: Selector Arguments

Do not flaunt false arguments at the end of functions.

#### G16: Obscured Intent

Code should not be magic or obscure.

#### G17: Misplaced Responsibility

Use clear function name as waypoints for where to place your code.

#### G18: Inappropriate Static

Make your functions nonstatic.

#### G19: Use Explanatory Variables

Make explanatory variables, and lots of them.

#### G20: Function Names Should Say What They Do

...

#### G21: Understand the Algorithm

Understand how a function works. Passing tests is not enough. Refactoring a function can lead to a better understanding of it.

#### G22: Make Logical Dependencies Physical

Understand what your code is doing.

#### G23: Prefer Polymorphism to If/Else or Switch/Case

Avoid the brute force of switch/case.

#### G24: Follow Standard Conventions

It doesn't matter what your teams convention is. Just that you have on and everyone follows it.

#### G25: Replace Magic Numbers with Named Constants

Stop spelling out numbers.

#### G26: Be Precise

Don't be lazy. Think of possible results, then cover and test them.

#### G27: Structure Over Convention

Design decisions should have a structure rather than a dogma.

#### G28: Encapsulate Conditionals

Make your conditionals more precise.

#### G29: Avoid Negative Conditionals

Negative conditionals take more brain power to understand than a positive.

#### G31: Hidden Temporal Couplings

Use arguents that make temporal coupling explicit.

#### G32: Don???t Be Arbitrary

Your code's sturcture should communicate the reason for its structure.

#### G33: Encapsulate Boundary Conditions

Avoid leaking +1's and -1's into your code.

#### G34: Functions Should Descend Only One Level of Abstraction

The toughest heuristic to follow. One level of abstraction below the function's described operation can help clarify your code.

#### G35: Keep Configurable Data at High Levels

High level constants are easy to change.

#### G36: Avoid Transitive Navigation

Write shy code. Modules should only know about their neighbors, not their neighbor's neighbors.

## Names

#### N1: Choose Descriptive Names

Choose names that are descriptive and relevant.

#### N2: Choose Names at the Appropriate Level of Abstraction

Think of names that are still clear to the user when used in different programs.

#### N3: Use Standard Nomenclature Where Possible

Use names that express their task.

#### N4: Unambiguous Names

Favor clearness over curtness. A long, expressive name is better than a short, dull one.

#### N5: Use Long Names for Long Scopes

A name's length should relate to its scope.

#### N6: Avoid Encodings

No not encode names with type or scope information.

#### N7: Names Should Describe Side-Effects

Consider the side-effects of your function, and include that in its name.

## Tests

#### T1: Insufficient Tests

Test everything that can possibly break

#### T2: Use a Coverage Tool!

Use your IDE as a coverage tool.

#### T3: Don???t Skip Trivial Tests

...

#### T4: An Ignored Test is a Question about an Ambiguity

If your test is ignored, the code is brought into question.

#### T5: Test Boundary Conditions

The middle is usually covered. Remember the boundaries.

#### T6: Exhaustively Test Near Bugs

Bugs are rarely alone. When you find one, look nearby for another.

#### T7: Patterns of Failure Are Revealing

Test cases ordered well will reveal patterns of faiure.

#### T8: Test Coverage Patterns Can Be Revealing

Similarly, look at the code that is or is not passed in a failure.

#### T9: Tests Should Be Fast

Slow tests won't get run.
