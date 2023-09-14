#r "C:\Program Files\workspacer\workspacer.Shared.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.Bar\workspacer.Bar.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.ActionMenu\workspacer.ActionMenu.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.FocusIndicator\workspacer.FocusIndicator.dll"

using System;
using workspacer;
using workspacer.Bar;
using workspacer.Bar.Widgets;
using workspacer.ActionMenu;
using workspacer.FocusIndicator;

Action<IConfigContext> doConfig = (context) =>
{
    var fontSize = 12;
    var barHeight = 24;

    context.Branch = Branch.None;
    context.CanMinimizeWindows = false;

    context.AddBar(new BarPluginConfig()
    {
        FontSize = fontSize,
        BarHeight = barHeight,
        DefaultWidgetForeground = Color.White,
        DefaultWidgetBackground = Color.Black,
        // BarIsTop = false,
        LeftWidgets = () => new IBarWidget[]
        {
            new WorkspaceWidget(),
        },
        RightWidgets = () => new IBarWidget[]
        {
            new TimeWidget(1000, "yyyy-MM-dd HH:mm:ss"),
        }
    });
    context.AddFocusIndicator();
    var actionMenu = context.AddActionMenu();

    context.WorkspaceContainer.CreateWorkspaces("1", "2", "3", "4", "5", "6", "7", "8", "9", "10");

    context.Keybinds.UnsubscribeAll();

    var mod = KeyModifiers.Alt;

    context.Keybinds.Subscribe(MouseEvent.LButtonDown,
            () => context.Workspaces.SwitchFocusedMonitorToMouseLocation());
    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.Q,
            () => context.Workspaces.FocusedWorkspace.CloseFocusedWindow(), "close focused window");

    context.Keybinds.Subscribe(mod, Keys.J,
            () => context.Workspaces.FocusedWorkspace.FocusNextWindow(), "focus next window");
    context.Keybinds.Subscribe(mod, Keys.K,
            () => context.Workspaces.FocusedWorkspace.FocusPreviousWindow(), "focus previous window");
    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.J,
            () => context.Workspaces.FocusedWorkspace.SwapFocusAndNextWindow(), "swap focus and next window");
    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.K,
            () => context.Workspaces.FocusedWorkspace.SwapFocusAndPreviousWindow(), "swap focus and previous window");


    context.Keybinds.Subscribe(mod, Keys.H,
            () => context.Workspaces.FocusedWorkspace.ShrinkPrimaryArea(), "shrink primary area");
    context.Keybinds.Subscribe(mod, Keys.L,
            () => context.Workspaces.FocusedWorkspace.ExpandPrimaryArea(), "expand primary area");

    context.Keybinds.Subscribe(mod, Keys.D1,
            () => context.Workspaces.SwitchToWorkspace(0), "switch to workspace 1");
    context.Keybinds.Subscribe(mod, Keys.D2,
            () => context.Workspaces.SwitchToWorkspace(1), "switch to workspace 2");
    context.Keybinds.Subscribe(mod, Keys.D3,
            () => context.Workspaces.SwitchToWorkspace(2), "switch to workspace 3");
    context.Keybinds.Subscribe(mod, Keys.D4,
            () => context.Workspaces.SwitchToWorkspace(3), "switch to workspace 4");
    context.Keybinds.Subscribe(mod, Keys.D5,
            () => context.Workspaces.SwitchToWorkspace(4), "switch to workspace 5");
    context.Keybinds.Subscribe(mod, Keys.D6,
            () => context.Workspaces.SwitchToWorkspace(5), "switch to workspace 6");
    context.Keybinds.Subscribe(mod, Keys.D7,
            () => context.Workspaces.SwitchToWorkspace(6), "switch to workspace 7");
    context.Keybinds.Subscribe(mod, Keys.D8,
            () => context.Workspaces.SwitchToWorkspace(7), "switch to workspace 8");
    context.Keybinds.Subscribe(mod, Keys.D9,
            () => context.Workspaces.SwitchToWorkspace(8), "switch to workspace 9");
    context.Keybinds.Subscribe(mod, Keys.D0,
            () => context.Workspaces.SwitchToWorkspace(9), "switch to workspace 10");

    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.D1,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(0), "switch focused window to workspace 1");
    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.D2,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(1), "switch focused window to workspace 2");
    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.D3,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(2), "switch focused window to workspace 3");
    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.D4,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(3), "switch focused window to workspace 4");
    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.D5,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(4), "switch focused window to workspace 5");
    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.D6,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(5), "switch focused window to workspace 6");
    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.D7,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(6), "switch focused window to workspace 7");
    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.D8,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(7), "switch focused window to workspace 8");
    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.D9,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(8), "switch focused window to workspace 9");
    context.Keybinds.Subscribe(mod | KeyModifiers.LShift, Keys.D0,
        () => context.Workspaces.MoveFocusedWindowToWorkspace(9), "switch focused window to workspace 10");

    context.Keybinds.Subscribe(mod, Keys.Enter,
            () => System.Diagnostics.Process.Start("wt.exe"));
};
return doConfig;
