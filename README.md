# FantasyMVVM

> FantasyMVVM是一个针对MAUI而设计的MVVM模式框架。当前是预览版。可能会有未知的bug。正式项目中谨慎使用！！！

该框架仿照WPF的PRISM框架而编写，包含了视图注册，导航，Region注册等。当前适配的是MAUI的preview 的最新版本。

## Getting Started 使用指南

### 使用条件

项目基于MAUI （最新）版本开发，您可能需要保证您的MAUI是.net7

### 安装

您可以使用nuget进行下载

   ```
   Install-Package FantasyMvvm
   ```

### 使用

1. 在MauiProgram.cs文件中添加

```c#
builder.UseFantasyApplication().UseGetProvider();
```


2. 在App.xaml.cs文件中更换App基类

```c#
public partial class App : FantasyBootStarter
```

3. 在App.xaml中修改如下

```c#
 <local:FantasyBootStarter xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
                               xmlns:local="clr-namespace:FantasyMvvm;assembly=FantasyMvvm"
```

4. 使用扩展方式 UseRegisterPage 注册您的Page和PageView。如果是页面PageModel应该继承 FantasyPageModelBase 
  如果是ViewModel应该继承 FantasyViewModelBase

```c#
builder.UseRegisterPage<MainPage,MainPageModel>("MainPage");
builder.UseRegisterPage<SecondPage, SecondPageModel>("SecondPage");
builder.UseRegisterView<TitleView, TitleViewModel>("TitleView");
```

5. 在您的App.xaml.cs文件中设置启动页面

```c#
protected override string CreateShell()
{
    return "MainPage";
}
```

### Usage example 使用示例

#### 属性绑定

属性绑定采用微软的 Microsoft.Toolkit.Mvvm 。因此您可以使用如下语法：

```c#
private string _title;
public string title
{
    get { return _title; }
    set { _title = value; OnPropertyChanged(); }
}
```

#### 命令绑定

命令绑定采用微软的 `CommunityToolkit.Mvvm`。因此您可以使用如下语法：

```c#
[ICommand]
public void Next()
{
 //todo
}
```
#### 页面注册

FantasyMvvm的页面注册可以自动化绑定PageModel，当然，这需要您进行手动配置。您可以使用扩展方法`public static MauiAppBuilder UseRegisterPage<P, PM>(this MauiAppBuilder builder,string name)`来进行注册。示例如下：

```c#    
builder.UseRegisterPage<MainPage,MainPageModel>("MainPage");
builder.UseRegisterPage<SecondPage, SecondPageModel>("SecondPage");
```
UseRegisterPage 需要您传递一个string类型的变量，该变量的作用是让你给你的页面命名，未来导航的时候您可以根据命名来切换页面。
            
### 视图注册

视图是应用于页面的小组件，一个页面中可能会有多个视图，注册一个视图非常简单，和页面注册一样，不过，您使用的是`public static MauiAppBuilder UseRegisterView<V, VM>(this MauiAppBuilder builder, string name)`扩展方法。示例如下：

```c#
builder.UseRegisterView<TitleView, TitleViewModel>("TitleView");
```

UseRegisterView 需要您传递一个string类型的变量，该变量的作用是让你给你的视图命名，未来切换视图时候您可以根据命名来切换。

#### 页面保持

如果您期望您的页面在切换到其他页面后在切换回来的时候，数据不会被重新生成，您可以在你的PageModel中继承`IPageKeep`接口，该接口非常简单，只有一个bool类型的变量 Keep，如果您设置Keep变量为true，则会保持页面。

#### 导航

导航功能用于切换页面，如要使用导航，您可以在PageModel或者ViewModel中注入 INavigationService 

INavigationService 提供了导航的两个方法，分别是

```c#
Task NavigationToAsync(string pageName, bool hasBackButton = true, INavigationParameter parameter = null);
Task NavigationToAsync(string pageName, INavigationParameter parameter = null);
```

pageName:要跳转的页面名称

**hasBackButton**：默认是true，表示顶部会有一个返回上一个页面的按钮，通常情况下，建议都是true.但是当您使用登录页面的时候，登录成功后您不希望用户点击回退或者其他方式在返回登陆页面，您可以设置为false。注意，一旦您设置为false，会清空所有页面。

**parameter**:导航参数，您在跳转页面的时候可以传递参数给下一个页面。

#### Region视图

除了Page页面，还有一种叫做View的视图，视图就像是一个页面的组件，可以在一个页面中放置多个视图。每个页面都需要一个类似占位符的东西来标注自己可以放置视图。

##### 如何放置region（占位符）:

在您的页面文件中(xaml文件)添加命名空间

```c#
xmlns:fanasy="clr-namespace:FantasyMvvm.FantasyAttachProp;assembly=FantasyMvvm"
```

添加一个ContentView控件

```c#
<ContentView fanasy:FantasyRegion.Region="ImageRegion"/>
```

FantasyRegion.Region="ImageRegion" 告知应用生成一个叫做ImageRegioin的占位符。

##### 如何使用region（占位符）:

在PageModel中注入 IRegionManager 接口，该接口只有一个方法：

```c#
void SetRegionView(string regionName,string viewName);
```

regionName:占位符名称，即上文中的ImageRegion

viewName:视图名称

#### 导航传参

如果PageModel需要接收上一个页面的参数，您需要让您的PageModel实现 `INavigationAware`

该接口需要您实现两个方法

```c#
public void OnNavigatedTo(string source, INavigationParameter parameter);

public void OnNavigatedFrom(string source,INavigationParameter parameter);
```

**source**: 上一个页面的名称

**parameter**: 通过parameter您可以获得上一个页面传递的参数。



## Contributing 贡献指南


## Release History 版本历史


## License 授权协议

这个项目 MIT 协议， 请点击 [LICENSE](LICENSE) 了解更多细节。
