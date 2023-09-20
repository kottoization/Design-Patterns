# Design-Patterns
Different design patterns in different branches, inplemented in C# <br><br>
Most of the files are in .rar or .zip and they are ment to show basic understandment of those patterns. <br> 
I have wanted to show only the basic understandment, so in most cases the program's operation is limited only to this area. <br><br>
🎓 All the files are either based on a course (udemy.com/course/design-patterns-csharp-dotnet) or are coming from my academic work. 

<br>

# Pre-Thread Singleton

The Pre-Thread Singleton Pattern is a design pattern that extends the Singleton Pattern to support multiple instances on a per-thread basis. In this pattern, each thread has its own unique instance, ensuring thread-specific data and operations.<br>
It's similar to providing individual workstations in a shared office space, allowing each worker to have their own resources while still benefiting from a communal environment. <br>
The Pre-Thread Singleton Pattern optimizes parallel processing by granting threads exclusive access to their respective instances, enhancing performance in multi-threaded applications.<br>
