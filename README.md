# Design-Patterns
Different design patterns in different branches, inplemented in C# <br><br>
Most of the files are in .rar or .zip and they are ment to show basic understandment of those patterns. <br> 
I have wanted to show only the basic understandment, so in most cases the program's operation is limited only to this area. <br>

# Observer Pattern
The Observer Pattern is a behavioral design pattern that establishes a one-to-many dependency between objects. In this pattern, when one object (known as the subject or publisher) undergoes a change in state, all its dependents (observers or subscribers) are automatically notified and updated accordingly. The primary goal of the Observer Pattern is to define a subscription mechanism to broadcast and propagate changes occurring within an object to other related objects, ensuring loose coupling between them.

At its core, the pattern consists of two key components: the subject (or observable) and the observers. The subject maintains a list of observers and provides methods to add, remove, and notify observers of any state changes. Observers, in turn, implement an update interface or method that allows the subject to notify them of changes.

This design pattern is extensively used in event handling systems, graphical user interfaces (GUIs), and any scenario where changes in one part of the system should trigger updates in other parts without tightly coupling them together. It promotes flexibility, as observers can be added or removed without altering the subject, fostering a more scalable and maintainable system architecture.
