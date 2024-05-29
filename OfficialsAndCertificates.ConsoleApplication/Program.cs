using OfficialsAndCertificates.Algorithms;

// Есть N чиновников, каждый из которых выдает справку определенного вида.
// Кроме того, у каждого чиновника есть набор справок, которые нужно получить до того, как обратиться к нему за справкой.
// Запрограммировать алгоритм, по которому можно получить все справки. Обойтись без рекурсии.
// Пример:
// N = 4
// Зависимость между чиновниками - {1, [2]}, { 2,[3,4]}
// (т.е.первый чиновник чтобы дать справку требует справку от второго, а второй от третьего и четвертого).
// Допустимы ответы:
// { 3, 4, 2, 1}
// { 4, 3, 2, 1}

// Для решения данной задачи введен словарь зависимостей, где Key - это Id чиновника, выдающего справку,
// а в Value находятся Id тех чиновников, к которым должен сперва прийти человек за справками, чтобы текущий чиновник мог выдать свою.

// Опишем зависимость узлов в виде словаря, где Key - это Id узла,
// а Value - массив узлов, из которых идут дуги к данному узлу (массив узлов-зависимостей).
var nodeDependencyDictionary = new Dictionary<uint, uint[]> 
{
    { 1, [2] }, 
    { 2, [3, 4] }
};

ShowNodeDependencyDictionary(nodeDependencyDictionary);

var sortedEnumerable = TopographicSorting.Sort(nodeDependencyDictionary);

ShowSortedEnumerable(sortedEnumerable);

Console.ReadKey(true);





// Вывод словаря зависимостей узлов в консоль
void ShowNodeDependencyDictionary(Dictionary<uint, uint[]> nodeDependencyDictionary)
{
    foreach (var keyValuePair in nodeDependencyDictionary)
    {
        Console.WriteLine($"{{ {keyValuePair.Key}, [{string.Join(", ", keyValuePair.Value.Select(v => v))}] }}");
    }
    Console.WriteLine();
}

// Вывод отсортированного перечисления в консоль
void ShowSortedEnumerable(IEnumerable<uint> sortedEnumerable)
{
    Console.WriteLine(string.Join(", ", sortedEnumerable));    
}