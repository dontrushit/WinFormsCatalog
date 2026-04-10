# Generics и коллекции (C#)

Конспект: Generics, IEnumerable, List, IList/ICollection, Dictionary, HashSet, Queue, Stack, value/reference в списках, boxing, порядок сложности, куда копать дальше.

## Оглавление

1. [Generics](#1-generics)
2. [IEnumerable](#2-ienumerable)
3. [List](#3-list)
4. [IList, ICollection](#4-ilist-icollection)
5. [Dictionary](#5-dictionary)
6. [HashSet](#6-hashset)
7. [Queue, Stack](#7-queue-stack)
8. [Value и reference](#8-value-и-reference)
9. [Boxing / unboxing](#9-boxing--unboxing)
10. [Big O](#10-big-o)
11. [Дальше](#11-дальше)

---

## 1. Generics

Параметр типа в угловых скобках: один класс/метод — разные конкретные типы. Компилятор подставляет тип и ловит ошибки до запуска.

```csharp
public class Container<T>
{
    public T Item { get; set; }
}

var c = new Container<int>();
c.Item = 42;
```

**Зачем:** старые коллекции вроде `ArrayList` хранят `object`. Туда можно положить что угодно, наружу — касты и риск `InvalidCastException`. `List<int>` хранит именно int, без приведений.

**Ограничения (`where`):**

```csharp
class A<T> where T : class { }
class B<T> where T : struct { }
class C<T> where T : new() { }
class D<T> where T : IComparable<T> { }
```

Несколько условий: `where T : class, new()`.

---

## 2. IEnumerable

`IEnumerable<T>` — контракт «можно перечислить элементы T» (foreach, LINQ). У `List<T>` он есть.

```csharp
foreach (var x in list) { }
```

Метод, который принимает `IEnumerable<T>`, съест и список, и массив, и что угодно перечисляемое.

---

## 3. List

`using System.Collections.Generic;`

Внутри — массив `T[]`. Мало места — выделяется больший буфер, элементы копируются. **Count** — сколько элементов, **Capacity** — размер буфера.

Создание:

```csharp
var a = new List<int>();
var b = new List<int>(100);
var c = new List<int> { 1, 2, 3 };
```

Часто используемое:

- `Add`, `AddRange`
- `Insert`, `Remove`, `RemoveAt`, `Clear`
- `[i]` — чтение/запись по индексу
- `Contains`, `IndexOf`, `LastIndexOf`
- `Sort` (для своих типов — делегат или `IComparable`)
- `Find`, `FindAll`, `FindIndex` (предикат)

Пример со своим классом:

```csharp
public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
}

var catalog = new List<Product>();
catalog.Add(new Product { Id = 1, Title = "Стол", Price = 5000m });
var cheap = catalog.FindAll(p => p.Price < 3000m);
catalog.Sort((x, y) => x.Price.CompareTo(y.Price));
```

**List норм:** индекс, порядок, обход целиком, в основном `Add` в конец.

**List плохо:** частые вставки/удаления из середины (сдвиг), поиск по ключу без перебора — тогда словарь.

---

## 4. IList, ICollection

Цепочка: `IEnumerable<T>` → `ICollection<T>` (добавить/удалить, Count) → `IList<T>` (индексатор, Insert, RemoveAt). `List<T>` реализует всё это.

Параметр `IList<T>` — если нужен индекс, но не важен конкретный класс списка.

---

## 5. Dictionary

Ключ → значение, ключи уникальны. Поиск по ключу в среднем O(1).

```csharp
var d = new Dictionary<string, int>();
d["usd"] = 1;
d.Add("eur", 2);
if (d.TryGetValue("usd", out var v)) { }
d.Remove("eur");
```

Индекс по Id из списка объектов — частый паттерн: пройти список, положить в словарь `id → объект`.

---

## 6. HashSet

Только уникальные элементы. `Contains` и `Add` в среднем O(1). Порядок обхода не опирайся.

Убрать дубликаты из списка: `new HashSet<T>(list)` и при необходимости обратно в `List`.

---

## 7. Queue, Stack

**Queue:** FIFO — `Enqueue`, `Dequeue`, `Peek`.

**Stack:** LIFO — `Push`, `Pop`, `Peek`.

---

## 8. Value и reference

`List<int>` — в буфере лежат значения. `List<Product>` — ссылки на объекты в куче. Взял элемент в переменную и поменял поля — изменился тот же объект, что в списке.

---

## 9. Boxing / unboxing

`int` в `object` — boxing (аллокация в куче). `(int)obj` — unboxing. В `List<int>` элементы не упаковываются в object как в ArrayList.

---

## 10. Big O

| | List | Dictionary | HashSet |
|--|------|------------|---------|
| Add | O(1)* | O(1)* | O(1)* |
| Поиск «есть ли» / по ключу | O(n) | O(1)* | O(1)* |
| Удаление | O(n) | O(1)* | O(1)* |
| [i] | O(1) | — | — |

*В среднем; у List при росте бывают перераспределения буфера.

---

## 11. Дальше

LINQ (`Where`, `Select`, `OrderBy`, `First`, `Any`, `ToList` и т.д.) — поверх `IEnumerable<T>`.

Ещё по мере надобности: `ReadOnlyCollection<T>`, immutable-коллекции, `ConcurrentDictionary` / `ConcurrentQueue`, `Span<T>`.

```csharp
var titles = catalog.Where(p => p.Price > 0).Select(p => p.Title).ToList();
var one = catalog.FirstOrDefault(p => p.Id == 1);
```
