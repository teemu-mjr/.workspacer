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

config.leader = { key = "g", mods = "CTRL", timeout_milliseconds = 1000 }
config.keys = {
    {
        key = "%",
        mods = "LEADER|SHIFT",
        action = wezterm.action.SplitHorizontal({ domain = "CurrentPaneDomain" }),
    },
    {
        key = "\"",
        mods = "LEADER|SHIFT",
        action = wezterm.action.SplitVertical({ domain = "CurrentPaneDomain" }),
    },
    {
        key = "x",
        mods = "LEADER",
        action = wezterm.action.CloseCurrentPane({ confirm = true }),
    },
    {
        key = "[",
        mods = "LEADER",
        action = wezterm.action.ActivateCopyMode
    },
    {
        key = "!",
        mods = "LEADER|SHIFT",
        action = wezterm.action_callback(function(win, pane)
            local tab, window = pane:move_to_new_tab()
        end),
    },
    {
        key = "h",
        mods = "LEADER|CTRL",
        action = wezterm.action.ActivatePaneDirection "Left",
    },
    {
        key = "j",
        mods = "LEADER|CTRL",
        action = wezterm.action.ActivatePaneDirection "Down",
    },
    {
        key = "k",
        mods = "LEADER|CTRL",
        action = wezterm.action.ActivatePaneDirection "Up",
    },
    {
        key = "l",
        mods = "LEADER|CTRL",
        action = wezterm.action.ActivatePaneDirection "Right",
    },
}

for i = 1, 9 do
    table.insert(config.keys, {
        key = tostring(i),
        mods = "LEADER",
        action = wezterm.action.ActivateTab(i - 1),
    })
    table.insert(config.keys, {
        key = tostring(i),
        mods = "LEADER|CTRL",
        action = wezterm.action.MoveTab(i - 1),
    })
end

return config
