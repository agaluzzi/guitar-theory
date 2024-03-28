using Color = System.Drawing.Color;

namespace GuitarTheory.UI.Support;

/// <summary>
/// These colors were borrowed from https://mobileui.github.io/#colors
/// </summary>
public static class Palette
{
    public static readonly Hue Red = new(
        Color.FromArgb(255, 205, 210),
        Color.FromArgb(239, 154, 154),
        Color.FromArgb(229, 115, 115),
        Color.FromArgb(239, 83, 80),
        Color.FromArgb(244, 67, 54),
        Color.FromArgb(229, 57, 53),
        Color.FromArgb(211, 47, 47),
        Color.FromArgb(198, 40, 40),
        Color.FromArgb(183, 28, 28)
    );

    public static readonly Hue Pink = new(
        Color.FromArgb(248, 187, 208),
        Color.FromArgb(244, 143, 177),
        Color.FromArgb(240, 98, 146),
        Color.FromArgb(236, 64, 122),
        Color.FromArgb(233, 30, 99),
        Color.FromArgb(216, 27, 96),
        Color.FromArgb(194, 24, 91),
        Color.FromArgb(173, 20, 87),
        Color.FromArgb(136, 14, 79)
    );

    public static readonly Hue Purple = new(
        Color.FromArgb(225, 190, 231),
        Color.FromArgb(206, 147, 216),
        Color.FromArgb(186, 104, 200),
        Color.FromArgb(171, 71, 188),
        Color.FromArgb(156, 39, 176),
        Color.FromArgb(142, 36, 170),
        Color.FromArgb(123, 31, 162),
        Color.FromArgb(106, 27, 154),
        Color.FromArgb(74, 20, 140)
    );

    public static readonly Hue DeepPurple = new(
        Color.FromArgb(209, 196, 233),
        Color.FromArgb(179, 157, 219),
        Color.FromArgb(149, 117, 205),
        Color.FromArgb(126, 87, 194),
        Color.FromArgb(103, 58, 183),
        Color.FromArgb(94, 53, 177),
        Color.FromArgb(81, 45, 168),
        Color.FromArgb(69, 39, 160),
        Color.FromArgb(49, 27, 146)
    );

    public static readonly Hue Indigo = new(
        Color.FromArgb(197, 202, 233),
        Color.FromArgb(159, 168, 218),
        Color.FromArgb(121, 134, 203),
        Color.FromArgb(92, 107, 192),
        Color.FromArgb(63, 81, 181),
        Color.FromArgb(57, 73, 171),
        Color.FromArgb(48, 63, 159),
        Color.FromArgb(40, 53, 147),
        Color.FromArgb(26, 35, 126)
    );

    public static readonly Hue Blue = new(
        Color.FromArgb(187, 222, 251),
        Color.FromArgb(144, 202, 249),
        Color.FromArgb(100, 181, 246),
        Color.FromArgb(66, 165, 245),
        Color.FromArgb(33, 150, 243),
        Color.FromArgb(30, 136, 229),
        Color.FromArgb(25, 118, 210),
        Color.FromArgb(21, 101, 192),
        Color.FromArgb(13, 71, 161)
    );

    public static readonly Hue LightBlue = new(
        Color.FromArgb(179, 229, 252),
        Color.FromArgb(129, 212, 250),
        Color.FromArgb(79, 195, 247),
        Color.FromArgb(41, 182, 246),
        Color.FromArgb(3, 169, 244),
        Color.FromArgb(3, 155, 229),
        Color.FromArgb(2, 136, 209),
        Color.FromArgb(2, 119, 189),
        Color.FromArgb(1, 87, 155)
    );

    public static readonly Hue Cyan = new(
        Color.FromArgb(178, 235, 242),
        Color.FromArgb(128, 222, 234),
        Color.FromArgb(77, 208, 225),
        Color.FromArgb(38, 198, 218),
        Color.FromArgb(0, 188, 212),
        Color.FromArgb(0, 172, 193),
        Color.FromArgb(0, 151, 167),
        Color.FromArgb(0, 131, 143),
        Color.FromArgb(0, 96, 100)
    );

    public static readonly Hue Teal = new(
        Color.FromArgb(178, 223, 219),
        Color.FromArgb(128, 203, 196),
        Color.FromArgb(77, 182, 172),
        Color.FromArgb(38, 166, 154),
        Color.FromArgb(0, 150, 136),
        Color.FromArgb(0, 137, 123),
        Color.FromArgb(0, 121, 107),
        Color.FromArgb(0, 105, 92),
        Color.FromArgb(0, 77, 64)
    );

    public static readonly Hue Green = new(
        Color.FromArgb(200, 230, 201),
        Color.FromArgb(165, 214, 167),
        Color.FromArgb(129, 199, 132),
        Color.FromArgb(102, 187, 106),
        Color.FromArgb(76, 175, 80),
        Color.FromArgb(67, 160, 71),
        Color.FromArgb(56, 142, 60),
        Color.FromArgb(46, 125, 50),
        Color.FromArgb(27, 94, 32)
    );

    public static readonly Hue LightGreen = new(
        Color.FromArgb(220, 237, 200),
        Color.FromArgb(197, 225, 165),
        Color.FromArgb(174, 213, 129),
        Color.FromArgb(156, 204, 101),
        Color.FromArgb(139, 195, 74),
        Color.FromArgb(124, 179, 66),
        Color.FromArgb(104, 159, 56),
        Color.FromArgb(85, 139, 47),
        Color.FromArgb(51, 105, 30)
    );

    public static readonly Hue Lime = new(
        Color.FromArgb(240, 244, 195),
        Color.FromArgb(230, 238, 156),
        Color.FromArgb(220, 231, 117),
        Color.FromArgb(212, 225, 87),
        Color.FromArgb(205, 220, 57),
        Color.FromArgb(192, 202, 51),
        Color.FromArgb(175, 180, 43),
        Color.FromArgb(158, 157, 36),
        Color.FromArgb(130, 119, 23)
    );

    public static readonly Hue Yellow = new(
        Color.FromArgb(255, 249, 196),
        Color.FromArgb(255, 245, 157),
        Color.FromArgb(255, 241, 118),
        Color.FromArgb(255, 238, 88),
        Color.FromArgb(255, 235, 59),
        Color.FromArgb(253, 216, 53),
        Color.FromArgb(251, 192, 45),
        Color.FromArgb(249, 168, 37),
        Color.FromArgb(245, 127, 23)
    );

    public static readonly Hue Amber = new(
        Color.FromArgb(255, 236, 179),
        Color.FromArgb(255, 224, 130),
        Color.FromArgb(255, 213, 79),
        Color.FromArgb(255, 202, 40),
        Color.FromArgb(255, 193, 7),
        Color.FromArgb(255, 179, 0),
        Color.FromArgb(255, 160, 0),
        Color.FromArgb(255, 143, 0),
        Color.FromArgb(255, 111, 0)
    );

    public static readonly Hue Orange = new(
        Color.FromArgb(255, 224, 178),
        Color.FromArgb(255, 204, 128),
        Color.FromArgb(255, 183, 77),
        Color.FromArgb(255, 167, 38),
        Color.FromArgb(255, 152, 0),
        Color.FromArgb(251, 140, 0),
        Color.FromArgb(245, 124, 0),
        Color.FromArgb(239, 108, 0),
        Color.FromArgb(230, 81, 0)
    );

    public static readonly Hue DeepOrange = new(
        Color.FromArgb(255, 204, 188),
        Color.FromArgb(255, 171, 145),
        Color.FromArgb(255, 138, 101),
        Color.FromArgb(255, 112, 67),
        Color.FromArgb(255, 87, 34),
        Color.FromArgb(244, 81, 30),
        Color.FromArgb(230, 74, 25),
        Color.FromArgb(216, 67, 21),
        Color.FromArgb(191, 54, 12)
    );

    public static readonly Hue Brown = new(
        Color.FromArgb(215, 204, 200),
        Color.FromArgb(188, 170, 164),
        Color.FromArgb(161, 136, 127),
        Color.FromArgb(141, 110, 99),
        Color.FromArgb(121, 85, 72),
        Color.FromArgb(109, 76, 65),
        Color.FromArgb(93, 64, 55),
        Color.FromArgb(78, 52, 46),
        Color.FromArgb(62, 39, 35)
    );

    public static readonly Hue Grey = new(
        Color.FromArgb(245, 245, 245),
        Color.FromArgb(238, 238, 238),
        Color.FromArgb(224, 224, 224),
        Color.FromArgb(189, 189, 189),
        Color.FromArgb(158, 158, 158),
        Color.FromArgb(117, 117, 117),
        Color.FromArgb(97, 97, 97),
        Color.FromArgb(66, 66, 66),
        Color.FromArgb(33, 33, 33)
    );

    public static readonly Hue BlueGrey = new(
        Color.FromArgb(207, 216, 220),
        Color.FromArgb(176, 190, 197),
        Color.FromArgb(144, 164, 174),
        Color.FromArgb(120, 144, 156),
        Color.FromArgb(96, 125, 139),
        Color.FromArgb(84, 110, 122),
        Color.FromArgb(69, 90, 100),
        Color.FromArgb(55, 71, 79),
        Color.FromArgb(38, 50, 56)
    );
}