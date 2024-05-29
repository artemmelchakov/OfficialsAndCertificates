# OfficialsAndCertificates

Данное решение - тестовое задание по следующей задаче:

Есть N чиновников, каждый из которых выдает справку определенного вида. Кроме того, у каждого чиновника есть набор справок, которые нужно получить до того, как обратиться к нему за справкой. Запрограммировать алгоритм, по которому можно получить все справки. Обойтись без рекурсии.

Пример:
N=4
Зависимость между чиновниками - {1, [2]}, {2,[3,4]} (т.е. первый чиновник чтобы дать справку требует справку от второго, а второй от третьего и четвертого).
Допустимы ответы:
{3, 4, 2, 1}
{4, 3, 2, 1}

Замечание:
Достаточно получить один вариант ответа (все не нужны).
Могут быть несвязанные чиновники, к примеру {1,[2]}, {3,[4]}   (не связаны, один из вариантов ответа {4, 3, 2, 1}).
