# C# - WPF - SignalR Real Time Chat Example Application with Unity DI Container. [Year of Development: 2018, 2020, 2021]

About the application technologies and operation:

### Technologies:
- Programming Language: C#
- FrontEnd Side: Windows Presentation Foundation (WPF) - .NET Framework 4.7.2
- BackEnd Side: SignalR ~2.4.1 - .NET Framework 4.7.2
- Other used modul:
    - Unity DI Container        ~ 5.11.11
    - Material Design Temes     ~ 4.0.0
    - Material Design Colors    ~ 2.0.0
    - MahApps.Metro             ~ 2.4.4
    - log4net                   ~ 2.2.12

### Application solution structure:
- **Application.Client**: Includes the FrontEnd Side of the application.
- **Application.Server**: Includes the BackEnd Side of the application.
- **Application.Models**: Includes the Common Models between the BackEnd- and FrontEnd Sides

### Installation/ Configuration:

1. Restore necessary Packages on the selected project, run the following command in **PM Console**

   ```
   Update-Package -reinstall
   ```
     
### About the application:

WPF - SignalR Real Time Chat Example Application that uses SignalR for real-time communication.

SignalR is a library that enables developers to create applications that have real-time communication functionality. 

SignalR is a library that enables developers to create applications that have real-time communication functionality. This functionality makes it suitable for the development of an instant-messaging chat application, like SignalChat, as any new data that is available on the server can immediately be pushed to all or some of the connected clients. With SignalR, connected clients can also be made aware of the connection status of other clients.

#### The application shows the following:
- How to implement **Data Binding** in **WPF**.
- How to use **Modal-View-ViewModel (MVVM)** in **WPF**.
- How to implement **Command Binding** in **WPF** with **ICommand** interface.
- How to implement and use **Unity DI Container**.
- How to **SignalR Chat Client** connects to the **SignalR Chat Server**.
- How to **SignalR Chat Client** logs into the server.
- How to send **Unicast Messages**.
- How to receives **Unicast Messages**.
- How to build **Windows, Views** with **MahApps.Metro** and **Material Design**.
- How to displaying chat messages, connected participants, how to display when a participant receive a new message, etc.
- How to Switching Views with the **ViewNavigator Service**.
- How to use **Application Cache (Default Cache Memory)** with **AppCacheStorage Service**.
- How to register **Unity DI Log4NetExtension** into the **Unity DI Container** and how to use it.
- How to use **Global Exception Handling** in **WPF Application**.
- How to register and use **Unity DI Container** in **SignalR**.
- How to register **Singleton or Transient** services into **Unity DI Container**.
- How to read and use **Configurations** from **app.config** files.
