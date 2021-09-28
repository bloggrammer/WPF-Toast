![GitHub](https://img.shields.io/github/license/Blogrammer/WPF-Toast?logo=github) [![NuGet](https://img.shields.io/nuget/v/WPF-Toast?)](https://www.nuget.org/packages/WPF-Toast?/) ![Nuget](https://img.shields.io/nuget/dt/WPF-Toast??logo=nuget)


# WPF-Toast

Show Toast Notifications in WPF Applications

# Demo-App:
## Positioning and timeout demo
![demo gif](doc/Demo-Gif.gif)

## Theming demo
  Theming the Toast is very easy. Simply create colors for these resource names in your app.xaml or any global resource dictionary:
  
  ```
        <SolidColorBrush x:Key="ToastCloseButtonBackground">#ff0</SolidColorBrush>
        <SolidColorBrush x:Key="ToastCloseButtonForeground">#9f1300</SolidColorBrush>
        <SolidColorBrush x:Key="ToastBackground">#f0f</SolidColorBrush>
        <SolidColorBrush x:Key="ToastBorderBrush">#0f0</SolidColorBrush>
        <SolidColorBrush x:Key="ToastContentForeground">#f90</SolidColorBrush>
        <SolidColorBrush x:Key="ToastHeaderBackground">#769</SolidColorBrush>
  ```

The toast controls will automatically bind to it. You can also change them at runtime.
![theme gif](doc/toast.gif)

## How to Show Toast Notifications in Your Next WPF Apps

Windows Toast Notifications (or simply Toasts) are flat notifications that pop up in the bottom right corner of your screen and can be accessed through the Windows Action Center. You can incorporate these notifications in your next Windows Presentation Foundation app by using this WPF-Toast control.

To see toasts in action, launch the "[DemoApp](https://github.com/Blogrammer/WPF-Toast/tree/main/WPF-Toast/WPF.Toast/DemoApp)" and click on any of the displayed buttons.

![demo app](doc/demo-app.PNG)

**WPF Toast Notification offers two notification control.**

| Toast Control  | Descriptions                                                                                                                              |
| -------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `ToastContent` | Allows you to display simple text notifications to users. The notification fades off after `0:0:1.5` time interval.                       |
| `ToastAction`  | Allows you to display text and visual elements on the screen. It provides reminder functionality for the user to snooze the notification. |


**Control Properties**

| Properties  | Descriptions                                                                                                                              |
| -------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `NotificationMessage` | This is the message displayed to the user. For `ToastAction`, you can completely customize the appearance by setting the `Content` property (see demo app)                       |
| `Position`  | Allows to position the toast notification at different locations on the screen or parent control. |
| `PositionReference` | Sets the reference of the positioning to either screen or parent control  |

![demo app](doc/toast-content.PNG)

_Toast Content_

![demo app](doc/toast-action.PNG)

_Toast Action_

## Contributions

The WPF Toast still requires little touches and exposing of some members for client's customisation. Please, feel free to contribute to the project.

See: [How to Contribute on GitHub](https://www.dataschool.io/how-to-contribute-on-github/)
