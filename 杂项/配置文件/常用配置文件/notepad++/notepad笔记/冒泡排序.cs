1.1 C#中的泛型
对冒泡排序不熟悉的读者，可以放心地忽略上面代码的方法体，它不会对你理解泛型造成丝毫的障碍，你只要知道它所实现的功能就可以了：将一个数组的元素按照从小到大的顺序重新排列。
======================================================
	
public class SortHelper{
    public void BubbleSort(int[] array) {
        int length = array.Length;

        for (int i = 0; i <= length - 2; i++) {
            for (int j = length - 1; j >= 1; j--) {

                // 对两个元素进行交换
                if (array[j] < array[j - 1] ) {
                    int temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;    
                }
            }
        }
    }
}

class Program {
    static void Main(string[] args) {
        SortHelper sorter = new SortHelper();
        
        int[] array = { 8, 1, 4, 7, 3 };

        sorter.BubbleSort(array);

        foreach(int i in array){
            Console.Write("{0} ", i);
        }

        Console.WriteLine();
        Console.ReadKey();
    }
}
输出为：

1 3 4 7 8



///int
public class SortHelper {
    public void BubbleSort(int[] array) {
        int length = array.Length;

        for (int i = 0; i <= length - 2; i++) {
            for (int j = length - 1; j >= 1; j--) {

                // 对两个元素进行交换
                if (array[j] < array[j - 1]) {
                    int temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                }
            }
        }
    }

///byte
    public void BubbleSort(byte[] array) {
        int length = array.Length;

        for (int i = 0; i <= length - 2; i++) {
            for (int j = length - 1; j >= 1; j--) {

                // 对两个元素进行交换
                if (array[j] < array[j - 1]) {
                    int temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                }
            }
        }
    }
}

///泛型的引入
public void BubbleSort(int[] array)
public void BubbleSort(byte[] array)
public void BubbleSort(char[] array)




public class SortHelper<T> {
	
    public void BubbleSort(T[] array) {
    int length = array.Length;

    for (int i = 0; i <= length - 2; i++) {
        for (int j = length - 1; j >= 1; j--) {

            // 对两个元素进行交换
            if (array[j] < array[j - 1]) {
                T temp = array[j];
                array[j] = array[j - 1];
                array[j - 1] = temp;
            }
        }
    }
}
}

///直接调用就行

SortHelper<int> sorter = new SortHelper<int>();
int[] array = { 8, 1, 4, 7, 3 };
sorter.BubbleSort(array);

///直接调用就行
SortHelper<byte> sorter = new SortHelper<byte>();
byte [] array = { 8, 1, 4, 7, 3 };
sorter.BubbleSort(array);

1.1.2 类型参数约束

public class Book {
    private int id;
    private string title;

    public Book() { }

    public Book(int id, string title) {
        this.id = id;
        this.title = title;
    }

    public int Id {
        get { return id; }
        set { id = value; }
    }

    public string Title {
        get { return title; }
        set { title = value; }
    }
}

一个Book类型的数组，然后试着使用上一小节定义的泛型类来对它进行排序
Book[] bookArray = new Book[2];

Book book1 = new Book(124, ".Net之美");
Book book2 = new Book(45, "C# 3.0揭秘");

bookArray[0] = book1;
bookArray[1] = book2;

SortHelper<Book> sorter = new SortHelper<Book>();
sorter.BubbleSort(bookArray);

foreach (Book b in bookArray) {
    Console.WriteLine("Id:{0}", b.Id);
    Console.WriteLine("Title:{0}\n", b.Title);
}



public void BubbleSort(T[] array) {
    int length = array.Length;

    for (int i = 0; i <= length - 2; i++) {
        for (int j = length - 1; j >= 1; j--) {

            // 对两个元素进行交换
            if (array[j] < array[j - 1]) {
                T temp = array[j];
                array[j] = array[j - 1];
                array[j - 1] = temp;
            }
        }
    }
}

实现比较的基本方法是实现IComparable接口，它有泛型版本和非泛型两个版本
排序 --> 比较大小

//非泛型版本
public interface IComparable {
    int CompareTo(object obj);
}
//非泛型版本 --> 比较两个book1与book2
book1.CompareTo(book2);
如果book1比book2小，返回一个 小于0的整数；
如果book1与book2相等，		  返回0；
如果book1比book2大，返回一个 大于0的整数。

Book类来实现IComparable接口
public class Book :IComparable {
    private int id;
    private string title;

    public Book() { }

    public Book(int id, string title) {
        this.id = id;
        this.title = title;
    }

    public int Id {
        get { return id; }
        set { id = value; }
    }

    public string Title {
        get { return title; }
        set { title = value; }
    }

    public int CompareTo(object obj) {
        Book book2 = (Book)obj;
        return this.Id.CompareTo(book2.Id);
    }
}


public class SortHelper<T>where T:IComparable { //--> 限定：类型参数T必须实现IComparable接口 
	
    public void BubbleSort(T[] array) {
    int length = array.Length;

    for (int i = 0; i <= length - 2; i++) {
        for (int j = length - 1; j >= 1; j--) {

            // 对两个元素进行交换
            if (array[j] < array[j - 1]) {
                T temp = array[j];
                array[j] = array[j - 1];
                array[j - 1] = temp;
            }
        }
    }
}
}

Book[] bookArray = new Book[2];

Book book1 = new Book(124, ".Net之美");
Book book2 = new Book(45, "C# 3.0揭秘");

bookArray[0] = book1;
bookArray[1] = book2;

SortHelper<Book> sorter = new SortHelper<Book>();
sorter.BubbleSort(bookArray);

foreach (Book b in bookArray) {
    Console.WriteLine("Id:{0}", b.Id);
    Console.WriteLine("Title:{0}\n", b.Title);
}


此时我们再次运行上面定义的代码，会看到下面的输出：

Id:45
Title:.Net之美

Id:124
Title:C# 3.0揭秘


1.1.3 泛型方法

public class SuperCalculator {
    public int SuperAdd(int x, int y) {
        return 0;
    }

    public int SuperMinus(int x, int y) {
        return 0;
    }

    public string SuperSearch(string key) {
        return null;
    }

    public void SuperSort(int[] array) {
    }
}



public class SuperCalculator<T> where T:IComparable {
    // CODE：略

    public void SpeedSort(T[] array) {      
        // CODE：实现略
    }
}



反射

      public class RefClass
      {
          private int _test3;
          private int _test1 { get; set; }
          protected int Test2 { get; set; }
          public int Test3 { get; set; }

          public void Show()
          {

          }
      }


	  ///细心的读者一定会发现这里的输出并没有包含private和protected访问权限的成员。这就应了上面的那句话：GetMembers默认返回公开的成员。
   static void Main(string[] args)
       {
           Type t = typeof(RefClass);
           MemberInfo[] minfos = t.GetMembers();
           foreach (MemberInfo minfo in minfos)
           {
               Console.WriteLine(minfo.Name);
           }
           Console.ReadKey();
       }



///查看非公开代码
     static void Main(string[] args)
         {
             Type t = typeof(RefClass);
             MemberInfo[] minfos = t.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public );//分别是“包含非公开”、“包含实例成员”和“包含公开”
             foreach (MemberInfo minfo in minfos)
             {
                 Console.WriteLine(minfo.Name);
             }
             Console.ReadKey();
         }
 --> 发现属性很多，而且还包含了大量的父类中的属性，假设我们只关注该类中的成员，并不关注父类中的成员该如何做呢？		 
 -->  --> 其实我们只需要加上一个枚举类型（BindingFlags.DeclaredOnly）：
/*
BindingFlags.NonPublic 					“包含非公开”
BindingFlags.Instance 					“包含实例成员”
BindingFlags.Public 						“包含公开”
BindingFlags.DeclaredOnly			    只关注该类成员
BindingFlags.Static					    静态成员
*/

MemberInfo[] minfos = t.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly );

/////////-////////////////*/*/*/*/*/*/*/*/*/*/*//////*///////////////////////////////////
下面我们在RefClass类中添加两个静态方法，如下所示：

 public class RefClass
        {
            private int _test3;
            private int _test1 { get; set; }
            protected int Test2 { get; set; }
            public int Test3 { get; set; }

            private static void Show2()
            {
            }

            public static void Show3()
            {
            }

            public void Show()
            {

            }
        }
可以发现最终的结果并没有输出这些静态成员。这个时候我们只需要在GetMembers中加上一个枚举：BindingFlags.Static即可。

  static void Main(string[] args)
        {
            Type t = typeof(RefClass);
            Func<MemberTypes, String> getType = (x) =>
            {
                switch (x)
                {
                    case MemberTypes.Field:
                        {
                            return "字段";
                        }
                    case MemberTypes.Method:
                        {
                            return "方法";
                        }
                    case MemberTypes.Property:
                        {
                            return "属性";
                        }
                    default:
                        {
                            return "未知";	
                        }
                }
            };
            MemberInfo[] minfos = t.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Static );
            foreach (MemberInfo minfo in minfos)
            {
                Console.WriteLine(minfo.Name + ";类型:" + getType(minfo.MemberType));
            }
            Console.ReadKey();
        }





       static void Main(string[] args)
       {
           Type t = typeof(RefClass);
           FieldInfo[] finfos = t.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
           foreach (FieldInfo finfo in finfos)
           {
               Console.WriteLine("字段名称：{0}  字段类型:{1} ", finfo.Name, finfo.FieldType.ToString());
           }
           Console.ReadKey();
       }
	   
	   一直到这里大家都会认为我们仅仅只是分析，感觉没有什么实质的东西，下面就来点实质的东西，你可以看到_test3、_test1和Test2是私有和保护类型，

是不可以获取到它们的值的，但是我们通过反射却可以，具体的代码如下所示：
    static void Main(string[] args)
        {
            Type t = typeof(RefClass);
            RefClass rc = new RefClass();
            rc.Test3 = 3;
            FieldInfo[] finfos = t.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (FieldInfo finfo in finfos)
            {
                Console.WriteLine("字段名称：{0}  字段类型:{1} rc中的值为:{2}", finfo.Name, finfo.FieldType.ToString(), finfo.GetValue(rc));
            }
            Console.ReadKey();
        }

























