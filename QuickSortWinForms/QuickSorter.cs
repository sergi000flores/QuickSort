namespace QuickSortWinForms;

public enum StepKind { Initial, Pivot, Setup, Compare, Final, Single, Done }

/// <summary>Formas de elegir el pivote.</summary>
public enum PivotStrategy { First, Last, Random, MedianOfThree }

public static class PivotExtensions
{
    public static string DisplayName(this PivotStrategy s) => s switch
    {
        PivotStrategy.First => "Primer elemento",
        PivotStrategy.Last => "Último elemento",
        PivotStrategy.Random => "Selección aleatoria",
        _ => "Mediana de tres"
    };
}

/// <summary>Una "foto" del algoritmo en un momento dado (para mostrarla paso por paso).</summary>
public sealed class SortStep
{
    public StepKind Kind { get; init; }
    public string[] Items { get; init; } = Array.Empty<string>();
    public bool[] Fixed { get; init; } = Array.Empty<bool>();
    public int Lo { get; init; } = -1;
    public int Hi { get; init; } = -1;
    public int I { get; init; } = -1;
    public int J { get; init; } = -1;
    public int PivotFinal { get; init; } = -1;
    public int PivotPos { get; init; } = -1;
    public int[] Candidates { get; init; } = Array.Empty<int>();
    public string[] CandidateLabels { get; init; } = Array.Empty<string>();
    public string Title { get; init; } = "";
    public string Headline { get; init; } = "";
    public string Message { get; init; } = "";
    public int Comparisons { get; init; }
    public int Swaps { get; init; }
}

public sealed class SortResult
{
    public List<SortStep> Steps { get; init; } = new();
    public int Comparisons { get; init; }
    public int Swaps { get; init; }
    public int Partitions { get; init; }
}

public sealed record StrategyStats(PivotStrategy Strategy, double Partitions, double Comparisons, double Swaps, bool IsAverage);

public static class QuickSorter
{
    // ================= VERSIÓN LIMPIA DEL ALGORITMO (genérica) =================
    // Funciona con cualquier tipo T que sea comparable: int, double, string, char, DateTime...

    public static void Sort<T>(T[] array, PivotStrategy strategy = PivotStrategy.Last, Random? rng = null)
        where T : IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(array);
        Sort(array, 0, array.Length - 1, strategy, rng ?? Random.Shared);
    }

    private static void Sort<T>(T[] a, int lo, int hi, PivotStrategy s, Random rng) where T : IComparable<T>
    {
        if (lo >= hi) return;                    // 0 o 1 elemento: ya está ordenado
        int p = Partition(a, lo, hi, s, rng);    // el pivote queda en su lugar final (posición p)
        Sort(a, lo, p - 1, s, rng);              // se repite con la izquierda
        Sort(a, p + 1, hi, s, rng);              // se repite con la derecha
    }

    private static int Partition<T>(T[] a, int lo, int hi, PivotStrategy s, Random rng) where T : IComparable<T>
    {
        int pi = ChoosePivot(a, lo, hi, s, rng);
        if (pi != hi) (a[pi], a[hi]) = (a[hi], a[pi]);   // el pivote elegido se deja al final

        T pivot = a[hi];
        int i = lo - 1;                          // i marca el final del grupo de menores o iguales
        for (int j = lo; j < hi; j++)
        {
            if (a[j].CompareTo(pivot) <= 0)
            {
                i++;
                (a[i], a[j]) = (a[j], a[i]);
            }
        }
        (a[i + 1], a[hi]) = (a[hi], a[i + 1]);   // el pivote va justo después de los menores
        return i + 1;
    }

    private static int ChoosePivot<T>(T[] a, int lo, int hi, PivotStrategy s, Random rng) where T : IComparable<T> => s switch
    {
        PivotStrategy.First => lo,
        PivotStrategy.Last => hi,
        PivotStrategy.Random => rng.Next(lo, hi + 1),
        _ => MedianIndex(a, lo, (lo + hi) / 2, hi)
    };

    private static int MedianIndex<T>(T[] a, int x, int y, int z) where T : IComparable<T>
    {
        if (a[x].CompareTo(a[y]) < 0)
        {
            if (a[y].CompareTo(a[z]) < 0) return y;
            return a[x].CompareTo(a[z]) < 0 ? z : x;
        }
        if (a[x].CompareTo(a[z]) < 0) return x;
        return a[y].CompareTo(a[z]) < 0 ? z : y;
    }

    // ================= VERSIÓN QUE REGISTRA CADA PASO (para la pantalla) =================

    public static SortResult SortWithSteps<T>(T[] data, Func<T, string> format, PivotStrategy strategy, Random rng)
        where T : IComparable<T>
        => new Recorder<T>((T[])data.Clone(), format, strategy, rng).Run();

    /// <summary>Ordena la misma lista con las 4 estrategias para ver cuál hace menos trabajo.</summary>
    public static List<StrategyStats> CompareStrategies<T>(T[] data, Func<T, string> format, Random rng, int randomRuns = 30)
        where T : IComparable<T>
    {
        var list = new List<StrategyStats>();
        foreach (var s in new[] { PivotStrategy.First, PivotStrategy.Last, PivotStrategy.Random, PivotStrategy.MedianOfThree })
        {
            int runs = s == PivotStrategy.Random ? randomRuns : 1;
            double c = 0, w = 0, p = 0;
            for (int r = 0; r < runs; r++)
            {
                var res = SortWithSteps(data, format, s, rng);
                c += res.Comparisons; w += res.Swaps; p += res.Partitions;
            }
            list.Add(new StrategyStats(s, p / runs, c / runs, w / runs, runs > 1));
        }
        return list;
    }

    private sealed class Recorder<T> where T : IComparable<T>
    {
        private readonly T[] a;
        private readonly Func<T, string> fmt;
        private readonly PivotStrategy strat;
        private readonly Random rng;
        private readonly bool[] done;
        private readonly List<SortStep> steps = new();
        private int comps, swaps, parts;

        public Recorder(T[] array, Func<T, string> format, PivotStrategy strategy, Random random)
        {
            a = array;
            fmt = format;
            strat = strategy;
            rng = random;
            done = new bool[array.Length];
        }

        public SortResult Run()
        {
            Add(StepKind.Initial, -1, -1, -1, -1, -1, "Lista inicial", "Lista desordenada",
                $"Esta es la lista original. Estrategia de pivote: {strat.DisplayName()}. Pulsa «Siguiente» para avanzar paso por paso.");
            Quick(0, a.Length - 1);
            Add(StepKind.Done, -1, -1, -1, -1, -1, "Lista ordenada", "¡Lista ordenada!",
                $"Todos los elementos están en su lugar final. Total: {comps} comparaciones, {swaps} intercambios y {parts} particiones.");
            return new SortResult { Steps = steps, Comparisons = comps, Swaps = swaps, Partitions = parts };
        }

        private void Add(StepKind kind, int lo, int hi, int i, int j, int pf, string title, string headline, string message,
                         int pivotPos = -1, int[]? cand = null, string[]? candLabels = null)
        {
            steps.Add(new SortStep
            {
                Kind = kind, Items = a.Select(fmt).ToArray(), Fixed = (bool[])done.Clone(),
                Lo = lo, Hi = hi, I = i, J = j, PivotFinal = pf, PivotPos = pivotPos,
                Candidates = cand ?? Array.Empty<int>(), CandidateLabels = candLabels ?? Array.Empty<string>(),
                Title = title, Headline = headline, Message = message,
                Comparisons = comps, Swaps = swaps
            });
        }

        private string Rng(int lo, int hi) => string.Join("  ", a.Skip(lo).Take(hi - lo + 1).Select(fmt));

        private static string Side(int n) => n switch
        {
            0 => "lado vacío, no hay nada que hacer",
            1 => "queda 1 elemento, ya está ordenado",
            _ => $"{n} elementos, se repite el proceso"
        };

        private int Cmp(T x, T y) { comps++; return x.CompareTo(y); }

        private int MedianOfThree(int x, int y, int z)
        {
            if (Cmp(a[x], a[y]) < 0)
            {
                if (Cmp(a[y], a[z]) < 0) return y;
                return Cmp(a[x], a[z]) < 0 ? z : x;
            }
            if (Cmp(a[x], a[z]) < 0) return x;
            return Cmp(a[y], a[z]) < 0 ? z : y;
        }

        private void Quick(int lo, int hi)
        {
            if (lo > hi) return;
            if (lo == hi)
            {
                done[lo] = true;
                Add(StepKind.Single, lo, lo, -1, -1, lo, $"Elemento solo en la posición {lo}", $"{fmt(a[lo])} ya está ordenado",
                    "Una sublista de un solo elemento no necesita ordenarse: ese elemento ya está en su lugar definitivo.");
                return;
            }

            parts++;
            int n = parts;

            // ---- elegir el pivote y dejarlo en la última posición ----
            if (strat != PivotStrategy.Last)
            {
                int pi;
                int[] cand = Array.Empty<int>();
                string[] candLabels = Array.Empty<string>();
                string msg;
                switch (strat)
                {
                    case PivotStrategy.First:
                        pi = lo;
                        msg = $"Estrategia: primer elemento. El pivote es {fmt(a[pi])} (posición {pi}).";
                        break;
                    case PivotStrategy.Random:
                        pi = rng.Next(lo, hi + 1);
                        msg = $"Estrategia: selección aleatoria. Se sorteó la posición {pi} entre {lo} y {hi}: el pivote es {fmt(a[pi])}.";
                        break;
                    default:
                        int mid = (lo + hi) / 2;
                        pi = MedianOfThree(lo, mid, hi);
                        cand = new[] { lo, mid, hi };
                        candLabels = new[] { "primero", "medio", "último" };
                        msg = $"Estrategia: mediana de tres. Se comparan el primero ({fmt(a[lo])}, posición {lo}), el medio ({fmt(a[mid])}, posición {mid}) y el último ({fmt(a[hi])}, posición {hi}). La mediana es {fmt(a[pi])}, así que ese es el pivote.";
                        break;
                }
                string chosen = fmt(a[pi]);
                msg += pi == hi
                    ? " Ya está en la última posición, no hay que moverlo."
                    : $" Se intercambia con el último elemento para dejarlo al final: {chosen} ↔ {fmt(a[hi])}.";
                Add(StepKind.Pivot, lo, hi, lo - 1, -1, -1, $"Partición {n} · Elegir pivote", $"Pivote: {chosen}", msg, pi, cand, candLabels);
                if (pi != hi)
                {
                    (a[pi], a[hi]) = (a[hi], a[pi]);
                    swaps++;
                }
            }

            T pv = a[hi];
            string pvs = fmt(pv);
            int i = lo - 1;

            Add(StepKind.Setup, lo, hi, i, lo, -1, $"Partición {n} · Preparación", $"Sublista: {Rng(lo, hi)}",
                $"Ocupa las posiciones {lo} a {hi}. " +
                (strat == PivotStrategy.Last ? $"El pivote es el último elemento: {pvs}." : $"El pivote ({pvs}) ya está en la última posición.") +
                $" i = {i} (todavía no hay elementos menores o iguales). j empieza en la posición {lo} y revisará hasta la {hi - 1}.");

            for (int j = lo; j < hi; j++)
            {
                comps++;
                string x = fmt(a[j]);
                bool yes = a[j].CompareTo(pv) <= 0;
                string act;
                if (yes)
                {
                    i++;
                    string before = fmt(a[i]);
                    if (i != j)
                    {
                        (a[i], a[j]) = (a[j], a[i]);
                        swaps++;
                        act = $"{x} es menor o igual que el pivote {pvs}, así que va al grupo de la izquierda. i sube a {i}. Intercambiamos la posición {i} con la {j}: {before} ↔ {x}.";
                    }
                    else
                    {
                        act = $"{x} es menor o igual que el pivote {pvs}, así que va al grupo de la izquierda. i sube a {i}. i y j son la misma posición ({j}), así que el intercambio no cambia nada.";
                    }
                }
                else
                {
                    act = $"{x} es mayor que el pivote {pvs}, así que se queda donde está. i sigue en {i}.";
                }
                act += j + 1 < hi ? $" j avanza a {j + 1}." : " j llega al pivote: la revisión termina.";
                Add(StepKind.Compare, lo, hi, i, j, -1, $"Partición {n} · j = {j}", $"¿{x} ≤ {pvs}?  {(yes ? "Sí" : "No")}", act);
            }

            int p = i + 1;
            string bf = fmt(a[p]);
            string mv;
            if (p != hi)
            {
                (a[p], a[hi]) = (a[hi], a[p]);
                swaps++;
                mv = $"Intercambiamos la posición {p} (primer elemento mayor: {bf}) con el pivote en la posición {hi}: {bf} ↔ {pvs}.";
            }
            else
            {
                mv = $"El pivote ya está en la posición {p}, la última, así que no cambia nada.";
            }
            done[p] = true;
            Add(StepKind.Final, lo, hi, i, hi, p, $"Partición {n} · Pivote a su lugar", $"Pivote {pvs} a su lugar",
                $"{mv} El {pvs} queda fijo en la posición {p}. Resultado: {Rng(lo, hi)}. Izquierda: {Side(p - lo)}. Derecha: {Side(hi - p)}.");

            Quick(lo, p - 1);
            Quick(p + 1, hi);
        }
    }
}
