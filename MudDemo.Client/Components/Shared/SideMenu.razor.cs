using Microsoft.AspNetCore.Components;
using MudBlazor;


using MudDemo.Client.Models;
using MudDemo.Client.Models.SideMenu;

namespace MudDemo.Client.Components.Shared;

public partial class SideMenu
{
    private List<MenuSectionModel> _menuSections = new()
    {
        new MenuSectionModel
        {
            Title = "GENERAL",
            SectionItems = new List<MenuSectionItemModel>
            {
                new()
                {
                    Title = "App",
                    Icon = Icons.Material.Filled.Speed,
                    Href = "/"
                },
                new()
                {
                    Title = "E-Commerce",
                    Icon = Icons.Material.Filled.ShoppingCart,
                    Href = "/ecommerce",
                    PageStatus = PageStatus.Completed
                },
                new()
                {
                    Title = "Analytics",
                    Icon = Icons.Material.Filled.Analytics,
                    Href = "/analytics",
                    PageStatus = PageStatus.Completed
                },
                new()
                {
                    Title = "Banking",
                    Icon = Icons.Material.Filled.Money,
                    Href = "/banking",
                    PageStatus = PageStatus.Completed
                },
                new()
                {
                    Title = "Booking",
                    Icon = Icons.Material.Filled.CalendarToday,
                    Href = "/booking",
                    PageStatus = PageStatus.Completed
                }
            }
        },

        new MenuSectionModel
        {
            Title = "MANAGEMENT",
            SectionItems = new List<MenuSectionItemModel>
            {
                new()
                {
                    IsParent = true,
                    Title = "User",
                    Icon = Icons.Material.Filled.Person,
                    MenuItems = new List<MenuSectionSubItemModel>
                    {
                        new()
                        {
                            Title = "Profile",
                            Href = "/user/profile",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Cards",
                            Href = "/user/cards",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "List",
                            Href = "/user/list",
                            PageStatus = PageStatus.Completed
                        }
                    }
                },
                new()
                {
                    IsParent = true,
                    Title = "Article",
                    Icon = Icons.Material.Filled.Article,
                    MenuItems = new List<MenuSectionSubItemModel>
                    {
                        new()
                        {
                            Title = "Posts",
                            Href = "/user/posts",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "Post",
                            Href = "/user/post",
                            PageStatus = PageStatus.Completed
                        },
                        new()
                        {
                            Title = "New Post",
                            Href = "/user/newpost",
                            PageStatus = PageStatus.Completed
                        }
                    }
                }
            }
        }
    };

    [EditorRequired] [Parameter] public bool SideMenuDrawerOpen { get; set; }
    [EditorRequired] [Parameter] public EventCallback<bool> SideMenuDrawerOpenChanged { get; set; }
    [EditorRequired] [Parameter] public bool CanMiniSideMenuDrawer { get; set; }
    [EditorRequired] [Parameter] public EventCallback<bool> CanMiniSideMenuDrawerChanged { get; set; }
    [EditorRequired] [Parameter] public UserModel User { get; set; }
}