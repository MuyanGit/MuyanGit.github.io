



参数数组
 允许向方法
  修饰符声明。只有方法的最后一个参数才可以是参数数组，并且参数数组的类型必须是一维数组类型。System.Console 类的 Write 和 WriteLine 方法就是参数数组用法的很好示例。它们的声明如下。
public class Console
{
	public static void Write(string fmt, params object[] args) {...}
	public static void WriteLine(string fmt, params object[] args) {...}
	...
}
在使用参数数组的方法中，参数数组的行为完全就像常规的数组类型参数。但是，在具有参数数组的方法的调用中，既可以传递参数数组类型的单个实参，也可以传递参数数组的元素类型的任意数目的实参。在后一种情况下，将自动创建一个数组实例，并使用给定的实参对它进行初始化。示例：
Console.WriteLine("x={0} y={1} z={2}", x, y, z);
等价于以下语句：
string s = "x={0} y={1} z={2}";
object[] args = new object[3];
args[0] = x;
args[1] = y;
args[2] = z;
Console.WriteLine(s, args);
1.6.6.2 方法体和局部变量
方法体指定了在调用该方法时将执行的语句。
方法体可以声明仅用在该方法调用中的变量。这样的变量称为局部变量 (local variable)。局部变量声明指定了类型名称、变量名称，还可指定初始值。下面的示例声明一个初始值为零的局部变量 i 和一个没有初始值的变量 j。
using System;
class Squares
{
	static void Main() {
		int i = 0;
		int j;
		while (i < 10) {
			j = i * i;
			Console.WriteLine("{0} x {0} = {1}", i, j);
			i = i + 1;
		}
	}
}
C# 要求在对局部变量明确赋值 (definitely assigned) 之后才能获取其值。例如，如果前面对 i 的声明中未包括初始值，则编译器将针对随后对 i 的使用报错，因为 i 在程序中的这些位置还没有明确赋值。
方法可以使用 return 语句将控制返回到它的调用方。在返回 void 的方法中，return 语句不能指定表达式。在返回非 void 的方法中，return 语句必须含有一个计算返回值的表达式。
1.6.6.3 静态方法和实例方法
使用 static 修饰符声明的方法为静态方法 (static method)。静态方法不对特定实例进行操作，并且只能直接访问静态成员。
不使用 static 修饰符声明的方法为实例方法 (instance method)。实例方法对特定实例进行操作，并且能够访问静态成员和实例成员。在调用实例方法的实例上，可以通过 this 显式地访问该实例。而在静态方法中引用 this 是错误的。
下面的 Entity 类具有静态成员和实例成员。
class Entity
{
	static int nextSerialNo;
	int serialNo;
	public Entity() {
		serialNo = nextSerialNo++;
	}
	public int GetSerialNo() {
		return serialNo;
	}
	public static int GetNextSerialNo() {
		return nextSerialNo;
	}
	public static void SetNextSerialNo(int value) {
		nextSerialNo = value;
	}
}
每个 Entity 实例都包含一个序号（我们假定这里省略了一些其他信息）。Entity 构造函数（类似于实例方法）使用下一个可用的序号来初始化新的实例。由于该构造函数是一个实例成员，它既可以访问 serialNo 实例字段，也可以访问 nextSerialNo 静态字段。
GetNextSerialNo 和 SetNextSerialNo 静态方法可以访问 nextSerialNo 静态字段，但是如果直接访问 serialNo 实例字段就会产生错误。
下面的示例演示 Entity 类的使用。
using System;
class Test
{
	static void Main() {
		Entity.SetNextSerialNo(1000);
		Entity e1 = new Entity();
		Entity e2 = new Entity();
		Console.WriteLine(e1.GetSerialNo());				// Outputs "1000"
		Console.WriteLine(e2.GetSerialNo());				// Outputs "1001"
		Console.WriteLine(Entity.GetNextSerialNo());		// Outputs "1002"
	}
}
注意：SetNextSerialNo 和 GetNextSerialNo 静态方法是在类上调用的，而 GetSerialNo 实例方法是在该类的实例上调用的。
1.6.6.4 虚方法、重写方法和抽象方法
若一个实例方法的声明中含有 virtual 修饰符，则称该方法为虚方法。若其中没有 virtual 修饰符，则称该方法为非虚方法。
在调用一个虚方法时，该调用所涉及的实例的运行时类型 (runtime type) 确定了要实际调用的方法实现。在非虚方法调用中，实例的编译时类型 (compile-time type) 负责做出此决定。
虚方法可以在派生类中重写 (override)。当某个实例方法声明包括 override 修饰符时，该方法将重写所继承的具有相同签名的虚方法。虚方法声明用于引入新方法，而重写方法声明则用于使现有的继承虚方法专用化（通过提供该方法的新实现）。
抽象 (abstract) 方法是没有实现的虚方法。抽象方法使用 abstract 修饰符进行声明，并且只允许出现在同样被声明为 abstract 的类中。抽象方法必须在每个非抽象派生类中重写。
下面的示例声明一个抽象类 Expression，它表示一个表达式目录树节点；它有三个派生类 Constant、VariableReference 和 Operation，它们分别实现了常量、变量引用和算术运算的表达式目录树节点。（这与第 4.6 节中介绍的表达式树类型相似，但不要混淆）。
using System;
using System.Collections;
public abstract class Expression
{
	public abstract double Evaluate(Hashtable vars);
}
public class Constant: Expression
{
	double value;
	public Constant(double value) {
		this.value = value;
	}
	public override double Evaluate(Hashtable vars) {
		return value;
	}
}
public class VariableReference: Expression
{
	string name;
	public VariableReference(string name) {
		this.name = name;
	}
	public override double Evaluate(Hashtable vars) {
		object value = vars[name];
		if (value == null) {
			throw new Exception("Unknown variable: " + name);
		}
		return Convert.ToDouble(value);
	}
}
public class Operation: Expression
{
	Expression left;
	char op;
	Expression right;
	public Operation(Expression left, char op, Expression right) {
		this.left = left;
		this.op = op;
		this.right = right;
	}
	public override double Evaluate(Hashtable vars) {
		double x = left.Evaluate(vars);
		double y = right.Evaluate(vars);
		switch (op) {
			case '+': return x + y;
			case '-': return x - y;
			case '*': return x * y;
			case '/': return x / y;
		}
		throw new Exception("Unknown operator");
	}
}
上面的四个类可用于为算术表达式建模。例如，使用这些类的实例，表达式 x + 3 可如下表示。
Expression e = new Operation(
	new VariableReference("x"),
	'+',
	new Constant(3));
代码中调用了 Expression 实例的 Evaluate 方法，以计算给定表达式的值，从而生成一个 double 值。该方法接受一个包含变量名称（作为哈希表项的键）和值（作为项的值）的 Hashtable 作为实参。Evaluate 方法是一个虚抽象方法，意味着非抽象派生类必须重写该方法以提供实际的实现。
Constant 的 Evaluate 实现只是返回所存储的常量。VariableReference 的实现在哈希表中查找变量名称，并返回产生的值。Operation 的实现先对左操作数和右操作数求值（通过递归调用它们的 Evaluate 方法），然后执行给定的算术运算。
下面的程序使用 Expression 类，对于不同的 x 和 y 值，计算表达式 x * (y + 2) 的值。
using System;
using System.Collections;
class Test
{
	static void Main() {
		Expression e = new Operation(
			new VariableReference("x"),
			'*',
			new Operation(
				new VariableReference("y"),
				'+',
				new Constant(2)
			)
		);
		Hashtable vars = new Hashtable();
		vars["x"] = 3;
		vars["y"] = 5;
		Console.WriteLine(e.Evaluate(vars));		// Outputs "21"
		vars["x"] = 1.5;
		vars["y"] = 9;
		Console.WriteLine(e.Evaluate(vars));		// Outputs "16.5"
	}
}
1.6.6.5 方法重载
方法重载 (overloading) 允许同一类中的多个方法具有相同名称，条件是这些方法具有唯一的签名。在编译一个重载方法的调用时，编译器使用重载决策 (overload resolution) 确定要调用的特定方法。重载决策将查找与参数最佳匹配的方法，如果没有找到任何最佳匹配的方法则报告错误信息。下面的示例演示重载决策的工作机制。Main 方法中的每个调用的注释表明实际调用的方法。
class Test
{
	static void F() {
		Console.WriteLine("F()");
	}
	static void F(object x) {
		Console.WriteLine("F(object)");
	}
	static void F(int x) {
		Console.WriteLine("F(int)");
	}
	static void F(double x) {
		Console.WriteLine("F(double)");
	}
	static void F<T>(T x) {
		Console.WriteLine("F<T>(T)");
	}
	static void F(double x, double y) {
		Console.WriteLine("F(double, double)");
	}
	static void Main() {
		F();					// Invokes F()
		F(1);					// Invokes F(int)
		F(1.0);				// Invokes F(double)
		F("abc");			// Invokes F(object)
		F((double)1);		// Invokes F(double)
		F((object)1);		// Invokes F(object)
		F<int>(1);			// Invokes F<T>(T)
		F(1, 1);				// Invokes F(double, double)	}
}
正如该示例所示，总是通过显式地将实参强制转换为确切的参数类型和/或显式地提供类型实参，来选择一个特定的方法。
1.6.7 其他函数成员
包含可执行代码的成员统称为类的函数成员 (function member)。前一节描述的方法是函数成员的主要类型。本节介绍了 C# 支持的其他类型的函数成员：构造函数、属性、索引器、事件、运算符和析构函数。
下表演示一个名为 List<T> 的泛型类，它实现一个可增长的对象列表。该类包含了几种最常见的函数成员的示例。
public class List<T>
{
	const int defaultCapacity = 4;	常量
	T[] items;
	int count;	字段
	public List(int capacity = defaultCapacity) {
		items = new T[capacity];
	}	构造函数
	public int Count {
		get { return count; }
	}
	public int Capacity {
		get {
			return items.Length;
		}
		set {
			if (value < count) value = count;
			if (value != items.Length) {
				T[] newItems = new T[value];
				Array.Copy(items, 0, newItems, 0, count);
				items = newItems;
			}
		}
	}	属性

	public T this[int index] {
		get {
			return items[index];
		}
		set {
			items[index] = value;
			OnChanged();
		}
	}	索引器
	public void Add(T item) {
		if (count == Capacity) Capacity = count * 2;
		items[count] = item;
		count++;
		OnChanged();
	}
	protected virtual void OnChanged() {
		if (Changed != null) Changed(this, EventArgs.Empty);
	}
	public override bool Equals(object other) {
		return Equals(this, other as List<T>);
	}
	static bool Equals(List<T> a, List<T> b) {
		if (a == null) return b == null;
		if (b == null || a.count != b.count) return false;
		for (int i = 0; i < a.count; i++) {
			if (!object.Equals(a.items[i], b.items[i])) {
				return false;
			}
		}
      return true;
	}	方法
	public event EventHandler Changed;	事件
	public static bool operator ==(List<T> a, List<T> b) {
		return Equals(a, b);
	}
	public static bool operator !=(List<T> a, List<T> b) {
		return !Equals(a, b);
	}	运算符
}

1.6.7.1 构造函数
C# 支持两种构造函数：实例构造函数和静态构造函数。实例构造函数 (instance constructor) 是实现初始化类实例所需操作的成员。静态构造函数 (static constructor) 是一种用于在第一次加载类本身时实现其初始化所需操作的成员。
构造函数的声明如同方法一样，不过它没有返回类型，并且它的名称与其所属的类的名称相同。如果构造函数声明包含 static 修饰符，则它声明了一个静态构造函数。否则，它声明的是一个实例构造函数。
实例构造函数可以被重载。例如，List<T> 类声明了两个实例构造函数，一个无参数，另一个接受一个 int 参数。实例构造函数使用 new 运算符进行调用。下面的语句分别使用 List<string> 类的每个构造函数分配两个 List 实例。
List<string> list1 = new List<string>();
List<string> list2 = new List<string>(10);
实例构造函数不同于其他成员，它是不能被继承的。一个类除了其中实际声明的实例构造函数外，没有其他的实例构造函数。如果没有为某个类提供任何实例构造函数，则将自动提供一个不带参数的空的实例构造函数。
1.6.7.2 属性
属性 (property) 是字段的自然扩展。属性和字段都是命名的成员，都具有相关的类型，且用于访问字段和属性的语法也相同。然而，与字段不同，属性不表示存储位置。相反，属性有访问器 (accessor)，这些访问器指定在它们的值被读取或写入时需执行的语句。
属性的声明与字段类似，不同的是属性声明以位于定界符 { 和 } 之间的一个 get 访问器和/或一个 set 访问器结束，而不是以分号结束。同时具有 get 访问器和 set 访问器的属性是读写属性 (read-write property)，只有 get 访问器的属性是只读属性 (read-only property)，只有 set 访问器的属性是只写属性 (write-only property)。
get 访问器相当于一个具有属性类型返回值的无形参方法。除了作为赋值的目标，当在表达式中引用属性时，将调用该属性的 get 访问器以计算该属性的值。
set 访问器相当于具有一个名为 value 的参数并且没有返回类型的方法。当某个属性作为赋值的目标被引用，或者作为 ++ 或 -- 的操作数被引用时，将调用 set 访问器，并传入提供新值的实参。
List<T> 类声明了两个属性 Count和 Capacity，它们分别是只读属性和读写属性。下面是这些属性的使用示例。
List<string> names = new List<string>();
names.Capacity = 100;			// Invokes set accessor
int i = names.Count;				// Invokes get accessor
int j = names.Capacity;			// Invokes get accessor
与字段和方法相似，C# 同时支持实例属性和静态属性。静态属性使用 static 修饰符声明，而实例属性的声明不带该修饰符。
属性的访问器可以是虚的。当属性声明包括 virtual、abstract 或 override 修饰符时，修饰符应用于该属性的访问器。
1.6.7.3 索引器
索引器 (indexer) 是这样一个成员：它支持按照索引数组的方法来索引对象。索引器的声明与属性类似，不同的是该成员的名称是 this，后跟一个位于定界符 [ 和 ] 之间的参数列表。在索引器的访问器中可以使用这些参数。与属性类似，索引器可以是读写、只读和只写的，并且索引器的访问器可以是虚的。
该 List 类声明了单个读写索引器，该索引器接受一个 int 参数。该索引器使得通过 int 值对 List 实例进行索引成为可能。例如
List<string> names = new List<string>();
names.Add("Liz");
names.Add("Martha");
names.Add("Beth");
for (int i = 0; i < names.Count; i++) {
	string s = names[i];
	names[i] = s.ToUpper();
}
索引器可以被重载，这意味着一个类可以声明多个索引器，只要其参数的数量和类型不同即可。
1.6.7.4 事件
事件 (event) 是一种使类或对象能够提供通知的成员。事件的声明与字段类似，不同的是事件的声明包含 event 关键字，并且类型必须是委托类型。
在声明事件成员的类中，事件的行为就像委托类型的字段（前提是该事件不是抽象的并且未声明访问器）。该字段存储对一个委托的引用，该委托表示已添加到该事件的事件处理程序。如果尚未添加事件处理程序，则该字段为 null。
List<T> 类声明了一个名为 Changed 的事件成员，它指示已将一个新项添加到列表中。Changed 事件由 OnChanged 虚方法引发，后者先检查该事件是否为 null（表明没有处理程序）。“引发一个事件”与“调用一个由该事件表示的委托”这两个概念完全等效，因此没有用于引发事件的特殊语言构造。
客户端通过事件处理程序 (event handler) 来响应事件。事件处理程序使用 += 运算符附加，使用 -= 运算符移除。下面的示例向 List<string> 类的 Changed 事件附加一个事件处理程序。
using System;
class Test
{
	static int changeCount;
	static void ListChanged(object sender, EventArgs e) {
		changeCount++;
	}
	static void Main() {
		List<string> names = new List<string>();
		names.Changed += new EventHandler(ListChanged);
		names.Add("Liz");
		names.Add("Martha");
		names.Add("Beth");
		Console.WriteLine(changeCount);		// Outputs "3"
	}
}
对于要求控制事件的底层存储的高级情形，事件声明可以显式提供 add 和 remove 访问器，它们在某种程度上类似于属性的 set 访问器。
1.6.7.5 运算符
运算符 (operator) 是一种类成员，它定义了可应用于类实例的特定表达式运算符的含义。可以定义三类运算符：一元运算符、二元运算符和转换运算符。所有运算符都必须声明为 public 和 static。
List<T> 类声明了两个运算符 operator == 和 operator !=，从而为将那些运算符应用于 List 实例的表达式赋予了新的含义。具体而言，上述运算符将两个 List<T> 实例的相等关系定义为逐一比较其中所包含的对象（使用所包含对象的 Equals 方法）。下面的示例使用 == 运算符比较两个 List<int> 实例。
using System;
class Test
{
	static void Main() {
		List<int> a = new List<int>();
		a.Add(1);
		a.Add(2);
		List<int> b = new List<int>();
		b.Add(1);
		b.Add(2);
		Console.WriteLine(a == b);		// Outputs "True" 
		b.Add(3);
		Console.WriteLine(a == b);		// Outputs "False"
	}
}
第一个 Console.WriteLine 输出 True，原因是两个列表包含的对象数目、对象顺序和对象值都相同。如果 List<T> 未定义 operator ==，则第一个 Console.WriteLine 将输出 False，原因是 a 和 b 引用的是不同的 List<int> 实例。
1.6.7.6 析构函数
析构函数 (destructor) 是一种用于实现销毁类实例所需操作的成员。析构函数不能带参数，不能具有可访问性修饰符，也不能被显式调用。垃圾回收期间会自动调用所涉及实例的析构函数。
垃圾回收器在决定何时回收对象和运行析构函数方面允许有广泛的自由度。具体而言，析构函数调用的时机并不是确定的，析构函数可以在任何线程上执行。由于这些以及其他原因，仅当没有其他可行的解决方案时，才应在类中实现析构函数。
using 语句提供了更好的对象析构方法。








Partial classes can also define partial methods. 
Partial methods are defined in one partial class definition without a method body, 
and implemented in another partial class definition. In both places,  the partial keyword is used:
部分类可定义部分方法。
部分方法在一个不带方法体的部分类定义中定义,
并在另一个部分类定义中实现。
在这两个位置,使用部分关键字:
public partial class MyClass
{
partial void MyPartialMethod();//不带方法体的部分类中定义————部分方法
}
 


public partial class MyClass
{
partial void MyPartialMethod()//另一个部分类定义中实现。
{
// Method implementation方法贯彻，执行//
}
}

Partial methods can also be static, but they are always private and can’t have a return value. Any parameters they use can’t be out parameters, although they can be ref parameters. They also can’t use the virtual, abstract, override, new, sealed, or extern modifiers.
Given these limitations, it is not immediately obvious what purpose partial methods fulfill. In fact, they are important when it comes to code compilation, rather than usage. Consider the following code:
public partial class MyClass
{
partial void DoSomethingElse(); public void DoSomething()
{
WriteLine("DoSomething() execution started."); DoSomethingElse();
WriteLine("DoSomething() execution finished.");
}
}
public partial class MyClass
{
partial void DoSomethingElse() => WriteLine("DoSomethingElse() called.");
}
Here, the partial method DoSomethingElse() is defined and called in the first partial class defini- tion, and implemented in the second. The output, when DoSomething() is called from a console application, is what you might expect:
DoSomething() execution started. DoSomethingElse() called.
DoSomething() execution finished.
If you were to remove the second partial class definition or partial method implementation entirely (or comment out the code), the output would be as follows:
DoSomething() execution started. DoSomething() execution finished.
You might assume that what is happening here is that when the call to DoSomethingElse() is made, the runtime discovers that the method has no implementation and therefore continues executing the next line of code. What actually happens is a little subtler. When you compile code that contains
a partial method definition without an implementation, the compiler actually removes the method entirely. It also removes any calls to the method. When you execute the code, no check is made for an implementation because there is no call to check. This results in a slight—but nevertheless significant—improvement in performance.
 


As with partial classes, partial methods are useful when it comes to customizing autogenerated
or designer-created code. The designer may declare partial methods that you can choose to imple- ment or not depending on the situation. If you don’t implement them, you incur no performance hit because effectively the method does not exist in the compiled code.
Consider at this point why partial methods can’t have a return type. If you can answer that to your own satisfaction, you can be sure that you fully understand this topic—so that is left as an exercise for you.

EXAMPLE APPLICATION
To illustrate some of the techniques you’ve been using so far, in this section you’ll develop a class module that you can build on and make use of in subsequent chapters. The class module contains two classes:
>	Card—Representing a standard playing card, with a suit of club, diamond, heart, or spade, and a rank that lies between ace and king
>	Deck—Representing a full deck of 52 cards, with access to cards by position in the deck and the capability to shuffle the deck

You’ll also develop a simple client to ensure that things are working, but you won’t use the deck in a full card game application—yet.

Planning the Application
The class library for this application, Ch10CardLib, will contain your classes. Before you get down  to any code, though, you should plan the required structure and functionality of your classes.



















