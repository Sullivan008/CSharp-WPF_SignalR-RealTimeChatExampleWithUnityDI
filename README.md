# C# - WPF - SignalR Real Time Chat Example Application with Unity DI Container. [Year of Development: 2018 and 2020]

About the application technologies and operation:

### Technologies:
- Programming Language: C#
- FrontEnd Side: Windows Presentation Foundation (WPF) - .NET Framework 4.7.2
- BackEnd Side: SignalR ~2.4.1 - .NET Framework 4.7.2
- Other used modul:
    - Unity DI Container        ~ 5.6.0
    - Material Design Temes     ~ 3.0.1
    - Material Design Colors    ~ 1.2.2
    - MahApps.Metro             ~ 1.6.5

### Application solution structure:
- **SignalRChatExampleClient**: Includes the FrontEnd Side of the application.
- **SignalRChatExampleServer**: Includes the BackEnd Side of the application.

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
- How to implement **Command Binding** in **UWP** with **ICommand** interface.
- How to implement and use **Unity DI Container** in **WPF**.
- How to **SignalR Chat Client** connects to the **SignalR Chat Server**.
- How to **SignalR Chat Client** logs into the server.
- How to send **Unicast- Broadcast Messages** and send **Unicast Notifications**.
- How to receives **Unicast- Broadcast Messages** or **Notifications**.
- How to build **Windows, Views** with **MahApps.Metro** and **Material Design**.
- How to displaying chat messages, connected participants, how to display when a participant receive a new message, etc.
- How to Switching Views with **ChatModeType Enum** in **App.xaml**.
