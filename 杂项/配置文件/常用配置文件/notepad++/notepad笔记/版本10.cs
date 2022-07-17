9.2.6 多播委托
最初委托仅有一个方法调用。调用委托相当于调用该方法。

如果要调用多个方法，则需要多次通过委托进行显式调用。
	委托可以包装多个方法。这样的委托称为多播委托。
	当调用[ 多播委托]时，它会连续调用看[ 每个委托]
		为此，委托[ 签名]应返回空白; 
		否则，您只能获得委托 调用的最后一个方法的结果 。

可使用void 返回类型，Action<double> delegate

[ 多播委托]-脉络-非[ 多播委托] => 委托数组-存储多个方法
[ 多播委托] => 可以使用 +  与 +=
1·普通+=
Action<double> operations = MathOperations.MultiplyByTwo; 
operations += MathOperations.Square;
2·扩展 +  ==  1·普通+=
Action<double> operation1 = MathOperations.MultiplyByTwo; 
Action<double> operation2 = MathOperations.Square; 
Action<double> operations = operation1 + operation2;
3· – 与 -=  移除委托

多播委托 => 同一委托中-调用其方法链的顺序未正式定义，勿依赖此顺序
多播委托 => 相继调用的委托集合 => 方法之一异常，则迭代停止
    请考虑MulticastIteration 示例。
         无参数、返回void的 简单委托Action 。
             此委托旨在调用方法One 和Two ，
             它们满足此委托的参数和返回类型要求。
请注意方法One 抛出异常

  

class User
{
public string Name { get; set; }

public string Password { get; set; }
}

class UserService
{
public void Register(User user)
{
if (user.Name == "Kirin")
{
Log("注册失败，已经包含名为" + user.Name + "的用户");
}
else
{
Log("注册成功！");
}
}
privte void Log(string message)
{
Console.WriteLine(message);
}
}
UserService 类封装用户登录的逻辑，并根据不同的登录情况向控制台打印不同的日志内容。当程序关闭时，所记录的日志自然也随之消失。

客户端的代码为
class Program
{
static void Main(string[] args)
{
User user = new User { Name = "Kirin", Password = "123" }; UserService service = new UserService(); service.Register(user);
Console.ReadLine();
}
}

使用策略模式

然而这样的设计肯定是无法满足用户的需求的，用户肯定希望能够查看以前的日志记录，而不仅仅是程序打开以后的内容。如果我们仅仅修改 Log 方法的实现，那么用户需求再次改变时我们该如何处理呢？难道要无休止地修改 Log 方法吗？

既然日志记录的方式是变化的根源，我们自然会想到将其进行封装。我们创建一个名为
ILog 的接口。
interface ILog
{
void Log(string message);
}
并创建两个实现了 ILog 的类，ConsoleLog 和 TextLog，分别用来向控制台和文本文件输出日志内容
class ConsoleLog : ILog
{
public void Log(string message)
{
Console.WriteLine(message);
}
}

class TextLog : ILog
{
public void Log(string message)
{
using (StreamWriter sw = File.AppendText("log.txt"))
{
sw.WriteLine(message); sw.Flush();
sw.Close();
}
}
}











