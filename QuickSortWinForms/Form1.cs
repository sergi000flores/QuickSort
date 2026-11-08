using System.Globalization;

namespace QuickSortWinForms;

public partial class Form1 : Form
{
    private enum DataKind { Entero, Decimal, Texto, Caracter, Fecha }

    private const int MaxItems = 30;
    private static readonly string[] Words =
    {
        "manzana", "pera", "uva", "sandía", "melón", "kiwi", "mango", "fresa", "limón", "naranja",
        "durazno", "papaya", "cereza", "piña", "plátano", "guayaba", "tuna", "ciruela", "coco", "lima"
    };

    private readonly Random _rng = new();
    private DataKind _kind = DataKind.Entero;
    private SortResult? _result;
    private string[] _original = Array.Empty<string>();
    private string _typeName = "";
    private int _stepIndex;
    private PivotStrategy _strategy = PivotStrategy.Last;
    private Action? _rerun;
    private bool _keepTab;
    private readonly Font _boldFont = new("Segoe UI", 11f, FontStyle.Bold);
    private bool _ready, _updatingList;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        _ready = true;
        UpdateHint();
        UpdateInterval();
        GenerateRandom();
    }

    // ---------------------------------------------------------------- tipo de dato

    private void TypeRadio_CheckedChanged(object? sender, EventArgs e)
    {
        if (!_ready || sender is not RadioButton rb || !rb.Checked) return;
        _kind = rb == rbInt ? DataKind.Entero
              : rb == rbDouble ? DataKind.Decimal
              : rb == rbString ? DataKind.Texto
              : rb == rbChar ? DataKind.Caracter
              : DataKind.Fecha;
        UpdateHint();
        GenerateRandom();
    }

    private void UpdateHint()
    {
        lblHint.Text = _kind switch
        {
            DataKind.Entero => "Ejemplo de datos propios: 7, 2, 9, 4, 1, 8, 5",
            DataKind.Decimal => "Ejemplo de datos propios: 3.5, 1.2, 9.9, 0.4",
            DataKind.Texto => "Ejemplo de datos propios: pera, manzana, uva, kiwi",
            DataKind.Caracter => "Ejemplo de datos propios (un solo carácter cada uno): d, a, c, b",
            _ => "Ejemplo de datos propios: 15/03/2025, 02/01/2024, 30/11/2025"
        };
    }

    private void PivotRadio_CheckedChanged(object? sender, EventArgs e)
    {
        if (!_ready || sender is not RadioButton rb || !rb.Checked) return;
        _strategy = rb == rbPivFirst ? PivotStrategy.First
                  : rb == rbPivLast ? PivotStrategy.Last
                  : rb == rbPivRandom ? PivotStrategy.Random
                  : PivotStrategy.MedianOfThree;
        _keepTab = true;          // se vuelve a ordenar la MISMA lista con el nuevo pivote
        _rerun?.Invoke();
        _keepTab = false;
    }

    // ---------------------------------------------------------------- generar datos

    private void btnGenerate_Click(object? sender, EventArgs e) => GenerateRandom();

    private void GenerateRandom()
    {
        int n = (int)nudCount.Value;
        switch (_kind)
        {
            case DataKind.Entero:
                Run(Enumerable.Range(0, n).Select(_ => _rng.Next(1, 100)).ToArray(),
                    x => x.ToString(), "Números enteros (int)");
                break;
            case DataKind.Decimal:
                Run(Enumerable.Range(0, n).Select(_ => Math.Round(_rng.NextDouble() * 100, 1)).ToArray(),
                    x => x.ToString("0.0", CultureInfo.CurrentCulture), "Números decimales (double)");
                break;
            case DataKind.Texto:
                Run(Enumerable.Range(0, n).Select(_ => Words[_rng.Next(Words.Length)]).ToArray(),
                    x => x, "Texto (string)");
                break;
            case DataKind.Caracter:
                Run(Enumerable.Range(0, n).Select(_ => (char)('A' + _rng.Next(26))).ToArray(),
                    x => x.ToString(), "Caracteres (char)");
                break;
            default:
                Run(Enumerable.Range(0, n).Select(_ => DateTime.Today.AddDays(-_rng.Next(0, 730))).ToArray(),
                    x => x.ToString("dd/MM/yyyy"), "Fechas (DateTime)");
                break;
        }
    }

    private void btnManual_Click(object? sender, EventArgs e)
    {
        var tokens = txtManual.Text
            .Split(new[] { ',', ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(t => t.Trim())
            .Where(t => t.Length > 0)
            .ToArray();

        if (tokens.Length < 2 || tokens.Length > MaxItems)
        {
            MessageBox.Show($"Escribe entre 2 y {MaxItems} datos separados por coma.", "Datos propios",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        nudCount.Value = tokens.Length;

        switch (_kind)
        {
            case DataKind.Entero:
            {
                var v = new int[tokens.Length];
                for (int k = 0; k < v.Length; k++)
                    if (!int.TryParse(tokens[k], NumberStyles.Integer, CultureInfo.CurrentCulture, out v[k]))
                    { Bad(tokens[k], "un número entero"); return; }
                Run(v, x => x.ToString(), "Números enteros (int)");
                break;
            }
            case DataKind.Decimal:
            {
                var v = new double[tokens.Length];
                for (int k = 0; k < v.Length; k++)
                    if (!double.TryParse(tokens[k], NumberStyles.Float, CultureInfo.CurrentCulture, out v[k]) &&
                        !double.TryParse(tokens[k], NumberStyles.Float, CultureInfo.InvariantCulture, out v[k]))
                    { Bad(tokens[k], "un número decimal"); return; }
                Run(v, x => x.ToString(CultureInfo.CurrentCulture), "Números decimales (double)");
                break;
            }
            case DataKind.Texto:
                Run(tokens, x => x, "Texto (string)");
                break;
            case DataKind.Caracter:
            {
                var v = new char[tokens.Length];
                for (int k = 0; k < v.Length; k++)
                {
                    if (tokens[k].Length != 1) { Bad(tokens[k], "un solo carácter"); return; }
                    v[k] = tokens[k][0];
                }
                Run(v, x => x.ToString(), "Caracteres (char)");
                break;
            }
            default:
            {
                var v = new DateTime[tokens.Length];
                for (int k = 0; k < v.Length; k++)
                    if (!DateTime.TryParse(tokens[k], CultureInfo.CurrentCulture, DateTimeStyles.None, out v[k]))
                    { Bad(tokens[k], "una fecha"); return; }
                Run(v, x => x.ToString("dd/MM/yyyy"), "Fechas (DateTime)");
                break;
            }
        }
    }

    private static void Bad(string token, string expected) =>
        MessageBox.Show($"No se pudo convertir \"{token}\" a {expected}.", "Dato no válido",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);

    // ---------------------------------------------------------------- ejecutar el algoritmo

    private void Run<T>(T[] data, Func<T, string> fmt, string typeName) where T : IComparable<T>
    {
        timerPlay.Stop();
        btnPlay.Text = "Reproducir";

        _rerun = () => Run(data, fmt, typeName);
        _typeName = typeName;
        _original = data.Select(fmt).ToArray();
        _result = QuickSorter.SortWithSteps(data, fmt, _strategy, _rng);       // todos los pasos, para mostrarlos

        var sorted = (T[])data.Clone();
        QuickSorter.Sort(sorted, _strategy, _rng);             // el algoritmo genérico QuickSort<T>
        var stats = QuickSorter.CompareStrategies(data, fmt, _rng);   // comparación de las 4 estrategias
        FillFinalTab(sorted.Select(fmt).ToArray(), stats);

        _updatingList = true;
        lstSteps.BeginUpdate();
        lstSteps.Items.Clear();
        for (int k = 0; k < _result.Steps.Count; k++)
            lstSteps.Items.Add($"{k + 1}. {_result.Steps[k].Title}");
        lstSteps.EndUpdate();
        _updatingList = false;

        if (!_keepTab) tabMain.SelectedTab = tabStep;
        ShowStep(0);
    }

    private void FillFinalTab(string[] sortedItems, List<StrategyStats> stats)
    {
        var r = _result!;
        finalOriginal.ShowItems(_original, null, false);
        finalSorted.ShowItems(sortedItems, null, true);
        lblStats.Text =
            $"Tipo de dato: {_typeName}   ·   Estrategia de pivote en pantalla: {_strategy.DisplayName()}{Environment.NewLine}" +
            $"Cantidad de elementos: {_original.Length}{Environment.NewLine}" +
            $"Particiones: {r.Partitions}   ·   Comparaciones: {r.Comparisons}   ·   Intercambios: {r.Swaps}{Environment.NewLine}" +
            $"Pasos mostrados en la pantalla paso a paso: {r.Steps.Count}";

        // ---- comparación: gana la que hace menos comparaciones (y, si empatan, menos intercambios) ----
        var ordered = stats.OrderBy(x => x.Comparisons).ThenBy(x => x.Swaps).ToList();
        var best = ordered
            .Where(x => Math.Abs(x.Comparisons - ordered[0].Comparisons) < 1e-9 && Math.Abs(x.Swaps - ordered[0].Swaps) < 1e-9)
            .ToList();

        lvCompare.Items.Clear();
        foreach (var st in stats)
        {
            bool isBest = best.Contains(st);
            string F(double v) => st.IsAverage ? v.ToString("0.0") : v.ToString("0");
            var item = new ListViewItem(new[]
            {
                (isBest ? "★ " : "") + st.Strategy.DisplayName() + (st.IsAverage ? " (promedio de 30 ejecuciones)" : ""),
                F(st.Partitions), F(st.Comparisons), F(st.Swaps)
            });
            if (isBest)
            {
                item.BackColor = Color.FromArgb(214, 235, 220);
                item.Font = _boldFont;
            }
            lvCompare.Items.Add(item);
        }

        string names = string.Join(" y ", best.Select(x => x.Strategy.DisplayName()));
        string cmp = best[0].IsAverage ? best[0].Comparisons.ToString("0.0") : best[0].Comparisons.ToString("0");
        lblBest.Text = (best.Count > 1
            ? $"Mejor para esta lista: {names} (empatan con {cmp} comparaciones)."
            : $"Mejor para esta lista: {names}, con {cmp} comparaciones.") + Environment.NewLine +
            "Nota: depende de la lista. Primer o último elemento fallan con listas ya ordenadas (peor caso); " +
            "el aleatorio y la mediana de tres evitan ese problema.";
    }

    // ---------------------------------------------------------------- navegación paso a paso

    private void ShowStep(int index)
    {
        if (_result == null) return;
        int count = _result.Steps.Count;
        index = Math.Max(0, Math.Min(index, count - 1));
        _stepIndex = index;
        var s = _result.Steps[index];

        arrayPanel.ShowItems(s.Items, s);
        lblStepTitle.Text = s.Title;
        lblHeadline.Text = s.Headline;
        lblMessage.Text = s.Message;
        lblCounter.Text = $"Paso {index + 1} de {count}   ·   Comparaciones: {s.Comparisons}   ·   Intercambios: {s.Swaps}";

        _updatingList = true;
        lstSteps.SelectedIndex = index;
        _updatingList = false;

        btnFirst.Enabled = btnPrev.Enabled = index > 0;
        btnNext.Enabled = btnLast.Enabled = index < count - 1;

        if (index == count - 1 && timerPlay.Enabled)
        {
            timerPlay.Stop();
            btnPlay.Text = "Reproducir";
        }
    }

    private void btnFirst_Click(object? sender, EventArgs e) => ShowStep(0);
    private void btnPrev_Click(object? sender, EventArgs e) => ShowStep(_stepIndex - 1);
    private void btnNext_Click(object? sender, EventArgs e) => ShowStep(_stepIndex + 1);
    private void btnLast_Click(object? sender, EventArgs e) => ShowStep(int.MaxValue);
    private void btnResult_Click(object? sender, EventArgs e) => tabMain.SelectedTab = tabFinal;

    private void btnPlay_Click(object? sender, EventArgs e)
    {
        if (_result == null) return;
        if (timerPlay.Enabled)
        {
            timerPlay.Stop();
            btnPlay.Text = "Reproducir";
            return;
        }
        if (_stepIndex >= _result.Steps.Count - 1) ShowStep(0);
        timerPlay.Start();
        btnPlay.Text = "Pausar";
    }

    private void timerPlay_Tick(object? sender, EventArgs e) => ShowStep(_stepIndex + 1);

    private void trackSpeed_Scroll(object? sender, EventArgs e) => UpdateInterval();

    private void UpdateInterval() => timerPlay.Interval = 1600 - trackSpeed.Value * 150;

    private void lstSteps_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_updatingList || lstSteps.SelectedIndex < 0) return;
        ShowStep(lstSteps.SelectedIndex);
    }
}
