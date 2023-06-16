namespace GuitarTheory.UI.Support;

/// <summary>
/// These colors were borrowed from https://mobileui.github.io/#colors
/// </summary>
public static class Palette
{
    public static readonly IReadOnlyList<Color> Red = new[]
    {
        new Color(255, 235, 238),
        new Color(255, 205, 210),
        new Color(239, 154, 154),
        new Color(229, 115, 115),
        new Color(239, 83, 80),
        new Color(244, 67, 54),
        new Color(229, 57, 53),
        new Color(211, 47, 47),
        new Color(198, 40, 40),
        new Color(183, 28, 28)
    };

    public static readonly IReadOnlyList<Color> Pink = new[]
    {
        new Color(252, 228, 236),
        new Color(248, 187, 208),
        new Color(244, 143, 177),
        new Color(240, 98, 146),
        new Color(236, 64, 122),
        new Color(233, 30, 99),
        new Color(216, 27, 96),
        new Color(194, 24, 91),
        new Color(173, 20, 87),
        new Color(136, 14, 79)
    };

    public static readonly IReadOnlyList<Color> Purple = new[]
    {
        new Color(243, 229, 245),
        new Color(225, 190, 231),
        new Color(206, 147, 216),
        new Color(186, 104, 200),
        new Color(171, 71, 188),
        new Color(156, 39, 176),
        new Color(142, 36, 170),
        new Color(123, 31, 162),
        new Color(106, 27, 154),
        new Color(74, 20, 140)
    };

    public static readonly IReadOnlyList<Color> DeepPurple = new[]
    {
        new Color(237, 231, 246),
        new Color(209, 196, 233),
        new Color(179, 157, 219),
        new Color(149, 117, 205),
        new Color(126, 87, 194),
        new Color(103, 58, 183),
        new Color(94, 53, 177),
        new Color(81, 45, 168),
        new Color(69, 39, 160),
        new Color(49, 27, 146)
    };

    public static readonly IReadOnlyList<Color> Indigo = new[]
    {
        new Color(232, 234, 246),
        new Color(197, 202, 233),
        new Color(159, 168, 218),
        new Color(121, 134, 203),
        new Color(92, 107, 192),
        new Color(63, 81, 181),
        new Color(57, 73, 171),
        new Color(48, 63, 159),
        new Color(40, 53, 147),
        new Color(26, 35, 126)
    };

    public static readonly IReadOnlyList<Color> Blue = new[]
    {
        new Color(227, 242, 253),
        new Color(187, 222, 251),
        new Color(144, 202, 249),
        new Color(100, 181, 246),
        new Color(66, 165, 245),
        new Color(33, 150, 243),
        new Color(30, 136, 229),
        new Color(25, 118, 210),
        new Color(21, 101, 192),
        new Color(13, 71, 161)
    };

    public static readonly IReadOnlyList<Color> LightBlue = new[]
    {
        new Color(225, 245, 254),
        new Color(179, 229, 252),
        new Color(129, 212, 250),
        new Color(79, 195, 247),
        new Color(41, 182, 246),
        new Color(3, 169, 244),
        new Color(3, 155, 229),
        new Color(2, 136, 209),
        new Color(2, 119, 189),
        new Color(1, 87, 155)
    };

    public static readonly IReadOnlyList<Color> Cyan = new[]
    {
        new Color(224, 247, 250),
        new Color(178, 235, 242),
        new Color(128, 222, 234),
        new Color(77, 208, 225),
        new Color(38, 198, 218),
        new Color(0, 188, 212),
        new Color(0, 172, 193),
        new Color(0, 151, 167),
        new Color(0, 131, 143),
        new Color(0, 96, 100)
    };

    public static readonly IReadOnlyList<Color> Teal = new[]
    {
        new Color(224, 242, 241),
        new Color(178, 223, 219),
        new Color(128, 203, 196),
        new Color(77, 182, 172),
        new Color(38, 166, 154),
        new Color(0, 150, 136),
        new Color(0, 137, 123),
        new Color(0, 121, 107),
        new Color(0, 105, 92),
        new Color(0, 77, 64)
    };

    public static readonly IReadOnlyList<Color> Green = new[]
    {
        new Color(232, 245, 233),
        new Color(200, 230, 201),
        new Color(165, 214, 167),
        new Color(129, 199, 132),
        new Color(102, 187, 106),
        new Color(76, 175, 80),
        new Color(67, 160, 71),
        new Color(56, 142, 60),
        new Color(46, 125, 50),
        new Color(27, 94, 32)
    };

    public static readonly IReadOnlyList<Color> LightGreen = new[]
    {
        new Color(241, 248, 233),
        new Color(220, 237, 200),
        new Color(197, 225, 165),
        new Color(174, 213, 129),
        new Color(156, 204, 101),
        new Color(139, 195, 74),
        new Color(124, 179, 66),
        new Color(104, 159, 56),
        new Color(85, 139, 47),
        new Color(51, 105, 30)
    };

    public static readonly IReadOnlyList<Color> Lime = new[]
    {
        new Color(249, 251, 231),
        new Color(240, 244, 195),
        new Color(230, 238, 156),
        new Color(220, 231, 117),
        new Color(212, 225, 87),
        new Color(205, 220, 57),
        new Color(192, 202, 51),
        new Color(175, 180, 43),
        new Color(158, 157, 36),
        new Color(130, 119, 23)
    };

    public static readonly IReadOnlyList<Color> Yellow = new[]
    {
        new Color(255, 253, 231),
        new Color(255, 249, 196),
        new Color(255, 245, 157),
        new Color(255, 241, 118),
        new Color(255, 238, 88),
        new Color(255, 235, 59),
        new Color(253, 216, 53),
        new Color(251, 192, 45),
        new Color(249, 168, 37),
        new Color(245, 127, 23)
    };

    public static readonly IReadOnlyList<Color> Amber = new[]
    {
        new Color(255, 248, 225),
        new Color(255, 236, 179),
        new Color(255, 224, 130),
        new Color(255, 213, 79),
        new Color(255, 202, 40),
        new Color(255, 193, 7),
        new Color(255, 179, 0),
        new Color(255, 160, 0),
        new Color(255, 143, 0),
        new Color(255, 111, 0)
    };

    public static readonly IReadOnlyList<Color> Orange = new[]
    {
        new Color(255, 243, 224),
        new Color(255, 224, 178),
        new Color(255, 204, 128),
        new Color(255, 183, 77),
        new Color(255, 167, 38),
        new Color(255, 152, 0),
        new Color(251, 140, 0),
        new Color(245, 124, 0),
        new Color(239, 108, 0),
        new Color(230, 81, 0)
    };

    public static readonly IReadOnlyList<Color> DeepOrange = new[]
    {
        new Color(251, 233, 231),
        new Color(255, 204, 188),
        new Color(255, 171, 145),
        new Color(255, 138, 101),
        new Color(255, 112, 67),
        new Color(255, 87, 34),
        new Color(244, 81, 30),
        new Color(230, 74, 25),
        new Color(216, 67, 21),
        new Color(191, 54, 12)
    };

    public static readonly IReadOnlyList<Color> Brown = new[]
    {
        new Color(239, 235, 233),
        new Color(215, 204, 200),
        new Color(188, 170, 164),
        new Color(161, 136, 127),
        new Color(141, 110, 99),
        new Color(121, 85, 72),
        new Color(109, 76, 65),
        new Color(93, 64, 55),
        new Color(78, 52, 46),
        new Color(62, 39, 35)
    };

    public static readonly IReadOnlyList<Color> Grey = new[]
    {
        new Color(250, 250, 250),
        new Color(245, 245, 245),
        new Color(238, 238, 238),
        new Color(224, 224, 224),
        new Color(189, 189, 189),
        new Color(158, 158, 158),
        new Color(117, 117, 117),
        new Color(97, 97, 97),
        new Color(66, 66, 66),
        new Color(33, 33, 33)
    };

    public static readonly IReadOnlyList<Color> BlueGrey = new[]
    {
        new Color(236, 239, 241),
        new Color(207, 216, 220),
        new Color(176, 190, 197),
        new Color(144, 164, 174),
        new Color(120, 144, 156),
        new Color(96, 125, 139),
        new Color(84, 110, 122),
        new Color(69, 90, 100),
        new Color(55, 71, 79),
        new Color(38, 50, 56)
    };
}