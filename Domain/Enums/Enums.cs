namespace DistroHub.Domain.Enums;

public enum DesktopEnv
{
    GNOME = 0, KDE = 1, XFCE = 2, LXDE = 3, Cinnamon = 4,
    MATE = 5, Budgie = 6, Pantheon = 7, None = 8, Other = 9
}

public enum PackageManager
{
    APT = 0, Pacman = 1, DNF = 2, Zypper = 3,
    Portage = 4, Nix = 5, Flatpak = 6, Other = 7
}

public enum InitSystem { Systemd = 0, OpenRC = 1, Runit = 2, SysV = 3, Other = 4 }

public enum Category
{
    General = 0, Beginner = 1, Advanced = 2,
    Privacy = 3, Gaming = 4, Server = 5,
    Education = 6, Minimalist = 7
}

public enum Arch { X86_64 = 0, ARM64 = 1, ARM = 2, i386 = 3, RISCV = 4 }
