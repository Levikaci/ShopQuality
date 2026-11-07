# ShopQuality — учебный проект для лабораторной работы № 10

Решение .NET 9: библиотека расчёта суммы заказа, стоимости доставки и переходов статусов, а также отдельный проект xUnit с небольшим первоначальным набором тестов.

## Как открыть

Откройте `ShopQuality.sln` в Visual Studio 2022 с поддержкой .NET 9 либо используйте терминал в корне папки.

```powershell
dotnet --version
dotnet restore ShopQuality.sln
dotnet build ShopQuality.sln -c Debug
dotnet test ShopQuality.sln -c Debug
```

Для получения покрытия:

```powershell
dotnet test tests/ShopQuality.Core.Tests/ShopQuality.Core.Tests.csproj -c Debug --collect:"XPlat Code Coverage"
```

Ищите `coverage.cobertura.xml` в папке `tests/ShopQuality.Core.Tests/TestResults/<идентификатор>/`. Не перепутайте покрытие строк и покрытие ветвей. Для краткой сводки можно прочитать атрибуты `line-rate` и `branch-rate` корневого элемента XML и умножить на 100; по отдельным классам смотрите элементы `class`. Сгенерированный файл покрытия — результат измерения, не редактируйте его вручную.

**Важно:** сначала зафиксируйте исходные показатели, затем добавляйте тесты только в отдельном задании или копии проекта: иначе результаты разных студентов не будут сопоставимы.

Подробное задание предоставляется отдельным `.md` файлом. Функциональные требования: `docs/requirements.md`.
