构造函数·默认值
public MyClass(int x):this(x, "Using Default String")
{
...	Keyword
}

抽象类
using System;

abstract class AbClass                       // 抽象类
{
   public void IdentifyBase()                // Normal method
   {
      Console.WriteLine( "I am AbClass" );
   }

   abstract public void IdentifyDerived();   // Abstract 抽象method
}

class DerivedClass : AbClass                 // Derived class
{
   override public void IdentifyDerived()    // 抽象方法的实现
   {
      Console.WriteLine( "I am DerivedClass" );
   }
}

class Program
{
   static void Main()
   {
      // AbClass a = new AbClass(); // 错误。无法实例化抽象类
      // a.IdentifyDerived(); // an abstract class.

      DerivedClass b = new DerivedClass();   // Instantiate the derived class.
      b.IdentifyBase();                      // Call the inherited method.
      b.IdentifyDerived();                   // Call the "abstract" method.
   }
}

扩展类·扩展方法·无法调用继承·所以进行扩展
using System;

class MyData
{
   private double D1;                                 // Fields
   private double D2;
   private double D3;

   public MyData( double d1, double d2, double d3 )   // Constructor
   {
      D1 = d1;
      D2 = d2;
      D3 = d3;
   }

   public double Sum()                                // Method Sum
   {
      return D1 + D2 + D3;
   }
}

static class ExtendMyData
{
   public static double Average( MyData md )//MyData类的实例作为形参
   {
      return md.Sum() / 3;
   }
}

class Program
{
   static void Main()
   {
      MyData md = new MyData( 3, 4, 5 );
      Console.WriteLine( "Average: {0}", ExtendMyData.Average( md ) );
   }
}

代码：
Average: 4


2·扩展方法的重要要求如下： 
• 在其中声明扩展方法的类必须声明为	静态。
• 扩展方法	本身必须声明为				静态。
• 扩展方法必须包含			      this 关键字 作为第一个参数类型，
后面紧跟要扩展的类的名称（就是所扩展的类名字（实例））。
扩展类·静态类·静态方法·this作为首参，可以使用实例变相访问静态方法，实例名字.静态方法

using System;

namespace ExtensionMethods
{
   sealed class MyData
   {
      private double D1, D2, D3;
      public MyData( double d1, double d2, double d3 )
      {
         D1 = d1; D2 = d2; D3 = d3;
      }
      public double Sum() { return D1 + D2 + D3; }
   }

   static class ExtendMyData//扩展类·静态类·静态方法·this作为首参
   {
      public static double Average( this MyData md )
      {
         return md.Sum() / 3;
      }
   }

   class Program
   {
      static void Main()
      {
         MyData md = new MyData( 3, 4, 5 );
         Console.WriteLine( $"Sum:     { md.Sum() }" );
         Console.WriteLine( "Average: {0}", md.Average() );//实例名字.静态方法
		 //实例变相访问静态方法
      }
   }
}

Pascal 	 首字母大写
Camel 	 首字母小写
_Camel 	_ 首字母小写

236UL 	无符号 长整

@——---两个双引号表示一个双引号
逐字字符串字面量
@“（""  ""）”

#转换运算符的声明示例，该声明将 LimitedInt 类型的对象转换为 int，反之亦然：
#用户定义类型的转换--implicit-explicit-不需要强转的 => （）
class LimitedInt
{
    const int MaxValue = 100;//const类似静态成员；在字段参与计算之前就是已经加载
    const int MinValue = 0;

    public static implicit operator int(LimitedInt li)
    // implicit operator == 函数名字
    //int(LimitedInt li)  == 参数；
    {
        return li.TheValue;
    }

    public static implicit operator LimitedInt(int x)
    // implicit operator  == 函数名字
    //LimitedInt(int x)   == 参数；
    {
        LimitedInt li = new LimitedInt()
        {
            TheValue = x
        };
        return li;
    }

    private int _theValue;//默认值本就是0；但是添加0之后，就是可以在const函数-静态成员加载后   加载此字段
                          //private int _theValue ;//默认值本就是0
    public int TheValue
    { // Property
        get { return _theValue; }
        set
        {
            if (value < MinValue)
                _theValue = 0;
            else
                _theValue = value > MaxValue ? MaxValue : value;
        }
    }
}

class Program
{
    static void Main()                                       // Main
    {
        LimitedInt li = new LimitedInt();
        li = 500;//500 》100 ？ 100:500；所以数值是100； //  500 转换为 LimitedInt
                 //LimitedInt li = 500 ；//·······简写 上一行代码       

        int value = li;   //  实际上是属性的运算····LimitedInt 转换为 int——— 
        Console.WriteLine($"li: { li.TheValue }, value: { value }");
    }
}

#用户定义类型的转换--显式转换-explicit-需要强转的 => （）
using System;
//用户定义类型的转换--显式转换-explicit-需要强转的 => （）
class LimitedInt
{
   const int MaxValue = 100;
   const int MinValue = 0;

   public static explicit operator int(LimitedInt li)
   {
      return li.TheValue;
   }

   public static explicit operator LimitedInt(int x)
   {
        LimitedInt li = new LimitedInt
        {
            TheValue = x
        };
        return li;
   }

   private int _theValue = 0;
   public int TheValue
   { // Property
      get { return _theValue; }
      set
      {
         if (value < MinValue)
                _theValue = 0;
         else
                _theValue = value > MaxValue
                  ? MaxValue
                  : value;
      }
   }
}

class Program
{
   static void Main()
   {
      LimitedInt li = (LimitedInt)500;//显式转换-explicit-需要强转的 => （）
        int value = (int)li;

      Console.WriteLine($"li: { li.TheValue }, value: { value }");
   }
}
#//运算符重载示例
using System;
//运算符重载示例
class LimitedInt
{
   const int MaxValue = 100;
   const int MinValue = 0;

   public static LimitedInt operator -(LimitedInt x)//负数 => 返回值LimitedInt对象
    //                       LimitedInt  == 函数名字
    //         operator  -(LimitedInt x) ==  运算符+参数 => 参数
    {
        // In this strange class, negating a value just sets its value to 0.
        LimitedInt li = new LimitedInt()
        {
            TheValue = 0
        };
        return li;
   }

   public static LimitedInt operator -(LimitedInt x, LimitedInt y)//减法=> 返回值LimitedInt对象
    //                                   LimitedInt  == 函数名字
    //        operator -(LimitedInt x, LimitedInt y) ==  运算符+参数 => 参数
    {
        LimitedInt li = new LimitedInt()
        {
            TheValue = x.TheValue - y.TheValue
        };
        return li;
   }

   public static LimitedInt operator +(LimitedInt x, double y)//加法=> 返回值LimitedInt对象
         //                                   LimitedInt  == 函数名字
    //                  operator +(LimitedInt x, double y)/==  运算符+参数 => 参数
   {
        LimitedInt li = new LimitedInt()
        {
            TheValue = x.TheValue + (int)y
        };
        return li;
   }

   private int _theValue = 0;
   public int TheValue
   {
      get { return _theValue; }
      set
      {
         if (value < MinValue)
            _theValue = 0;
         else
            _theValue = value > MaxValue
            ? MaxValue
            : value;
      }
   }
}

class Program
{
   static void Main()
   {
      LimitedInt li1 = new LimitedInt();
      LimitedInt li2 = new LimitedInt();
      LimitedInt li3 = new LimitedInt();

      li1.TheValue = 10; li2.TheValue = 26;
      Console.WriteLine($" li1: { li1.TheValue }, li2: { li2.TheValue }");

      li3 = -li1;//operator -(LimitedInt x)/ => 调用重载的运算符时候 => 可以省略 operator
        Console.WriteLine($"-{ li1.TheValue } = { li3.TheValue }");

      li3 = li2 - li1;
      Console.WriteLine($" { li2.TheValue } - { li1.TheValue } = { li3.TheValue }");

      li3 = li1 - li2;//int类型 差 《 0 =>  =0
      Console.WriteLine($" { li1.TheValue } - { li2.TheValue } = { li3.TheValue }");
   }
}

#使用系统.反射;       使用反射命名空间充分利用确定有关类型的信息。
using System;
using System.Reflection;  
 //使用系统.反射;       使用反射命名空间充分利用确定有关类型的信息。

class SomeClass
{
   public int Field1;
   public int Field2;
   public void Method1() { }
   public int  Method2() { return 1; }
}

class Program
{
   static void Main()
   {
      Type t = typeof(SomeClass);//public abstract class Type : MemberInfo, _Type, IReflect
        FieldInfo[] fi  = t.GetFields();// public abstract class FieldInfo : MemberInfo, _FieldInfo
        MethodInfo[] mi = t.GetMethods();

      foreach (FieldInfo f in fi)
         Console.WriteLine($"Field : { f.Name }");
      foreach (MethodInfo m in mi)
         Console.WriteLine($"Method: { m.Name }");
   }
}


文本文件的读写
// using statement
         using (TextWriter tw = File.CreateText("Lincoln.txt"))
         {
            tw.WriteLine("Four score and seven years ago, ...");
         }

         // using statement
         using (TextReader tr = File.OpenText("Lincoln.txt"))
         {
            string InputString;
            while (null != (InputString = tr.ReadLine()))
               Console.WriteLine(InputString);
         }



@逐字字符串字面量

逐字字符串字面量
@——---两个双引号表示一个双引号

Operand  << Count	// Left shift
Operand  >> Count	// Right shift

在移动带符号的数字时，基础表示很重要，
因为向左移动一个位积分值的结果与将其乘以 2 的结果相同。将其向右移动与将其除以两相同。
移位 正整数 => 
正整数 
正整数 => x左移1位 == x*2 
正整数 => x右移1位 == x/2 

移位  负数 => x右移1位  => 左侧原站位 用0填充 => error



带符号的整数（包含负数） => 移位
若操作数是负数 => 则操作数最左侧位是 1（表示负数），
 => 于是 最左侧移开的位 其位置用 1 填充（非 0） => 这将保持正确的二补表示形式。

若操作数是非负数  => 最左侧移开的位 其位置用 0 填充即可


User-Defined Type Conversions
用户定义的类型转换
implicit conversion隐式转换,

public static implicit operator TargetType ( SourceType Identifier )
{
...
return ObjectOfTargetType;//目标类型的对象
}


explicit conversion显式转换，


显式转换的语法相同，只不过implicit被explicit替换。
以下代码显示了转换运算符的声明示例，该声明将 Forlimited 类型的对象转换为 int，反之亦然：

以下代码显示了转换运算符的声明示例，
该声明将 Forlimited 类型的对象转换为 int，反之亦然：




#多个资源和嵌套 using 语句也可以用于同一类型的多个资源，


Only one type	Resource	Resource
 	 	 
   	 
using ( ResourceType Id1 = Expr1, Id2 = Expr2, ... ) EmbeddedStatement
例如，在以下代码中，每个 using 语句分配和使用两个资源：

static void Main()
{
using (TextWriter tw1 = File.CreateText("Lincoln.txt"),tw2 = File.CreateText("Franklin.txt"))
{
tw1.WriteLine("Four score and seven years ago, ..."); 
tw2.WriteLine("Early to bed; Early to rise ...");
}

using (TextReader tr1 = File.OpenText("Lincoln.txt"),tr2 = File.OpenText("Franklin.txt"))
{
string InputString;

while (null != (InputString = tr1.ReadLine())) Console.WriteLine(InputString);

while (null != (InputString = tr2.ReadLine())) Console.WriteLine(InputString);
}
}

using 语句也可以嵌套。在以下代码中，除了 using 语句的嵌套之外，请注意，没有必要将块与第二个 using 语句一起使用，因为它仅包含单个简单语句。

using ( TextWriter tw1 = File.CreateText("Lincoln.txt") )
{
tw1.WriteLine("Four score and seven years ago, ...");

using ( TextWriter tw2 = File.CreateText("Franklin.txt") )	
// Nested tw2.WriteLine("Early to bed; Early to rise ...");	
// Single
}

# using 语句直接using对象


using 语句的另一种形式是：


Keyword	 Resource	 Uses resource
using ( Expression ) EmbeddedStatement/*嵌入式声明*/

在此窗体中，资源在 using 语句之前声明//但是这样做容易在using之后随意调用 已经终结的对象

TextWriter tw = File.CreateText("Lincoln.txt");	// Resource declared

using ( tw )	// using statement
tw.WriteLine("Four score and seven years ago, ...");


#结构
#结构的构造函数-默认-不覆盖
struct Simple
{
public int X; public int Y;
public Simple(int a, int b)	// Constructor with parameters
{
X = a;
Y = b;
}
}
class Program
{
static void Main()
{	Call implicit constructor
 
Simple s1 = new Simple();//无法重新定义、也是无需重新定义 => 直接可以调用无参的构造函数
 Simple s2 = new Simple(5, 10);
 
Call constructor
Console.WriteLine($"{ s1.X },{ s1.Y }");
Console.WriteLine($"{ s2.X },{ s2.Y }");
}
}

#结构声明中不允许实例属性和字段初始化程序
struct Simple
{	Not allowed
 
public int x = 0;	// Compile error
public int y = 10;	// Compile error
 
Not allowed
public int prop1 {get; set;} = 5; //Compile error
}
#结构默认密封-不可以使用：修饰符
•	protected
•	protected internal
•	abstract
•	sealed
•	virtual

##结构可以装箱、拆箱 => 
 => 可以作为返回值/参数


#枚举
##默认从0开始---枚举隐式的成员编号·1
using System;

enum TrafficLight
{
   Green,
   Yellow,
   Red
}

class Program
{
   static void Main(string[] args)
   {
      TrafficLight t1 = TrafficLight.Green;
           TrafficLight t2 = TrafficLight.Green;     // Assign from member
      TrafficLight t3 = t2;                     // 枚举成员相互调用

      Console.WriteLine($"{ t1 },\t{(int)t1 }");	0
      Console.WriteLine($"{ t2 },\t{(int)t2 }");	1
      Console.WriteLine($"{ t3 },\t{(int)t3 }\n");	2
   }	
}
##默认从0开始---枚举隐式的成员编号·2----同一个类中依次递增 结构之间的值
enum CardSuit {
Hearts,	// 0 - Since this is first
Clubs,	// 1  - One more than the previous one
Diamonds,	// 2  - One more than the previous one
Spades,	// 3  - One more than the previous one
MaxSuits	// 4 - A common way to assign a constant
}	//	to the number of listed items

enum FaceCards {
// Member	// Value assigned
Jack	= 11,	// 11 - Explicitly set
Queen,	// 12 - One more than the previous one
King,	// 13 - One more than the previous one
Ace,	// 14 - One more than the previous one NumberOfFaceCards = 4,	// 4 - Explicitly set
SomeOtherValue,		// 5 - One more than the previous one HighestFaceCard	= Ace	// 14 - Ace is defined above
}

11.2位标志
长期以来，程序员一直使用单个单词中的不同位作为表示一组开/关标志的紧凑方式。
在本节中，我们将此单词称为标志词。枚举提供了一种实现此方法的便捷方法。
一般步骤如下：
1. 确定所需的 位标志数，并选择具有足够位来容纳它们的 无符号整数类型。
2. 确定每个位位置代表什么，并给它一个名称。声明所选整数类型的枚举，每个成员由一个位 位置表示。
3. 使用按位 OR 运算符设置持有位标志的 [字]中的相应位。
4. 使用按位AND 运算符 或 HasFlag 检查是否设置了特定的位标志

方法或按位和运算符。例如，以下代码显示表示纸牌游戏卡片组选项的枚举声明。基础类型 uint 足以容纳所需的四位标志。请注意以下有关代码：
•	成员具有表示二进制选项的名称。
–	每个选项都由 [字]中的特定位位置表示。位位置持有 0 或 1。
–	由于一个位标志 表示 一个打开或关闭的位，
		若使用 0 作为成员值。 => 所有位标志都关闭了。
•	使用十六进制表示法，每个十六进制数字正好表示四位。
		由于位模式和十六进制表示之间的这种直接关联，
		在使用位模式时，通常使用十六进制而不是十进制表示。
•	从 C# 7.0 开始，二进制表示形式现在也可用。
•	使用 Flags 属性装饰（decorate）枚举实际上并不需要，
		但提供了一些额外的便利，我们稍后将讨论这些便利。
		属性显示为方括号之间的字符串，紧接在语言构造之前。
		在这种情况下，该属性紧接在枚举声明之前。我们将在第 25 章中介绍属性。

[Flags]
enum CardDeckSettings : uint
{
SingleDeck	= 0x01,	// Bit 0
LargePictures = 0x02,	// Bit 1
FancyNumbers  = 0x04,	// Bit 2
Animation	= 0x08	// Bit 3
}




#  | 运算符
using System;

enum CardDeckSettings : uint//冒号之后加上各种类型
{
   SingleDeck    = 0x01, // bit 0
   LargePictures = 0x02, // bit 1
   FancyNumbers  = 0x04, // bit 2
   Animation     = 0x08  // bit 3
}

class Program
{
   static void Main()
   {
      CardDeckSettings ops;
      ops = CardDeckSettings.FancyNumbers;      // Set one flag.
      Console.WriteLine(ops.ToString());
                                                // Set two bit flags.
      ops = CardDeckSettings.FancyNumbers | CardDeckSettings.Animation;
      Console.WriteLine(ops.ToString());        // Print what?
   }
}

代码：
FancyNumbers
12
请按任意键继续. .



##枚举·特定的 位标志集 判断 HasFlag

[Flags]
enum CardDeckSettings : uint
{
SingleDeck	= 0x01,	// Bit 0
LargePictures = 0x02,	// Bit 1
FancyNumbers  = 0x04,	// Bit 2
Animation	= 0x08	// Bit 3
}

枚举类型		CardDeckSettings
标志字			ops 
位标志 被“或” 在一起


CardDeckSettings ops =	CardDeckSettings.SingleDeck| CardDeckSettings.FancyNumbers| CardDeckSettings.Animation ;

HasFlag判断 标志字ops  => 是否包含特定的  位标志集“CardDeckSettings.FancyNumbers”
HasFlag判断 标志字ops  => 也是可以检测多个 位标志 如FancyNumbers 与 Animation

bool useFancyNumbers = ops.HasFlag(CardDeckSettings.FancyNumbers);

CardDeckSettings testFlags = CardDeckSettings.Animation | CardDeckSettings.FancyNumbers;
#检测是否所有的 位标志都在 标志字ops中 进行设置
bool useAnimationAndFancyNumbers = ops.HasFlag( testFlags );
#使用 & 与运算符 判断等价 => 证明是否设置了该 位标志
bool useFancyNumbers =
(ops & CardDeckSettings.FancyNumbers) == CardDeckSettings.FancyNumbers;

#枚举·有无[Flags]---
无[Flags]----使用数值-输出枚举-找不到对应枚举的 => 输出默认数值
//[Flags]
enum CardDeckSettings : uint
{
   SingleDeck    = 0x01, // bit 0
   LargePictures = 0x02, // bit 1
   FancyNumbers  = 0x04, // bit 2
   Animation     = 0x08  // bit 3
}

class Program
{
   static void Main()
   {
      CardDeckSettings ops;
      ops = CardDeckSettings.FancyNumbers;      // Set one flag.
      Console.WriteLine(ops.ToString());
                                                // Set two bit flags.
      ops = CardDeckSettings.FancyNumbers | CardDeckSettings.Animation;
      Console.WriteLine(ops.ToString());        // Print what?
   }
}
代码：
FancyNumbers
12
请按任意键继续. . .



有[Flags]----使用数值-输出枚举-找不到对应枚举的 => 有[Flags] => 告诉ToString()可以分开考虑 => 输出数值对应的 枚举组合
using System;
[Flags]//可以注释查看区别
enum CardDeckSettings : uint
{
   SingleDeck    = 0x01, // bit 0
   LargePictures = 0x02, // bit 1
   FancyNumbers  = 0x04, // bit 2
   Animation     = 0x08  // bit 3
}

class Program
{
   static void Main()
   {
      CardDeckSettings ops;
      ops = CardDeckSettings.FancyNumbers;      // Set one flag.
      Console.WriteLine(ops.ToString());
                                                // Set two bit flags.
      ops = CardDeckSettings.FancyNumbers | CardDeckSettings.Animation;
      Console.WriteLine(ops.ToString());        // Print what?
   }
}
代码：
FancyNumbers
FancyNumbers, Animation
请按任意键继续. . .

#枚举名字 => 	   可以命名空间声明静态 => using static TrafficLight;
#System.Console => 可以命名空间声明静态 => using static System.Console;
//直接输出枚举数据---省略枚举名+ .  TrafficLight.
//直接打印---------省略 Console

using System;
using static TrafficLight;//直接输出枚举数据---省略枚举名+ .  TrafficLight.
using static System.Console;//直接打印---------省略 Console
enum TrafficLight
{
   Green,
   Yellow,
   Red
}

class Program
{
   static void Main(string[] args)
   {
      TrafficLight t1 = TrafficLight.Green;
      TrafficLight t2 = TrafficLight.Yellow;
      TrafficLight t3 = TrafficLight.Red;

        WriteLine($"{ t1 },\t{(int)t1 }");
        WriteLine($"{ t2 },\t{(int)t2 }");
        WriteLine($"{ t3 },\t{(int)t3 }\n");

        WriteLine($"{ Green }");//直接打印---------省略 Console   +//直接输出枚举数据---省略枚举名+ .  TrafficLight.
        WriteLine($"{ Yellow }");
        WriteLine($"{ Red }");

    }
}

using System;
using static TrafficLight;//直接输出枚举数据---省略枚举名+ .  TrafficLight.
using static System.Console;//直接打印---------省略 Console
enum TrafficLight
{
   Green,
   Yellow,
   Red
}

class Program
{
   static void Main(string[] args)
   {
      TrafficLight t1 = TrafficLight.Green;
      TrafficLight t2 = TrafficLight.Yellow;
      TrafficLight t3 = TrafficLight.Red;

        WriteLine($"{ t1 },\t{(int)t1 }");
        WriteLine($"{ t2 },\t{(int)t2 }");
        WriteLine($"{ t3 },\t{(int)t3 }\n");

        WriteLine($"{ Green }");//直接打印---------省略 Console   +//直接输出枚举数据---省略枚举名+ .  TrafficLight.
        WriteLine($"{ Yellow }");
        WriteLine($"{ Red }");

    }
}

# Enum.GetName（Type（枚举名字），默认数字）与 Enum.GetNames（）全部枚举成员；
using System;

enum TrafficLight
{
   Green,
   Yellow,
   Red
}

class Program
{
   static void Main()
   {
      Console.WriteLine("Second member of TrafficLight is {0}\n", Enum.GetName(typeof(TrafficLight), 1));
      foreach (var name in Enum.GetNames(typeof(TrafficLight)))
         Console.WriteLine(name);
   }
}

#	数组初始化与var推断
此处需要声明数组的 秩
var	intArr4 = new	[,]/*此处需要声明数组的秩*/ { { 10, 1 }, { 2, 10 }, { 11, 9 } };
Explicit		Explicit
int [] intArr1 = new int[] { 10, 20, 30, 40 };
var	intArr2 = new	[] { 10, 20, 30, 40 };
 	 
Keyword	Inferred
int[,] intArr3 = new int[,] { { 10, 1 }, { 2, 10 }, { 11, 9 } };
var	intArr4 = new	[,]/*此处需要声明数组的秩*/ { { 10, 1 }, { 2, 10 }, { 11, 9 } };
 
Rank specifier
string[] sArr1 = new string[] { "life", "liberty", "pursuit of happiness" }; 
var	sArr2 = new	[] { "life", "liberty", "pursuit of happiness" };






##数组
##行列-
class Program
{
   static void Main( string[] args )
   {
      // 声明、创建和初始化隐式类型化数组。
      var arr = new int[,] { { 0, 1, 2 }, { 10, 11, 12 } };

      // Print the values.
      for ( int i = 0; i < 2; i++ )
         for ( int j = 0; j < 3; j++ )
            Console.WriteLine( $"Element [{ i },{ j }] is { arr[i, j] }" );
   }
}

#交错数组  秩 >= 2
[][]  =>  秩 = 2
int[][]	SomeArr;	// Rank = 2
int[][][] OtherArr;	// Rank = 3
int[][] jagArr = new int[3][];
int[][] jagArr = new int[3][4];
	// Wrong! Compile error---[ 子数组]的个数只可以在第一个[]中定义
###交错数组的定义+实例化
int[][] Arr = new int[3][]					//  1.实例化顶层。 
Arr[0] = new int[] {10, 20, 30};			// 2. Instantiate 子数组.
Arr[1] = new int[] {40, 50, 60, 70};		// 3. Instantiate 子数组.
Arr[2] = new int[] {80, 90, 100, 110, 120};  // 4. Instantiate 子数组.

###交错数组的 [ 子数组]
交错数组的方法 GetLength(int n) => 继承 System.Array => 获取数组中指定维度的长度


{ 
	{ 10, 20 },
	{ 100, 200 } 
};

{
	{ 30, 40, 50 },
	{ 300, 400, 500 } 
};

{
	{ 60, 70, 80, 90 },
	{ 600, 700, 800, 900 }
};






 //
        // 摘要:
        //     获取一个 32 位整数，该整数表示 System.Array 的指定维中的元素数。
        //
        // 参数:
        //   dimension:
        //     System.Array 的从零开始的维度，其长度需要确定。
        //
        // 返回结果:
        
        // 异常:
        //   T:System.IndexOutOfRangeException:
        //     dimension 小于零。- 或 -dimension 等于或大于 System.Array.Rank。
        



事件
using System;

delegate void Handler();//事件需要委托---参数、返回值 与委托一致

class Incrementer
{
   public event Handler CountedADozen;//创建·发布·事件

   public void DoCount()
   {
      for ( int i = 1; i < 100; i++ )//8*12=96
         if ( i % 12 == 0 && CountedADozen != null )//每12个计数··触发一次事件
            CountedADozen();
   }
}

class Dozens
{
   public int DozensCount { get; private set; }

   public Dozens( Incrementer incrementer )//构造函数-事件所在类的对象·作为参数
   {
      DozensCount = 0;
      incrementer.CountedADozen += IncrementDozensCount;//参数.事件 += 事件···订阅事件
   }

   void IncrementDozensCount()
   {
      DozensCount++;
   }
}

class Program
{
   static void Main()
   {
      Incrementer incrementer = new Incrementer();
      Dozens dozensCounter = new Dozens( incrementer );//对象---作为参数

      incrementer.DoCount();//对象.方法···事件类中的方法调用---事件触发8次---订阅者对象中··注册事件调用8次 => 同时对象字段发生变化 => 构造函数中注册的事件
      Console.WriteLine( "Number of dozens = {0}",
                              dozensCounter.DozensCount );
   }
}




细细品味C#抽象接口
与abstract一样；类似抽象-无需实现成员

using System ; interface IInteger {
void Add(int i) ;
}
interface IDouble {
void Add(double d) ;
}
interface INumber: IInteger, IDouble {
} 
class CMyTest {
void Test(INumber n)
 {
// Num.Add(1) ; 错误
n.Add(1.0) ; // 正确
((IInteger)n).Add(1) ; // 正确
((IDouble)n).Add(1) ; // 正确
}
}


interface IBase { void FWay(int i) ;
}
interface ILeft: IBase { new void FWay (int i) ;
}
interface IRight: IBase
{ void G( ) ; }
interface IDerived: ILeft, IRight { }

class CTest {
void Test(IDerived d)
 {
d. FWay (1) ; // 调 用 ILeft. FWay 
((IBase)d). FWay (1) ; // 调 用 IBase. FWay 
((ILeft)d). FWay (1) ; // 调 用 ILeft. FWay 
((IRight)d). FWay (1) ; // 调用 IBase. FWay
}
}


上例中，方法 IBase.FWay 在派生的接口 ILeft 中被 Ileft 的成员方法 FWay 覆盖了。
所以对 d. FWay (1)的调用实际上调用了。
虽然从 IBase-> IRight-> IDerived 这条继承路径上来看,
ILeft.FWay 方法是没有被覆盖的。
我们只要记住这一点：一旦成员被覆盖以后，所有对其的访问都被覆盖以后的成员"拦截"了。
类对接口的实现

前面我们已经说过，接口定义不包括方法的实现部分。接口可以通过类或结构来实现。我们主要讲述通过类来实现接口。用类来实现接口时，接口的名称必须包含在类定义中的基类列表中。

下面的例子给出了由类来实现接口的例子。其中 ISequence 为一个队列接口，提供了向队列尾部添加对象的成员方法 Add( )，
IRing 为一个循环表接口，提供了向环中插入对象的方法 Insert(object obj)，方法返回插入的位置。类 RingSquence 实现了接口 ISequence 和接口 IRing



using System ; 

interface ISequence 
{
	object Add( ) ;
}
interface IRing 
{
int Insert(object obj) ;
}
class RingSequence: ISequence, IRing
{
public object Add( ) {…}
public int Insert(object obj) {…}
}


#重写与覆盖

interface IControl 
{ void Paint( ) ;
}

class Control: IControl 
{ 
public virtual void Paint( ) {...}
}
class TextBox: Control 
{
public override void Paint( ) {...}
}

Control c = new Control( ) ; 
TextBox t = new TextBox( ) ; 
IControl ic = c ;
IControl it = t ;
c.Paint( ) ; // 影响 Control.Paint( ); 
t.Paint( ) ; // 影响 TextBox.Paint( ); 
ic.Paint( ) ; // 影响 Control.Paint( ); 
虚方法
it.Paint( ) ; // 影响 TextBox.Paint( );//虚方法 重写无效--保持TextBoxPaint( );. //当一个接口方法被映射到一个类中的虚拟方法，派生类就不可能覆盖这个虚拟方法并且改变接口的实现函数
但是这样子可以覆盖接口方法的
interface IControl 
{ 
void Paint( ) ;
}
class Control: IControl 
{
	
void IControl.Paint( ) 
{ 
PaintControl( ); 
} 

protected virtual void PaintControl( ) {...}

}
class TextBox: Control 
{
protected override void PaintControl( ) {...}
}



#协变、逆变
协变       out

elegate T Factory<out T>( );//协变  out 关键字执行类型参数的协变

class Animal	{ public int Legs = 4; } // Base class class 
Dog : Animal { }	// Derived class

delegate T Factory<T>( );	//delegate Factory

class Program
{
static Dog MakeDog( )	//Method that matches delegate Factory
{
return new Dog( );
}
static void Main( )
{
Factory<Dog>	dogMaker	= MakeDog;	
//Create delegate object.
Factory<Animal> animalMaker = dogMaker;	//直接转换 出错 =>  需要使用 out => 两个泛型没有继承关系 => 使用out之后就是可以
//Attempt to assign delegate object.
Console.WriteLine( animalMaker( ).Legs.ToString( ) );
}
}




#逆变关键字 in

class Animal { public int NumberOfLegs = 4; } 
class Dog : Animal { }

class Program	
{
delegate void Action1<in T>( T a );//逆变关键字 in
static void ActOnAnimal( Animal a ) 
{ Console.WriteLine( a.NumberOfLegs ); } 

static void Main( )
{
Action1<Animal> act1 = ActOnAnimal;
 Action1<Dog>	dog1 = act1;
dog1( new Dog() );
}
}

This code produces the following output:

4



dynamic

索引器·常量·无法声明静态
常量const·必须初始化
readonly 与 const
switch 有无 break
索引器多参数重载
外部读取，内部写入·属性




typeof
1·主窗体 =》 
 public SFMainEntry() =》 namespace ProtocolSF =》 SFMainEntry.cs
四方协议命名空间 =》 ProtocolSFCommunication 类全名
className = typeof(ProtocolSF.ProtocolSFCommunication).FullName;


2·协议支持的操作系统
        public override List<OSFamily> ProtocolConfigureOperationSystem()
3·命名空间（解决方案同名cs） =》 同名命名空间 =》 
下面的字段、属性、构造函数、、重写方法--连接字符串
顺序 =》 事件





运行时的显示--高亮
调试配置---解决方案属性
枚举当做数组
List<T>集合初始化
构造函数-基类
Collection<DeviceOperationInfo>();     

return new List<OSFamily>
(new OSFamily[] { OSFamily.Windows, OSFamily.Uniux });
执行顺序·override之间区别
		virtual		不一定 override
		abstract	  一定 override
线程		

先入为主·否定

\\192.100.106.134\\

FipsAlgorithmPolicyCheck```菲普斯算法策略检查


1、增加设备分类功能，II设备可以进行自维护开锁 
2、传票前增加用户身份认证授权功能
3、系统联调 





  1	 福建自运维解锁操作管理需求 	  	 2019/9/30 	 	 
  
  吕友森 	 软件工程师 	
  1、增加设备分类功能，II设备可以进行自维护开锁 
  分类
  自维护开锁：远程遥控二次设备解锁，
				   设置二次设备闭锁属性
				   监控请求解锁二次设备  =》  五防 =》 允许解锁 =》 监控执行解锁
				   
  
  二次设备
			jyyo-j 传票之前--生成任务后
										--可以自学、无法传票 =》 验证权限 =》 
										当前用户对比注册信息
										
			
  
  2、传票前增加用户身份认证授权功能 
  3、系统联调 	  	 10.00 	 10 		
	系统联调 =》 联合调试控制、自动化、联合
  明细 
   
  
  龙文航 	 软件工程师 	 1、增加一种自维护票类型，开发一个外挂模块，增加“开自维护任务”菜单 2、增加自维护任务开票流程，能够生成相应术语，将设备加入票中，开票过程类似开检修票 
  3、接收钥匙回传信息后，给规约提供接口结束任务，并记录任务信息 4、系统联调 	  	 26.00 	 26 		 
  
  王恺 	 软件工程师 	 
  1、和钥匙组协商修改1D钥匙规约文档，增加自维护票类型 2、修改传票规约，能够传输自维护票和接收钥匙回传信息 
  3、系统联调 
  
  
  
  ProtocolBase base1 = ProtocolSF.ProtocolSFCommunication
  base1.Config() 
        public ProtocolSFCommunication()``
  

xmldoc.LoadXml（"<ChannelParameters><NO>0</NO><Name>四方五防规约通道0</Name></ChannelParameters>"）

{Element, Name="NO"}
string strSel = "//ChannelParameters/NO";
                    XmlNode mode = xmldoc.SelectSingleNode(@strSel);
@ 取消转义					
  
  
1·SFMainEntry.cs···SFMainEntry : MainEntryBase, IProtocolsInfo
字段
构造函数
重写父类···SupportedOperationSystem···MainEntryBase（ProtocolSF）

2·ProtocolSF.cs···ProtocolSFCommunication: ProtocolBase, IProtocol

{
    class ProtocolSFCommunication : ProtocolBase, IProtocol
构造函数 ···（···默认属性） 
重写父类···Config···ProtocolSFCommunication（ProtocolSF）···处理规约参数的配置内容param。
  
  
  "<ChannelParameters><NO>0</NO><Name>四方五防规约通道0</Name></ChannelParameters>"
  
  
  
  下载请求的资源作为 System.String。 要下载的资源指定为 System.String 其中包含的 URI。
  
基类字段在子类中的覆盖于扩展

已经证明：
父类：接口1
子类：父类1，接口1  
是否还是需要实现父类
实现完美的封装
  
目标
事件执行顺序 =》 四方 =》 客户端 =》 事件注册于传递
编写顺序
事件注册·调用
任务权限设置 =》 任务所在位置 =》 执行之前用户权限设置
 设备分类查看=》 二次设备单独拎出  
  
项目添加到了···············  
F:\项目控制\ScadaIV\JOYOJ6\老代码\五防平台\配置工具\IVToJoyoJ
  
  
  
  
  
public sealed partial class JoyoMessageLogWriter 
{		

}

MainStarter.cs
InitLogFileNameSuffix
Main
JoyoMessageLogWriter  

等待添加
E:\项目控制\ScadaIV\JOYOJ6\五防平台\公共模块\WFTypes\BaseType\UTCommonClasses.cs
 
 E:\项目控制\ScadaIV\JOYOJ6\五防平台\公共模块\WFCommon\SystemRules.cs
 
E:\项目控制\ScadaIV\JOYOJ6\五防平台\人机交互\JoyoJClient\JoyojLoader.cs  
  
E:\项目控制\ScadaIV\JOYOJ6\五防平台\公共模块\UTAdvType\JoyojLoaderBase.cs
E:\项目控制\ScadaIV\JOYOJ6\五防平台\人机交互\WFInterfaceWinForm\Communication\ChannelConfigureForm.cs








