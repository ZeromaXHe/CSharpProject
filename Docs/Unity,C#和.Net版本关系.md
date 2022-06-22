# 一、Unity各版本对应C#版本的支持

| Unity版本    | C# 语言版本   |
| ------------ | ------------- |
| Unity 2020.2 | C# 8          |
| Unity 2018.3 | C# 7.3        |
| Unity 2018.2 | C# 7.2        |
| Unity 2017.1 | C# 6 .Net 4.6 |
| Unity 5.5    | C# 4.0        |

# 二、C# 语言版本控制，.net目标框架对应C#版本的支持

| 目标框架及版本      | C# 语言版本的默认值 |
| ------------------- | ------------------- |
| .NET 6.x            | C# 10.0             |
| .NET 5.x            | C# 9.0              |
| .NET Core 3.x       | C# 8.0              |
| .NET Core 2.1，2.2  | C# 7.3              |
| .NET Standard 2.1   | C# 8.0              |
| .NET Standard 2.0   | C# 7.3              |
| .NET Standard 1.x   | C# 7.3              |
| .NET Framework 全部 | C# 7.3              |

更详细的参考：[C#版本与.NET版本对应关系](https://www.cnblogs.com/webapi/p/15204940.html)

| C#版本 | .NET版本                 | 发布日期   | 特性                                                         |
| :----- | :----------------------- | :--------- | :----------------------------------------------------------- |
| C# 1.0 | .NET Framework 1.0       | 2002-02-13 | 委托、事件                                                   |
| C# 1.1 | .NET Framework 1.1       | 2003-04-24 | APM（异步编程模型）                                          |
| C# 2.0 | .NET Framework 2.0       | 2005-11-07 | 泛型、匿名方法、迭代器、可空类型                             |
| C# 3.0 | .NET Framework 3.0       | 2007-11-06 | 隐式类型                                                     |
|        | .NET Framework 3.5       | 2007-11-19 | 对象集合初始化、自动实现属性、匿名类型、扩展方法、查询表达式、Lambda表达式、 表达式树、分部类和方法、Linq |
| C# 4.0 | .NET Framework 4.0       | 2010-04-12 | 动态绑定、命名和可选参数、泛型的协变和逆变、互操作性,最高支持MVC4.0+EF5，vs2010 |
| C# 5.0 | .NET Framework 4.5       | 2012-08-15 | 异步和等待(async和await)、调用方信息(Caller Information)，最高支持mvc5.0+EF6，vs2013 |
| C# 6.0 | .NET Framework 4.6       | 2015-07-20 | 静态导入、[C# 6 中的新增功能](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-60) vs2015 |
|        | .NET Core 1.0            | 2016-06-27 | asp.net mvc core1                                            |
| C# 7.0 | .NET Framework 4.6.2     | 2016-08-02 | 元组、[C# 7.0 中的新增功能](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-70) 最低系统要求Windows Server 2008 SP2，vs2017 |
| C# 7.1 | .NET Framework 4.7       | 2017-04-05 | vs2017 version15.3+                                          |
|        | .NET Core 2.0            | 2016-08-14 | [.NET Core 2.0 的新增功能](https://docs.microsoft.com/zh-cn/dotnet/core/whats-new/dotnet-core-2-0) |
| C# 7.2 | .NET Framework 4.7.1     | 2017-10-17 | vs2017 version15.5+                                          |
| C# 7.3 | **.NET Framework 4.7.2** | 2018-04-30 | **vs2017 version15.7+**                                      |
|        | .NET Core 2.1            | 2018-05-30 | [.NET Core 2.1 的新增功能](https://docs.microsoft.com/zh-cn/dotnet/core/whats-new/dotnet-core-2-1) |
|        | .NET Core 2.2            | 2018-12-04 | [.NET Core 2.2 的新增功能](https://docs.microsoft.com/zh-cn/dotnet/core/whats-new/dotnet-core-2-2) |
| C# 8.0 | .NET Framework 4.8       | 2019-04-18 | [C# 8.0 中的新增功能](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-8) |
|        | .NET Core 3.0            | 2019-09-23 | [.NET Core 3.0 的新增功能](https://docs.microsoft.com/zh-cn/dotnet/core/whats-new/dotnet-core-3-0) |
|        | .NET Core 3.1            | 2019-12-03 | [.NET Core 3.1 的新增功能](https://docs.microsoft.com/zh-cn/dotnet/core/whats-new/dotnet-core-3-1) |
| C# 9.0 | .NET 5                   | 2020-09-04 | [C# 9.0 中的新增功能](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-9)  不再支持asp.net webform、wcf，必须使用vs 预览版 Visual Studio 2019 (v16.6) |
|        | .NET 5                   | 2020-10-13 | [What's new in .NET 5](https://docs.microsoft.com/zh-cn/dotnet/core/dotnet-five) |

# 三、Unity各版本及更新日志

[Unity各版本及更新日志](https://unity3d.com/get-unity/download/archive?_ga=2.25761725.1679819441.1582013610-1036800715.1555637915)（需要翻墙）

# 四、C#各版本新增特性

[官方文档：C# 7.0 - 7.3 中的新增功能](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-70)
[官方文档：C# 8.0 中的新增功能](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-8)
[官方文档：C# 9.0 中的新增功能](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-9)
[官方文档：C# 10.0 中的新增功能](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-10)

# 五、其他：

这里看到一个全网转发量比较高的一篇博文，也记录一下
[Unity各版本C#支持情况](https://blog.csdn.net/t163361/article/details/107266702/)

## Unity和C#对应关系

[Unity 2021.2 C#9](https://docs.unity3d.com/2021.2/Documentation/Manual/CSharpCompiler.html)

以下功能不支持

- Suppress emitting localsinit flag
- Covariant return types
- Module Initializers
- Extensible calling conventions for unmanaged function pointers

[Unity 2020.2 C#8](https://docs.unity3d.com/2020.3/Documentation/Manual/CSharpCompiler.html)

以下功能不支持

- Default interface methods
- Indices and ranges
- Asynchronous streams
- Asynchronous disposable

[Unity 2018.3 C#7.3](https://docs.unity3d.com/2018.3/Documentation/Manual/CSharpCompiler.html)

Unity 2018.2 C#7.2

Unity 2017.1 C#6 .Net 4.6

Unity 5.5 C#4.0

## C#特性

[C#10.0特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-10)

.NET 6 支持 C# 10

- Record structs:记录结构
- Improvements of structure types:结构类型的改进
- Interpolated string handlers:内插字符串处理程序
- global using directives:global using 指令
- File-scoped namespace declaration:文件范围的命名空间声明
- Extended property patterns:扩展属性模式
- Improvements on lambda expressions:对 Lambda 表达式的改进
- Allow const interpolated strings:可使用 const 内插字符串
- Record types can seal ToString():记录类型可密封 ToString()
- Improved definite assignment:改进型明确赋值
- Allow both assignment and declaration in the same deconstruction:在同一析构中可同时进行赋值和声明
- Allow AsyncMethodBuilder attribute on methods:可在方法上使用 AsyncMethodBuilder 属性
- CallerArgumentExpression attribute:CallerArgumentExpression 属性
- Enhanced #line pragma:增强的 #line pragma

[C#9.0新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-9)

.Net5支持C#9.0

- Records:记录
- Init only setters:仅限 Init 的资源库
- Top-level statements:顶级语句
- Pattern matching enhancements:模式匹配增强功能
- Performance and interop:性能和互操作性
- Native sized integers:本机大小的整数
- Function pointers:函数指针
- Suppress emitting localsinit flag:禁止发出 localsinit 标志
- Fit and finish features:调整和完成功能
- Target-typed new expressions:目标类型的 new 表达式
- static anonymous functions:static 匿名函数
- Target-typed conditional expressions:目标类型的条件表达式
- Covariant return types:协变返回类型
- Extension GetEnumerator support for foreach loops:扩展 GetEnumerator 支持 foreach 循环
- Lambda discard parameters:Lambda 弃元参数
- Attributes on local functions:本地函数的属性
- Support for code generators:支持代码生成器
- Module initializers:模块初始值设定项
- New features for partial methods:分部方法的新功能

[C#8.0新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-8)

- Readonly members:Readonly 成员
- Default interface methods:默认接口方法
- Pattern matching enhancements:模式匹配增强功能
- Switch expressions:Switch 表达式
- Property patterns:属性模式
- Tuple patterns:元组模式
- Positional patterns:位置模式
- Using declarations:Using 声明
- Static local functions:静态本地函数
- Disposable ref structs:可处置的 ref 结构
- Nullable reference types:可为空引用类型
- Asynchronous streams:异步流
- Asynchronous disposable:异步可释放
- Indices and ranges:索引和范围
- Null-coalescing assignment:Null 合并赋值
- Unmanaged constructed types:非托管构造类型
- Stackalloc in nested expressions:嵌套表达式中的 Stackalloc
- Enhancement of interpolated verbatim strings:内插逐字字符串的增强功能
- Obsolete on property accessors：属性访问器已经过时

[C#7.3新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-73)

- System.Enum, System.Delegate and unmanaged constraints：泛型约束，枚举、委托和非托管
- Ref local re-assignment：现在可以使用ref分配运算符（= ref）重新分配 Ref locals和ref参数。
- Stackalloc initializers：现在可以初始化堆栈分配的数组
- Indexing movable fixed buffers：索引可移动固定缓冲区
- Custom fixed statement：自定义fixed语句
- Improved overload candidates：改进重载候选项
- Expression variables in initializers and queries：初始化和查询中的表达式变量
- Tuple comparison：元组比较
- Attributes on backing fields：后备字段属性

[C#7.2新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-72)

- Span and ref-like types ref-like类型的编译安全规则
- In parameters and readonly references：值类型的引用语法
- Ref conditional：条件ref
- Non-trailing named arguments：不在尾部的指定名字参数
- Private protected accessibility：访问修饰符
- Digit separator after base specifier：前缀数字(非十进制)分割

[C#7.1新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-71)

- Async main：异步Main方法
- Default expressions：默认表达式
- Reference assemblies：参考程序集
- Inferred tuple element names：推断元组元素名称
- Pattern-matching with generics：泛型的模式匹配

[C#7.0新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-70)

- Out variables：out变量直接声明，例如可以out in parameter
- Pattern matching：模式匹配，根据对象类型或者其它属性实现方法派发
- Tuple 元组
- Deconstruction：元组解析
- Discards：舍弃
- Local Functions：本地函数
- Binary Literals：二进制文字
- Digit Separators：数字分隔符
- Ref returns and locals：Ref返回和临时变量
- Generalized async return types：异步返回类型的广泛支持
- More expression-bodied members：更多表达式化的成员体
- Throw expressions：抛出表达式

[C#6.0新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-60)

- Draft Specification online
- Compiler-as-a-service (Roslyn)
- Import of static type members into namespace：支持仅导入类中的静态成员
- Exception filters：异常过滤器
- Await in catch/finally blocks：支持在catch/finally语句块使用await语句
- Auto property initializers：自动属性初始化
- Default values for getter-only properties：设置只读属性的默认值
- Expression-bodied members：支持以表达式为主体的成员方法和只读属性
- Null propagator (null-conditional operator, succinct null checking)：Null条件操作符
- String interpolation：字符串插值，产生特定格式字符串的新方法
- nameof operator：nameof操作符，返回方法、属性、变量的名称
- Dictionary initializer：字典初始化

[C#5.0新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-50)

- Asynchronous methods 异步方法
- Caller info attributes：调用时访问调用者的信息
- foreach loop was changed to generates a new loop variable rather than closing over the same 
- variable every time

[C#4新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-40)

- Dynamic binding:动态绑定
- Named and optional arguments：命名参数和可选参数
- Generic co- and contravariance：泛型的协变和逆变
- Embedded interop types (“NoPIA”)：开启嵌入类型信息，增加引用COM组件程序的中立性

[C#3新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-30)

- Implicitly typed local variables
- Object and collection initializers
- Auto-Implemented properties
- Anonymous types
- Extension methods
- Query expressions, a.k.a LINQ (Language Integrated Query)
- Lambda expression
- Expression trees
- Partial methods
- Lock statement

[C#2新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-20)

- Generics
- Partial types
- Anonymous methods
- Iterators, a.k.a yield statement
- Nullable types
- Getter/setter separate accessibility
- Method group conversions (delegates)
- Static classes
- Delegate inference
- Type and namespace aliases
- Covariance and contravariance

[C#1.2新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-12)

- Dispose in foreach
- foreach over string specialization

[C#1特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-version-history#c-version-10)

- Classes
- Structs
- Enums
- Interfaces
- Events
- Operator overloading
- User-defined conversion operators
- Properties
- Indexers
- Output parameters (out and ref)
- params arrays
- Delegates
- Expressions
- using statement
- goto statement
- Preprocessor directives
- Unsafe code and pointers
- Attributes
- Literals
- Verbatim identifier
- Unsigned integer types

# 参考文档

1. 版权声明：《Unity各版本对C#版本的支持》为CSDN博主「少侠Smile丶」的原创文章，遵循CC 4.0 BY-SA版权协议，转载请附上原文出处链接及本声明。
   原文链接：https://blog.csdn.net/smile_Ho/article/details/119946986
2. C#版本与.NET版本对应关系 (链接：https://www.cnblogs.com/webapi/p/15204940.html)
3. 版权声明：《Unity各版本C#支持情况》为CSDN博主「听星」的原创文章，遵循CC 4.0 BY-SA版权协议，转载请附上原文出处链接及本声明。
   原文链接：https://blog.csdn.net/t163361/article/details/107266702/