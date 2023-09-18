local wezterm = require("wezterm")

local config = {}

if wezterm.config_builder then
    config = wezterm.config_builder()
end

config.default_prog = { "powershell.exe" }
config.color_scheme = "Catppuccin Frappe"

config.window_padding = {
    left = 0,
    right = 0,
    top = 0,
    bottom = 0,
}

config.tab_and_split_indices_are_zero_based = true
config.tab_bar_at_bottom = true

config.leader = { key = "g", mods = "CTRL", timeout_milliseconds = 1000 }
config.keys = {
    { key = "%",  mods = "LEADER|SHIFT", action = wezterm.action.SplitHorizontal({ domain = "CurrentPaneDomain" }), },
    { key = "\"", mods = "LEADER|SHIFT", action = wezterm.action.SplitVertical({ domain = "CurrentPaneDomain" }), },
    { key = "c",  mods = "LEADER",       action = wezterm.action.SpawnTab("CurrentPaneDomain") },
    { key = "z",  mods = "LEADER",       action = "TogglePaneZoomState" },
    { key = "[",  mods = "LEADER",       action = wezterm.action.ActivateCopyMode },
    {
        key = "!",
        mods = "LEADER|SHIFT",
        action = wezterm.action_callback(function(win, pane)
            local tab, window =
                pane:move_to_new_tab()
        end),
    },
    { key = "h", mods = "LEADER|CTRL",  action = wezterm.action.ActivatePaneDirection("Left") },
    { key = "j", mods = "LEADER|CTRL",  action = wezterm.action.ActivatePaneDirection("Down") },
    { key = "k", mods = "LEADER|CTRL",  action = wezterm.action.ActivatePaneDirection("Up") },
    { key = "l", mods = "LEADER|CTRL",  action = wezterm.action.ActivatePaneDirection("Right") },
    { key = "H", mods = "LEADER|SHIFT", action = wezterm.action.AdjustPaneSize({ "Left", 5 }) },
    { key = "J", mods = "LEADER|SHIFT", action = wezterm.action.AdjustPaneSize({ "Down", 5 }) },
    { key = "K", mods = "LEADER|SHIFT", action = wezterm.action.AdjustPaneSize({ "Up", 5 }) },
    { key = "L", mods = "LEADER|SHIFT", action = wezterm.action.AdjustPaneSize({ "Right", 5 }) },
    { key = "x", mods = "LEADER",       action = wezterm.action.CloseCurrentPane({ confirm = true }), },
}

for i = 0, 9 do
    table.insert(config.keys, {
        key = tostring(i),
        mods = "LEADER",
        action = wezterm.action.ActivateTab(i),
    })
    table.insert(config.keys, {
        key = tostring(i),
        mods = "LEADER|CTRL",
        action = wezterm.action.MoveTab(i),
    })
end

return config
