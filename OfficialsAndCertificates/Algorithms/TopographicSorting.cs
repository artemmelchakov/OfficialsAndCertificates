using System.Linq;

namespace OfficialsAndCertificates.Algorithms
{
    public static class TopographicSorting
    {
        public static IEnumerable<uint> Sort(Dictionary<uint, uint[]> nodeDependencyDictionary)
        {
            bool isFirstCycle = true;
            var resultStack = new Stack<uint>();
            while (true)
            {
                //В теории графов, узел графа, в который входят связи, но не выходят, называется вершиной с входящими дугами (англ. source node).
                //Получим список таких узлов.
                var sourceNodes = nodeDependencyDictionary.Values.SelectMany(v => v).Distinct();
                //В теории графов, узел графа, из которого не выходят связи, а только входят, называется стоком (англ. sink).
                //Получим список таких узлов.
                var sinkNodes = nodeDependencyDictionary.Keys.Except(sourceNodes);

                // При первом прохождении цикла мы должны записать самые первые стоки. Затем же алгоритм будет добавлять
                // только узлы-зависимости (requiredNode) текущих стоков.
                if (isFirstCycle)
                {
                    // Добавляем первые стоки в результирующий список.
                    foreach (var sinkNode in sinkNodes)
                    {
                        resultStack.Push(sinkNode);
                    }
                    isFirstCycle = false;
                }

                // Получаем узлы-зависимости (requiredNode) текущих стоков и помещаем их в стек.
                var requiredNodes = sinkNodes.SelectMany(sinkNode => nodeDependencyDictionary[sinkNode]).Distinct();
                foreach (var requiredNode in requiredNodes)
                {
                    if(!resultStack.Contains(requiredNode))
                    {
                        resultStack.Push(requiredNode);
                    }
                }

                // Если количество стоков не равно количеству пар в словаре,
                // это означает, что можно убрать из словаря эти стоки и продолжить алгоритм.
                if (sinkNodes.Count() != nodeDependencyDictionary.Count)
                {
                    // Убираем из словаря стоки 
                    foreach ( var sinkNode in sinkNodes) 
                    {
                        nodeDependencyDictionary.Remove(sinkNode);
                    }
                }
                // Если же количество стоков равно количеству пар в словаре, то остались только последние стоки и вершины с входящими в них дугами.
                // Их следует записать в стек и закончить алгоритм - все узлы будут лежать в нём отсортированными необходимым нам способом.
                else
                {
                    return resultStack.AsEnumerable();
                }
            }
        }
    }
}
