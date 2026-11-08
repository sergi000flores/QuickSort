using System.Drawing.Drawing2D;

namespace QuickSortWinForms;

public static class Palette
{
    public static readonly Color Background = Color.FromArgb(246, 244, 239);
    public static readonly Color Dark = Color.FromArgb(27, 36, 48);
    public static readonly Color Muted = Color.FromArgb(91, 100, 112);
    public static readonly Color Cell = Color.FromArgb(255, 253, 248);
    public static readonly Color Border = Color.FromArgb(216, 210, 196);
    public static readonly Color Orange = Color.FromArgb(217, 102, 31);
    public static readonly Color Blue = Color.FromArgb(47, 93, 138);
    public static readonly Color Green = Color.FromArgb(63, 125, 88);
    public static readonly Color Yellow = Color.FromArgb(243, 210, 122);
    public static readonly Color Faded = Color.FromArgb(236, 232, 222);
    public static readonly Color FadedText = Color.FromArgb(138, 145, 156);
}

/// <summary>Panel que dibuja la lista como casillas de colores.</summary>
public sealed class ArrayPanel : Panel
{
    private readonly record struct CellStyle(Color Back, Color Fore, Color Border, float Width, string Label);

    private string[] _items = Array.Empty<string>();
    private SortStep? _step;
    private bool _allSorted;
    private readonly Font _cellFont = new("Segoe UI", 16f, FontStyle.Bold);
    private readonly Font _smallFont = new("Segoe UI", 10f);
    private readonly Font _labelFont = new("Segoe UI", 11f, FontStyle.Bold);
    private const int Gap = 12, Pad = 20, CellH = 76, IndexH = 22, LabelH = 28, RowGap = 14;

    public ArrayPanel()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
        AutoScroll = true;
        BackColor = Palette.Background;
    }

    public void ShowItems(string[] items, SortStep? step, bool allSorted = false)
    {
        _items = items;
        _step = step;
        _allSorted = allSorted;
        UpdateScroll();
        Invalidate();
    }

    private void Metrics(out int cellW, out int perRow, out int rowH)
    {
        int maxText = 0;
        foreach (var s in _items) maxText = Math.Max(maxText, TextRenderer.MeasureText(s, _cellFont).Width);
        cellW = Math.Max(76, maxText + 28);
        int avail = Math.Max(cellW, ClientSize.Width - 2 * Pad);
        perRow = Math.Max(1, (avail + Gap) / (cellW + Gap));
        rowH = IndexH + CellH + LabelH + RowGap;
    }

    private void UpdateScroll()
    {
        Metrics(out _, out int perRow, out int rowH);
        int rows = _items.Length == 0 ? 0 : (_items.Length + perRow - 1) / perRow;
        AutoScrollMinSize = new Size(0, rows * rowH + 2 * Pad);
    }

    protected override void OnResize(EventArgs eventargs)
    {
        base.OnResize(eventargs);
        UpdateScroll();
    }

    private CellStyle GetStyle(int k)
    {
        var cell = new CellStyle(Palette.Cell, Palette.Dark, Palette.Border, 2f, "");
        var green = new CellStyle(Palette.Green, Color.White, Palette.Green, 2f, "");
        var faded = new CellStyle(Palette.Faded, Palette.FadedText, Palette.Border, 2f, "");
        var blue = new CellStyle(Palette.Blue, Color.White, Palette.Blue, 2f, "");
        if (_allSorted) return green;
        var s = _step;
        if (s == null) return cell;

        bool fx = k < s.Fixed.Length && s.Fixed[k];
        bool inRange = s.Lo >= 0 && k >= s.Lo && k <= s.Hi;

        switch (s.Kind)
        {
            case StepKind.Pivot:
            {
                if (!inRange) return fx ? green : faded;
                string lab = "";
                for (int c = 0; c < s.Candidates.Length; c++)
                    if (s.Candidates[c] == k) lab += (lab.Length > 0 ? "/" : "") + s.CandidateLabels[c];
                if (k == s.PivotPos) return new CellStyle(Palette.Orange, Palette.Dark, Palette.Orange, 2f, lab.Length > 0 ? lab : "pivote");
                if (lab.Length > 0) return new CellStyle(Palette.Yellow, Palette.Dark, Palette.Dark, 3f, lab);
                return cell;
            }

            case StepKind.Setup:
            case StepKind.Compare:
                if (!inRange) return fx ? green : faded;
                if (k == s.Hi) return new CellStyle(Palette.Orange, Palette.Dark, Palette.Orange, 2f, "pivote");
                if (k == s.J) return new CellStyle(Palette.Yellow, Palette.Dark, Palette.Dark, 5f, k == s.I ? "i, j" : "j");
                if (k <= s.I) return new CellStyle(Palette.Blue, Color.White, Palette.Blue, 2f, k == s.I ? "i" : "");
                return cell;

            case StepKind.Final:
                if (!inRange) return fx ? green : faded;
                if (k == s.PivotFinal) return new CellStyle(Palette.Green, Color.White, Palette.Green, 2f, "pivote");
                if (k < s.PivotFinal) return blue;
                return cell;

            default:
                return fx ? green : cell;
        }
    }

    private static GraphicsPath RoundRect(Rectangle r, int radius)
    {
        int d = radius * 2;
        var p = new GraphicsPath();
        p.AddArc(r.X, r.Y, d, d, 180, 90);
        p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        p.CloseFigure();
        return p;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (_items.Length == 0) return;

        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        g.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

        Metrics(out int cellW, out int perRow, out int rowH);
        using var sf = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
            FormatFlags = StringFormatFlags.NoWrap
        };

        for (int k = 0; k < _items.Length; k++)
        {
            int row = k / perRow, col = k % perRow;
            int inRow = Math.Min(perRow, _items.Length - row * perRow);
            int rowWidth = inRow * (cellW + Gap) - Gap;
            int x0 = Math.Max(Pad, (ClientSize.Width - rowWidth) / 2);
            int x = x0 + col * (cellW + Gap);
            int y = Pad + row * rowH;
            var st = GetStyle(k);

            using (var br = new SolidBrush(Palette.Muted))
                g.DrawString(k.ToString(), _smallFont, br, new RectangleF(x, y, cellW, IndexH), sf);

            var rect = new Rectangle(x, y + IndexH, cellW, CellH);
            using (var path = RoundRect(rect, 12))
            using (var fill = new SolidBrush(st.Back))
            using (var pen = new Pen(st.Border, st.Width))
            {
                g.FillPath(fill, path);
                g.DrawPath(pen, path);
            }
            using (var fb = new SolidBrush(st.Fore))
                g.DrawString(_items[k], _cellFont, fb, rect, sf);

            if (st.Label.Length > 0)
                using (var lb = new SolidBrush(Palette.Dark))
                    g.DrawString(st.Label, _labelFont, lb, new RectangleF(x, y + IndexH + CellH + 2, cellW, LabelH), sf);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _cellFont.Dispose();
            _smallFont.Dispose();
            _labelFont.Dispose();
        }
        base.Dispose(disposing);
    }
}

/// <summary>Leyenda de colores.</summary>
public sealed class LegendPanel : Panel
{
    private static readonly (Color Color, string Text)[] Entries =
    {
        (Palette.Orange, "Pivote"),
        (Palette.Yellow, "j / candidato a pivote"),
        (Palette.Blue, "Menores o iguales (hasta i)"),
        (Palette.Green, "Ya en su lugar final"),
        (Palette.Faded, "Fuera de la sublista")
    };

    public LegendPanel()
    {
        DoubleBuffered = true;
        BackColor = Palette.Background;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        int x = 14;
        foreach (var (color, text) in Entries)
        {
            using (var br = new SolidBrush(color)) e.Graphics.FillRectangle(br, x, 8, 18, 18);
            e.Graphics.DrawRectangle(Pens.Gray, x, 8, 18, 18);
            TextRenderer.DrawText(e.Graphics, text, Font, new Point(x + 24, 6), Palette.Dark);
            x += 24 + TextRenderer.MeasureText(text, Font).Width + 26;
        }
    }
}
