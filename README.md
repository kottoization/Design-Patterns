# Design-Patterns
Different design patterns in different branches, inplemented in C# <br><br>
Most of the files are in .rar or .zip and they are ment to show basic understandment of those patterns. <br> 
I have wanted to show only the basic understandment, so in most cases the program's operation is limited only to this area. <br><br>
🎓 All the files are either based on a course (udemy.com/course/design-patterns-csharp-dotnet) or are coming from my academic work. 

<br>

# Ambient Context Pattern

The Ambient Context Pattern allows different parts of a program to access important information without needing to pass it around all the time.<br>
It's like having a shared notebook that everyone in a team can refer to. This way, they can work together smoothly without constantly checking with each other. <br>
This pattern is handy when different parts of a program need to know the same things, but they don't want to keep asking for them all the time.<br>
It's like having a common place where everyone can find what they need. The Ambient Context Pattern is useful when a program has a lot of pieces that need to share information in an organized way.<br>
While the Ambient Context Pattern and other Singleton patterns ensure single instances, they differ in their purpose. <br>
The Ambient Context Pattern focuses on providing a shared context for components, allowing them to access relevant information without direct dependencies.<br>
This is particularly useful in scenarios where contextual data is crucial for system behavior. On the other hand, traditional Singleton patterns like the Singleton Pattern and Monostate Pattern primarily concentrate on managing the instantiation of a class to guarantee a single point of access. 
